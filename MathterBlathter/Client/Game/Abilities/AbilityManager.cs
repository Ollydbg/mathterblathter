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


namespace Client.Game.Abilities
{

	using Game = Client.Game.Core.Game;

	public class AbilityManager : IGameManager
	{

		public Dictionary<Actor, List<AbilityBase>> Abilities = new Dictionary<Actor, List<AbilityBase>>();

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
				foreach (var ability in kvp.Value) {

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
					Abilities [rp.actor].Remove (rp.ability);
				} else {
					Abilities.Remove(rp.actor);
				}
			}

		}




		public void ActivateAbility(AbilityContext ctx) {
			deferredAds.Enqueue(ctx);
		}

		private void readAddQueue(AbilityContext ctx) {
			var ability = (AbilityBase)Activator.CreateInstance(ctx.data.executionScript);

			List<AbilityBase> abilities;
			if(!Abilities.TryGetValue(ctx.source, out abilities)) {
				abilities = new List<AbilityBase>();
				Abilities[ctx.source] = abilities;
			}
				
			abilities.Add (ability);

			ability.Init (ctx);
			ability.Start ();
		}


		public void AddActor (Actor actor)
		{
			if(!ActorUsesAbilities(actor)) {
				return;
			}


			var buffDatasToCreate = actor.Data.attributeData
				.Where( p=>p.Id == ActorAttributes.Abilities.Id)
				.Select(p => MockAbilityData.FromId(p.ValueI))
				.Where(p=>p.AbilityType == AbilityType.Buff);

			foreach( var buffData in buffDatasToCreate) {
				ActivateAbility( new AbilityContext(actor, buffData));
			}
		}

		public void RemoveActor(Actor actor) {
			deferredRemoves.Enqueue(new RemovePair(actor, null));
		}

		bool ActorUsesAbilities (Actor actor)
		{
			return actor.Attributes[ActorAttributes.Abilities] != ActorAttributes.Abilities.DefaultValue;//actor.ActorType == ActorType.Enemy || actor.ActorType == ActorType.Friendly || actor.ActorType == ActorType.Fixture || actor.ActorType == ActorType.Pickup;
		}

		//returns true if it got consumed
		public bool NotifyPayloadSender (Payload payload, Actor actor)
		{
			return false;	
		}

		//returns true if it got consumed
		public bool NotifyPayloadReceiver (Payload payload, Actor actor)
		{
			return false;
		}

		public class RemovePair {
			public Actor actor;
			public AbilityBase ability;
			public RemovePair(Actor actor, AbilityBase ability) {this.actor = actor; this.ability = ability;}
		}
	}



}

