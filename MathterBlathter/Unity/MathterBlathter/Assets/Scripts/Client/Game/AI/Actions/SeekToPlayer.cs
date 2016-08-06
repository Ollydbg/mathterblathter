using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.AI.Actions
{
	public class SeekToPlayer : AIAction
	{
		public SeekToPlayer ()
		{
		}


		#region IAction implementation


		public override AIResult Update (float dt, Character actor)
		{
			//Get player transform
			
			var target = PlayerMid;

			var distanceVec = target - actor.transform.position;
			
			if (ActionUtil.InDetectionRange (distanceVec, actor)) {

				AimAtTarget2D(actor, target);
				actor.Controller.MoveDirection(distanceVec.normalized);
			}
			return inAbilityRange (distanceVec, actor) ? AIResult.Success : AIResult.Running;

		}

		#endregion



	}
}

