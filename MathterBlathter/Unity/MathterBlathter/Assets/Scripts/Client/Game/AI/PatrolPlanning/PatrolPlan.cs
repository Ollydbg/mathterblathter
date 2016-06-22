using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.Attributes;
using Client.Utils;

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

			route.Left = VectorUtils.Vector2(actor.GameObject.transform.position);
			route.Right = VectorUtils.Vector2(actor.GameObject.transform.position);

			while(true) {
				var test = route.Left + Vector2.left;

				if(PositionIsTraversable(test, actor)) {
					route.Left = test;
				} else {
					break;
				}
			}

			while(true) {
				var test = route.Right + Vector2.right;

				if(PositionIsTraversable(test, actor)) {
					route.Right = test;
				} else {
					break;
				}
			}

			return route;
		}


		private bool PositionIsTraversable(Vector2 position, Actor byActor) {
			int mask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Door.ToString()});

			//is that position a wall? 
			var offsetTest = position + new Vector2(0, .5f);
			var wallHits = Physics2D.OverlapCircleAll(offsetTest, .01f, mask);
			if(wallHits.Length > 0)
				return false;

			//if the enemy is grounded, is immediately underneath a floor?
			if(byActor.Attributes[ActorAttributes.GravityScalar] != 0f) {
				var underneath = position + new Vector2(0, -.5f);
				int walkableMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.SoftGeometry.ToString()});

				var floorHits = Physics2D.OverlapCircleAll(underneath, .1f, walkableMask);

				return floorHits.Length > 0;
			}

			return true;
		}

	}

	public class PatrolRoute {

		public Vector2 Left;
		public Vector2 Right;

		public void Flip() {
			CurrentDirection *= -1f;
		}

		public Vector2 CurrentDirection;
	}
}

