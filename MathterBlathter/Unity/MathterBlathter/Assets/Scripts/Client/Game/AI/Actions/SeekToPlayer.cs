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


		public override AIResult Update (float dt, Actor actor)
		{
			//Get player transform
			
			var target = PlayerMid;

			var distanceVec = target - actor.transform.position;
			
			if (ActionUtil.InDetectionRange (distanceVec, actor)) {

				FaceTarget2D(actor, target);
				actor.transform.position += distanceVec.normalized * dt * actor.Attributes[ActorAttributes.Speed];
			}
			return inAbilityRange (distanceVec, actor) ? AIResult.Success : AIResult.Running;

		}

		#endregion



	}
}

