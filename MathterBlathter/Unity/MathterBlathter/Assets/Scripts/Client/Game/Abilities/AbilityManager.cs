using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Abilities.Scripts;
using System.Linq;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Enums;
using UnityEngine;
using Client.Game.Utils;


namespace Client.Game.Abilities
{

	using Game = Client.Game.Core.Game;
	using AbilityMap = Dictionary<InstanceId, AbilityBase>;

	public class AbilityManager : IGameManager
	{

		public Dictionary<Actor, AbilityMap> Abilities = new Dictionary<Actor, AbilityMap>();

		public void SetPlayerCharacter (PlayerCharacter player)
		{
		}


		private Queue<RemovePair> deferredRemoves = new Queue<RemovePair>();
		private Queue<AbilityContext> deferredAds = new Queue<AbilityContext>();

		public AbilityManager ()
		{
			
		}

		public void Start (Game game)
		{
			
		}

		public void Shutdown ()
		{
			Abilities.Clear();
			deferredRemoves.Clear();
			deferredAds.Clear();
		}


		public void Update (float dt)
		{
			
			while(deferredAds.Count>0){
				readAddQueue(deferredAds.Dequeue());		
			}

			foreach (var kvp in Abilities) {
				foreach (var ability in kvp.Value.Values) {

					ability.Update(dt);
					if (ability.isComplete ()) {
						deferredRemoves.Enqueue (new RemovePair (kvp.Key, ability));
					}
				}
			}

			//cull
			while (deferredRemoves.Count > 0) {
				var rp = deferredRemoves.Dequeue ();
				if(rp.ability != null) {
					rp.ability.End ();
					AbilityMap actorAbils;
					if(Abilities.TryGetValue(rp.actor, out actorAbils)) {
						Abilities [rp.actor].Remove (rp.ability.InstanceId);
					}
					
				} else {
					Abilities.Remove(rp.actor);
				}
			}
		}


		public void ActivateAbility(AbilityContext ctx) {
			deferredAds.Enqueue(ctx);
		}

		private void readAddQueue(AbilityContext ctx) {

			AbilityMap abilities;
			if(!Abilities.TryGetValue(ctx.source, out abilities)) {
				abilities = new AbilityMap();
				Actor owner = ctx.source;
				Abilities[owner] = abilities;
			}
				
			//look for pre-existing instance
			if(ctx.data.IsBuff) {
				AbilityBase ability;
				if(abilities.TryGetValue(ctx, out ability)) {
					var buff = ability as BuffBase;
					buff.Stack(ctx);
				} else {
					abilities.Add (ctx, CreateAndStart(ctx));
				}

			} else {
				var ability = CreateAndStart(ctx);
				abilities.Add (ability.InstanceId, ability);

			}
		}

		private AbilityBase CreateAndStart(AbilityContext ctx) {
			var ability = (AbilityBase)Activator.CreateInstance(ctx.data.executionScript);
			ability.Init (ctx);
			ability.InstanceId = ctx;
			ability.Start ();

			return ability;
		}

		public void AddActor (Actor actor)
		{
			
			foreach( int dataId in ActorUtils.IterateAttributes(actor, ActorAttributes.Abilities) ) {
				var data = MockAbilityData.FromId(dataId);
				if(data.IsBuff) {
					var context = new AbilityContext(actor, actor, data);
					ActivateAbility(context);
				}
			}
		}
				

		public void RemoveActor(Actor actor) {
			deferredRemoves.Enqueue(new RemovePair(actor, null));
		}

		bool ActorUsesAbilities (Actor actor)
		{
			return actor.Attributes[ActorAttributes.Abilities] != ActorAttributes.Abilities.DefaultValue;
		}

		//returns true if it got consumed
		public bool NotifyPayloadSender (Payload payload, Actor actor)
		{
			foreach( AbilityBase ability in Abilities[actor].Values) {
				if(ability.OnPayloadSend(payload))
					return true;
			}
			return false;
		}

		//returns true if it got consumed
		public bool NotifyPayloadReceiver (Payload payload, Actor actor)
		{
			foreach( AbilityBase ability in Abilities[actor].Values) {
				if(ability.OnPayloadReceive(payload))
					return true;
			}
			return false;
		}

		public class RemovePair {
			public Actor actor;
			public AbilityBase ability;
			public RemovePair(Actor actor, AbilityBase ability) {this.actor = actor; this.ability = ability;}
		}

	}

	public class InstanceId : IEquatable<InstanceId> {
		public static int buffOffset = 0xFF;
		public static int lastId = 1;
		private int Id;

		public InstanceId(AbilityContext ctx) {
			if(ctx.data.IsBuff) {
				Id = ctx.data.Id << 16 | buffOffset;
			} else {
				Id = ctx.data.Id << 16 | ++lastId;
			}
		}

		public static implicit operator InstanceId(AbilityContext ctx) {
			return new InstanceId(ctx);
		}

		public override int GetHashCode ()
		{
			return Id.GetHashCode();
		}

		public bool Equals (InstanceId other)
		{
			return Id == other.Id;
		}

	}



}

