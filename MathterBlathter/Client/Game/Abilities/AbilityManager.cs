using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Abilities.Scripts;
using System.Linq;
namespace Client.Game.Abilities
{

	using Game = Client.Game.Core.Game;

	public class AbilityManager : IGameManager
	{

		public Dictionary<Actor, List<AbilityBase>> Abilities = new Dictionary<Actor, List<AbilityBase>>();


		public Queue<RemovePair> deferredRemoves = new Queue<RemovePair>();

		public AbilityManager ()
		{
			
		}

		public void Start (Game game)
		{
			
		}
		public void Shutdown ()
		{
			throw new NotImplementedException ();
		}


		public void Update (float dt)
		{
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
				rp.ability.End ();
				Abilities [rp.actor].Remove (rp.ability);
			}

		}

		public void ActivateAbility(AbilityContext ctx) {
			
			var ability = (AbilityBase)Activator.CreateInstance(ctx.data.executionScript);
			Abilities [ctx.source] = new List<AbilityBase> ();
			Abilities [ctx.source].Add (ability);

			ability.Init (ctx);
			ability.Start ();

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

