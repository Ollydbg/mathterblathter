using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.AI.PatrolPlanning;
using Client.Utils;

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
				Route = new PatrolPlan().PlanRoute(actor);
			}


			Vector3 target = NextGoal(actor);

			FaceTarget(actor, target);
			actor.transform.position += VectorUtils.Vector3(Route.CurrentDirection * actor.Attributes[ActorAttributes.Speed]);
			
			return AIResult.Running;
		}

		private Vector3 NextGoal(Actor actor) {
			if(Route.CurrentDirection == Vector2.right) {
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

        #endregion

	}
}

