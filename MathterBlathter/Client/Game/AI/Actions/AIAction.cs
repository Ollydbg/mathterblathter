using System;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.AI
{
	using Game = Client.Game.Core.Game;

	public abstract class AIAction
	{
		public abstract AIResult Update(float dt, Actor actor);
		public AIAction Next;

		internal bool inAbilityRange(Vector3 distanceVec, Actor selfActor) {
			return distanceVec.sqrMagnitude < (8 * 8);
		}


		internal Vector3 PlayerMid
		{
			get {
				var possessed = Game.Instance.PossessedActor;
				return possessed.HalfHeight;
			}
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

