using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;
using System.Collections.Generic;

namespace Client.Game.AI
{
	using Game = Client.Game.Core.Game;

	public abstract class AIAction
	{
		public virtual void Start(Actor selfActor) {}
		public virtual void End(){}

		public abstract AIResult Update(float dt, Actor actor);
		public AIAction Next;

		internal bool inAbilityRange(Vector3 distanceVec, Actor selfActor) {
			
			return distanceVec.sqrMagnitude < (AbilityRange() * AbilityRange());
		}

		internal float AbilityRange() {
			return 15;
		}

		internal Vector3 PlayerMid
		{
			get {
				var possessed = Game.Instance.PossessedActor;
				return possessed.HalfHeight;
			}
		}


		internal void FaceTarget(Actor selfActor, Vector3 target) {

			float angle = target.x < selfActor.transform.position.x ? -180 : 0;

			selfActor.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}
	}



	public enum AIResult {
		Success,
		Failure,
		Running
	}

	public class Sequence : AIAction {
		public List<AIAction> Actions = new List<AIAction>();

		public override AIResult Update (float dt, Actor actor)
		{
			var allSuccess = false;


			foreach( var action in Actions) {
				var result = action.Update(dt, actor);
				if(result != AIResult.Success) {
					return AIResult.Failure;
				}

				allSuccess &= result == AIResult.Success;

			}
			return allSuccess ? AIResult.Success : AIResult.Failure;
		}
	}

	public class EmptyAction : AIAction {
		
		public override AIResult Update (float dt, Actor actor)
		{
			return AIResult.Running;
		}



	}
}

