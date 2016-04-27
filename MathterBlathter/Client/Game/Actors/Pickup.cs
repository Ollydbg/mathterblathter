using System;
using Client.Game.Data;
using UnityEngine;

namespace Client.Game.Actors
{
	public class Pickup : Actor , IInteractable
	{
		public Pickup ()
		{
		}


		public void Interact ()
		{
			throw new NotImplementedException ();
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

