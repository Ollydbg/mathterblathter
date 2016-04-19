using System;
using Client.Game.Actors;
using UnityEngine;
using System.Linq;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Data;

namespace Client.Game.Items
{
	public class PickupController
	{
		Actor Owner;

		float updateInterval = .5f;
		float accumulator = 0f;

		public Pickup ClosestPickup;

		int _pickupMask;
		private int pickupMask {
			get {
				if(_pickupMask == 0) {
					_pickupMask = 1<<LayerMask.NameToLayer(Layers.Pickups.ToString());
				}
				return _pickupMask;
			}
		}

		public PickupController (Actor owner)
		{
			this.Owner = owner;
		}


		void Consume(Pickup actor) {
			//give to owner

			((PlayerCharacter)Owner).WeaponController.AddWeapon(MockWeaponData.CERAMIC_SHOTGUN);

			//remove from this world
			actor.Game.ActorManager.RemoveActor(actor);
			ClosestPickup = null;
		}


		public void PickupClosest ()
		{
			if(ClosestPickup != null) {
				Consume(ClosestPickup);
			}

		}

		void UpdateSlow ()
		{
			ClosestPickup = GetClosestPickup();
		}

		Pickup GetClosestPickup() {
			var colliders = Physics.OverlapSphere(Owner.transform.position, Owner.Attributes[ActorAttributes.PickupRadius], pickupMask);

			float shortestDistance = float.MaxValue;
			Pickup closestPickup = null;

			foreach( var collider in colliders ) {
				var actorRef = collider.GetComponent<ActorRef>();
				if(actorRef != null) {
					if(actorRef.Actor.ActorType == Client.Game.Data.ActorType.Pickup) {
						//find closest
						var distance = (Owner.transform.position - collider.gameObject.transform.position).sqrMagnitude;

						if(distance < shortestDistance) {
							shortestDistance = distance;
							closestPickup = (Pickup)actorRef.Actor;
						}
						
					}
				}
			}

			return closestPickup;
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

