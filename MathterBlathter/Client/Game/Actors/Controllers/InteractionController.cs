using System;
using Client.Game.Data;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Enums;

namespace Client.Game.Actors.Controllers
{
	public class InteractionController
	{
		Actor Owner;

		float updateInterval = .1f;
		float accumulator = 0f;

		public IInteraction Closest;

		public InteractionController(Actor owner) {
			this.Owner = owner;
		}



		public void InteractClosest() {
			if(Closest != null) {
				Closest.Interact(Owner);
			}
		}


		void UpdateSlow () 
		{
			Closest = GetClosest();

		}

		IInteraction GetClosest() {

			var colliders = Physics.OverlapSphere(Owner.transform.position, Owner.Attributes[ActorAttributes.InteractionRadius]);
			float shortestDistance = float.MaxValue;
			IInteraction closestObject = null;

			foreach( var collider in colliders ) {
				var actorRef = collider.GetComponent<ActorRef>();
				if(actorRef != null) {
					if(actorRef.Actor is IInteraction) {
						var distance = (Owner.transform.position - collider.gameObject.transform.position).sqrMagnitude;

						if(distance < shortestDistance) {
							shortestDistance = distance;
							closestObject = (IInteraction)actorRef.Actor;
						}
					}

				}
			}


			return closestObject;
		}

		public void Update(float dt) {
			accumulator+= dt;
			if(accumulator >= updateInterval) {
				accumulator -= updateInterval;
				UpdateSlow();
			}
		}
	}
}

