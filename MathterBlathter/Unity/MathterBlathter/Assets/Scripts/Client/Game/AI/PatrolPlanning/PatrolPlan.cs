using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.Attributes;

namespace Client.Game.AI.PatrolPlanning
{
	public class PatrolPlan
	{
		public PatrolPlan() {
		}

		public PatrolRoute PlanRoute(Actor actor)
		{
			var route = new PatrolRoute();
			route.CurrentDirection = Vector3.right;

			route.Left = actor.GameObject.transform.position;
			route.Right = actor.GameObject.transform.position;

			while(true) {
				var test = route.Left + Vector3.left;

				if(PositionIsTraversable(test, actor)) {
					route.Left = test;
				} else {
					break;
				}
			}

			while(true) {
				var test = route.Right + Vector3.right;

				if(PositionIsTraversable(test, actor)) {
					route.Right = test;
				} else {
					break;
				}
			}

			return route;
		}


		private bool PositionIsTraversable(Vector3 position, Actor byActor) {
			int mask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Door.ToString()});

			//is that position a wall? 
			var offsetTest = position + new Vector3(0, .5f, 0);
			var wallHits = Physics.OverlapSphere(offsetTest, .01f, mask);
			if(wallHits.Length > 0)
				return false;

			//if the enemy is grounded, is immediately underneath a floor?
			if(byActor.Attributes[ActorAttributes.GravityScalar] != 0f) {
				var underneath = position + new Vector3(0, -.5f, 0);
				int walkableMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.SoftGeometry.ToString()});

				var floorHits = Physics.OverlapSphere(underneath, .1f, walkableMask);

				return floorHits.Length > 0;
			}

			return true;
		}

	}

	public class PatrolRoute {

		public Vector3 Left;
		public Vector3 Right;

		public void Flip() {
			CurrentDirection *= -1f;
		}

		public Vector3 CurrentDirection;
	}
}

