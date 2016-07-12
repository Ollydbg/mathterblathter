﻿using System;
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


		public override AIResult Update (float dt, Character actor)
		{
			var target = PlayerMid;
			var distanceVec = target - actor.transform.position;

			FaceTarget2D(actor, target);

			if (!inAbilityRange (distanceVec, actor)) {
				return AIResult.Failure;
			} else {
				ActionUtil.TryActivateAbility (PlayerMid, actor);
				return AIResult.Running;
			}

		}


	}
}

