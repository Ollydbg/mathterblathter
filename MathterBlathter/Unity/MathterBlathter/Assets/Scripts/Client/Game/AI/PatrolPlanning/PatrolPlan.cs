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

		//padding
		public const float OBSTACLE_CLEARANCE = .1f;

		private bool Flying(Actor actor) {
			
			return actor.Attributes[ActorAttributes.GravityScalar] == 0f;
		}


		public PatrolRoute PlanRoute(Actor actor)
		{

			Debug.Log("Creating patrol plan for actor: " + actor);

			var route = new PatrolRoute();
			route.CurrentDirection = Vector3.right;

			route.Left = VectorUtils.Vector2(actor.GameObject.transform.position);
			route.Right = VectorUtils.Vector2(actor.GameObject.transform.position);
			var colliderExtents = VectorUtils.Vector2(actor.TerrainCollider.bounds.extents);

			colliderExtents += Vector2.one * OBSTACLE_CLEARANCE;

			if(Flying(actor)) {

				route.Right = PatrolExtentInDirection(actor.transform.position, Vector2.right, colliderExtents);
				route.Left = PatrolExtentInDirection(actor.transform.position, Vector2.left, colliderExtents);

			} else {
				while(true) {
					var test = route.Right + Vector2.right;

					if(PointIsWalkable(test, actor)) {
						route.Right = test;
					} else {
						break;
					}
				}

				while(true) {
					var test = route.Left + Vector2.left;

					if(PointIsWalkable(test, actor)) {
						route.Left = test;
					} else {
						break;
					}
				}

			}
			
		
			return route;
		}


		public Vector2 PatrolExtentInDirection(Vector2 position, Vector2 direction, Vector2 extents) {
			int mask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Door.ToString()});
			var maxDistance = 200f;
			var hit = Physics2D.CircleCast(position, extents.y, direction, maxDistance, mask);

			if(hit.transform != null) {
				var offset = direction.x > 0 ? extents.x * Vector2.right : extents.x * Vector2.left;

				return hit.point - offset;
			} else {
				return position + direction * maxDistance;
			}

		}

		private bool PointIsWalkable(Vector2 position, Actor byActor) {
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

