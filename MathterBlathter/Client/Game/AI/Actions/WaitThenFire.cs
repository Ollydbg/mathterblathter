using System;
using Client.Game.Actors;
using UnityEngine;

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
			if(ActionUtil.HasLOS(actor, PlayerMid)) {
				time += dt;
				if(time >= 3f) {
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

