using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.AI.Actions
{
	public class AimSteerAtPlayer : AIAction
	{
		private static float EPSILON = .001f;

		public AimSteerAtPlayer ()
		{
		}

		#region implemented abstract members of AIAction

		public override AIResult Update (float dt, Character actor)
		{
			
			var playerDirection = PlayerMid - actor.transform.position;
			var currentDirection = actor.WeaponController.AimDirection;
			var angle = Vector2.Angle(currentDirection, playerDirection);
			Vector2 clampedDirection;

			if(angle > EPSILON) {
				
				var clamped = Mathf.Clamp(angle, 0, actor.Attributes[ActorAttributes.AIMaxTurnSpeed] * dt);
				var pct = clamped/ angle;
				if (pct < EPSILON) {
					clampedDirection = currentDirection;
				} else {
					clampedDirection = Vector2.Lerp(currentDirection, playerDirection, pct);
				}

			} else {
				clampedDirection = playerDirection;
			}



			var clampedDot = Mathf.Clamp01(Vector2.Dot(clampedDirection, playerDirection));

			MoveAndAim(clampedDirection, clampedDot, actor);

			return AIResult.Running;
		}


		#endregion

		private void MoveAndAim(Vector2 unNormalized, float amt, Character actor) {
			
			actor.WeaponController.AimDirection = unNormalized.normalized * amt;
			actor.Controller.MoveDirection(unNormalized.normalized * amt);

		}

	}



	public class FireWhileSteeringTowardsPlayer : AIAction {
		#region implemented abstract members of AIAction

		public override AIResult Update (float dt, Character actor)
		{

			if(ActionUtil.AimingAtActor(actor, actor.Game.PossessedActor, 5)) {
				actor.WeaponController.Attack();
			}
			return AIResult.Running;
		}

		#endregion


	}
}

