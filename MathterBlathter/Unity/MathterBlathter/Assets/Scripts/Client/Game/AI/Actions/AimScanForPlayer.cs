using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Utils;

namespace Client.Game.AI.Actions 
{
	public class AimScanForPlayer : AIAction
	{
		
		private static int _castingMask = -1;
		public static int CastingMask {
			get {
				if(_castingMask == -1) {
					_castingMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Player.ToString()});
						
				}
				return _castingMask;
			}
		}
		public AimScanForPlayer ()
		{
		}


		double accum = 0;
		#region implemented abstract members of AIAction
		
		public override AIResult Update (float dt, Character actor)
		{
			accum += dt;

			float aimAngle = actor.Attributes[ActorAttributes.AIScanDegrees];
			float aimConstraint = aimAngle / 360f;

			double angle = Math.Sin(accum) * aimConstraint;

			Vector3 aimVector = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0f).normalized;

			Actor hitActor;

			aimVector = actor.transform.rotation * aimVector;

			actor.WeaponController.AimDirection = aimVector;

			var origin = AttachPointComponent.AttachPointPositionOnActor(AttachPoint.Muzzle, actor);
			if (ActorUtils.RayCastForActor(origin, aimVector, out hitActor, CastingMask)) {
				if(hitActor.Id == actor.Game.PossessedActor.Id) {
					return AIResult.Success;
				}
			}

			return AIResult.Running;	

		}

		#endregion
	}


	//this is a poor substitute for our tree not having sequencing functions!
	public class FireAimingDirectionAtPlayer : FireAimingDirection {
		
		public override AIResult Update (float dt, Character actor)
		{
			if(lockedOn(actor)) {
				return base.Update(dt, actor);
			} else {
				return AIResult.Failure;
			}
		}

		private bool lockedOn(Actor actor) {
			var origin = AttachPointComponent.AttachPointPositionOnActor(AttachPoint.Muzzle, actor);
			Actor hitActor;
			if (ActorUtils.RayCastForActor(origin, actor.WeaponController.AimDirection, out hitActor, AimScanForPlayer.CastingMask)) {
				if(hitActor.Id == actor.Game.PossessedActor.Id) {
					return true;
				}
			}
			return false;
		}



	}
}

