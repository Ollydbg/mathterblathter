﻿using System;
using Client.Game.Actors;
using Client.Game.AI.Actions;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.AI.Actions
{
	public class SeekToPlayerLOS : AIAction
	{
		public SeekToPlayerLOS ()
		{
		}


		public override AIResult Update (float dt, Character actor)
		{
			var target = PlayerMid;

			var distanceVec = target - actor.transform.position;

			if(ActionUtil.InDetectionRange(distanceVec, actor)) {
				if(ActionUtil.HasLOS(actor, target)) {
					return AIResult.Success;
				} else {

					var moveVec = new Vector3(distanceVec.x, 0, 0);
					((Character)actor).Controller.MoveDirection(moveVec.normalized);

				}
			} else {
				
			}
			return AIResult.Running;
		}


	}
}

