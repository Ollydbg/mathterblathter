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

			if (inDetectionRange (distanceVec, actor)) {

				FaceTarget(actor, target);

				var moveMagnitude = .08f;

				actor.transform.position += distanceVec.normalized * moveMagnitude;

			}
			return inAbilityRange (distanceVec, actor) ? AIResult.Success : AIResult.Incomplete;

		}

		#endregion



		bool inDetectionRange (Vector3 distanceVec, Actor selfActor)
		{
			var detectionRange = selfActor.Attributes [ActorAttributes.AIDetectionRadius];
			return distanceVec.sqrMagnitude <= (detectionRange * detectionRange);
		}
	}
}

