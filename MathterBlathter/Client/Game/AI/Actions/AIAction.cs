using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.AI
{
	using Game = Client.Game.Core.Game;

	public abstract class AIAction
	{
		public abstract AIResult Update(float dt, Actor actor);
		public AIAction Next;

		internal bool inAbilityRange(Vector3 distanceVec, Actor selfActor) {
			
			return distanceVec.sqrMagnitude < (12 * 12);
		}

		internal Vector3 PlayerMid
		{
			get {
				var possessed = Game.Instance.PossessedActor;
				return possessed.HalfHeight;
			}
		}


		internal void FaceTarget(Actor selfActor, Vector3 target) {

			float angle = target.x < selfActor.transform.position.x ? -90 : 90;

			selfActor.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}
	}



	public enum AIResult {
		Success,
		Failure,
		Incomplete
	}

	public class EmptyAction : AIAction {
		
		public override AIResult Update (float dt, Actor actor)
		{
			return AIResult.Incomplete;
		}



	}
}

