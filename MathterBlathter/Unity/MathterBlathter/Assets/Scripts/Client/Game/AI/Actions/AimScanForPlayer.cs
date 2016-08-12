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
		

		public AimScanForPlayer ()
		{
		}


		double accum = 0;
		
		public override AIResult Update (float dt, Character actor)
		{

			accum += dt;

			float aimAngle = actor.Attributes[ActorAttributes.AIScanDegrees];
			float aimConstraint = aimAngle / 360f;

			double angle = Math.Sin(accum) * aimConstraint;
            
			Vector3 aimVector = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0f).normalized;

			if(actor.FacingLeft)
				aimVector.x *= -1f;
			

			aimVector = actor.transform.rotation * aimVector;

			actor.WeaponController.AimDirection = aimVector;

	  		if(IsAimedAtPlayer(actor))
				return AIResult.Success;
			
			return AIResult.Running;	

		}
        
	}


	public class FireAimingDirectionAtPlayer : FireAimingContinuous {
		
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

