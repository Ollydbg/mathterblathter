using System;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Abilities;
using Client.Game.Utils;

namespace Client.Game.Actors
{
	public class Pickup : Actor , IInteraction
	{
		public Pickup ()
		{
		}

		public Actor InteractionTarget {
			get {
				return this;
			}
		}

		public bool InteractionEnabled {
			get {
				return true;
			}
		}


		public bool Interact (Actor withActor)
		{
			//dump all our abilities onto the interactor
			ActorUtils.PropogateBuffs(this, withActor);
			Game.ActorManager.RemoveActor(this);

			return true;
		}

		public string GetPrompt ()
		{
			return Data.Name;
		}

		public bool CanActorPickup(Actor actor) {
			return true;
		}

		void onCollision (Collider Collider)
		{
			var hitRef = Collider.gameObject.GetComponent<ActorRef>();
			if(hitRef && hitRef.Actor.ActorType == ActorType.Player) {
				this.Game.ActorManager.RemoveActor(this);
			}
		}

		public override void EnterGame (Client.Game.Core.Game game)
		{
			GameObject.GetComponent<ActorRef>().TriggerEvent += onCollision;

			base.EnterGame (game);
		}

	}
}

