using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Enums;

namespace Client.Game.AI.Actions
{
	public class WaitThenFire : AIAction
	{
		public WaitThenFire ()
		{
		}

		Vector3 direction;
		float time = 0f;
		public override void Start (Actor selfActor)
		{
			direction = PlayerMid - selfActor.HalfHeight;
			time = 0f;
		}

		public override AIResult Update (float dt,Actor actor)
		{
			Vector3 muzzle = AttachPointComponent.AttachPointPositionOnActor(AttachPoint.Muzzle, actor);

			var aim = actor.WeaponController.GetAimDirection();

			if(ActionUtil.LineHasActor(muzzle, muzzle + (aim * 40f), Player)) {
				time += dt;
				if(time >= actor.Attributes[ActorAttributes.AIAttackDelay]) {
					actor.WeaponController.Attack(direction.normalized);
					return AIResult.Success;
				}
				return AIResult.Running;
			} else {
				return AIResult.Failure;
			}
		}

	}
}

