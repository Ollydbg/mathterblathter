﻿using System;
using Client.Game.Data;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Enums;
using Client.Utils;

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
				
				//a "true" result means it got consumed
				if(Closest.Interact(Owner)) {
					Closest = null;
				}
			}
		}


		void UpdateSlow () 
		{
			Closest = GetClosest();

		}

		IInteraction GetClosest() {
			var colliders = Physics2D.OverlapCircleAll(VectorUtils.Vector2(Owner.transform.position), Owner.Attributes[ActorAttributes.InteractionRadius]); 
			float shortestDistance = float.MaxValue;
			IInteraction closestObject = null;

			foreach( var collider in colliders ) {
				var actorRef = collider.GetComponent<ActorRef>();
				if(actorRef != null) {
					var interaction = actorRef.Actor as IInteraction;
					if(interaction != null && interaction.InteractionEnabled) {
						var distance = (Owner.transform.position - collider.gameObject.transform.position).sqrMagnitude;

						if(distance < shortestDistance) {
							shortestDistance = distance;
							closestObject = interaction;
						}
					}

				}
			}


			return closestObject;
		}

		public void Update(float dt) {
			UpdateSlow();
			/*
			accumulator+= dt;
			if(accumulator >= updateInterval) {
				accumulator -= updateInterval;
				UpdateSlow();
			}*/

		}
	}
}

