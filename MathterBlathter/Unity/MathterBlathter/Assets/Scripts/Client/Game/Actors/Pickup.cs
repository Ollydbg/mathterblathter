﻿using UnityEngine;
using Client.Game.Data;
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


		public virtual bool Interact (Actor withActor)
		{
			//dump all our abilities onto the interactor
			ActorUtils.PropogateBuffs(this, withActor);
			Destroy();

			return true;
		}

		public string GetPrompt ()
		{
			return Data.Name;
		}

		public bool CanActorPickup(Actor actor) {
			return true;
		}

		void onCollision (Collider2D Collider)
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

	public class ActiveItemPickup : Pickup {
		public override bool Interact (Actor withActor)
		{
			(withActor as PlayerCharacter).ActiveItemController.AddItem(this.Data);
			return base.Interact(withActor);
		}
	}
}

