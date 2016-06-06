using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Enums;

namespace Client.Game.AI.Actions
{
	public class PatrolAction : AIAction
	{
		
		public PatrolRoute Route;
		public bool PatrollingLeft;
		
		public PatrolAction ()
		{
		}
		
		
		
		#region IAction implementation


		public override AIResult Update (float dt, Actor actor)
		{
			if(Route == null) {
				DiscoverPatrolRoute(actor);
			}
			
			Vector3 target = NextGoal(actor);
			var distanceVec = target - actor.transform.position;
			
			FaceTarget(actor, target);
			actor.transform.position += Route.CurrentDirection * actor.Attributes[ActorAttributes.Speed];
			
			return AIResult.Running;
		}

		private Vector3 NextGoal(Actor actor) {
			if(Route.CurrentDirection == Vector3.right) {
				if(actor.transform.position.x >= Route.Right.x) {
					Route.Flip();
					return NextGoal(actor);
				}
					
				return Route.Right;
			} else {
				if(actor.transform.position.x <= Route.Left.x) {
					Route.Flip();
					return NextGoal(actor);
				}
				return Route.Left;
			}
		}

        private void DiscoverPatrolRoute(Actor actor)
        {
			this.Route = new PatrolRoute();
			this.Route.CurrentDirection = Vector3.right;
			
			Route.Left = actor.GameObject.transform.position;
			Route.Right = actor.GameObject.transform.position;
			
			while(true) {
				var test = Route.Left + Vector3.left;
				
				if(PositionIsTraversable(test, actor)) {
					Route.Left = test;
				} else {
					break;
				}
			}
			
			while(true) {
				var test = Route.Right + Vector3.right;
				
				if(PositionIsTraversable(test, actor)) {
					Route.Right = test;
				} else {
					break;
				}
			}
        }
		
		
		private bool PositionIsTraversable(Vector3 position, Actor byActor) {
			int mask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString()});
			
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

        #endregion


        public class PatrolRoute {
			
			public Vector3 Left;
			public Vector3 Right;
			
			public void Flip() {
				CurrentDirection *= -1f;
			}
			
			public Vector3 CurrentDirection;
		}


	}
}

