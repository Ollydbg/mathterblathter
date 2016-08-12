using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.AI.PatrolPlanning;
using Client.Utils;
using Client.Game.Map.TMX;

namespace Client.Game.AI.Actions
{
	public class PatrolAction : AIAction
	{
		
		public PatrolAction ()
		{
		}
		
		

		public override AIResult Update (float dt, Character actor)
		{
			

			if(actor.WeaponController.AimDirection.sqrMagnitude == 0f) {
				actor.WeaponController.AimDirection = Vector2.right;
			}

			Vector2 target;
			if(NextDirection(actor, out target)) {
				//AimAtTarget2D(actor, target);
				actor.Controller.MoveDirection(target.normalized);
			}


			return AIResult.Running;
		}

		Vector2 AimingAsNormalizedX(Actor actor) {
			return actor.WeaponController.AimDirection.x >= 0 ? Vector2.right : Vector2.left;
		}

		void Flip (Actor actor)
		{
			var aim = actor.WeaponController.AimDirection;
			aim.x *= -1f;
			actor.WeaponController.AimDirection = aim;
		}

		private bool NextDirection(Actor actor, out Vector2 direction) {

			var sourcePos = VectorUtils.Vector2(actor.transform.position);
			var aimDir = AimingAsNormalizedX(actor);
			var targetPos = sourcePos + aimDir;

			targetPos.x += ((aimDir.x < 0? -1 : 1) * actor.TerrainCollider.bounds.extents.x);

			if(PointIsTraversable(targetPos, actor)) {
				direction = targetPos - sourcePos;
				return true;
			} else {
				Flip(actor);
				direction = Vector2.zero;
				return false;
			}

		}

		private bool PointIsTraversable(Vector2 position, Actor byActor) {
			int mask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Door.ToString()});

			//is that position a wall? 
			var offsetTest = position + new Vector2(0, .5f);

			var wallHits = Physics2D.LinecastAll(byActor.transform.position, offsetTest, mask);
			if(wallHits.Length > 0)
				return false;

			//if the enemy is grounded, is immediately underneath a floor?
			if(byActor.Attributes[ActorAttributes.GravityScalar] != 0f) {
				var underneath = position + new Vector2(0, -.5f);
				int walkableMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.SoftGeometry.ToString()});
				Debug.DrawRay(underneath, Vector3.forward, Color.green, 1f);
				var floorHits = Physics2D.OverlapCircleAll(underneath, .1f, walkableMask);

				return floorHits.Length > 0;
			}

			return true;
		}

		private bool Flying(Actor actor) {

			return actor.Attributes[ActorAttributes.GravityScalar] == 0f;
		}
        
	}
}

