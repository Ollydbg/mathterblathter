using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Abilities;
using Client.Game.Data;

namespace Client.Game.AI.Actions
{
	public class FireAtPlayer : AIAction
	{
		public FireAtPlayer ()
		{
		}


		public override AIResult Update (float dt, Actor actor)
		{
			var target = PlayerMid;
			var distanceVec = target - actor.transform.position;

			FaceTarget(actor, target);

			if (!inAbilityRange (distanceVec, actor)) {
				return AIResult.Failure;
			} else {

				ActionUtil.TryActivateAbility (PlayerMid, actor);
				return AIResult.Running;
			}

		}


	}
}

