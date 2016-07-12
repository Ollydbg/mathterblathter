using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Utils;

namespace Client.Game.AI.Actions
{
	using Random = UnityEngine.Random;


	public class Idle : AIAction
	{
		public Idle ()
		{
		}

		float accum = 0f;
		float frequency = .5f;
		float range = 1f;

		Vector2 StartPosition;
		Vector2 GoalPosition;

		public override void Start (Actor selfActor)
		{
			StartPosition = selfActor.transform.position;

			CreateGoal();

		}

		void CreateGoal ()
		{
			accum = 0f;
			GoalPosition = StartPosition + new Vector2(Random.Range(-range, range), Random.Range(-range, range));
		}

		private const float EPSILON = .01f;

		public override AIResult Update (float dt, Character actor)
		{
			accum += dt;

			if(accum >= frequency)
				CreateGoal();

			

			var dir = GoalPosition - VectorUtils.Vector2(actor.transform.position);

			if(dir.sqrMagnitude <= EPSILON) {
				CreateGoal();
				return Update(dt, actor);
			}

			actor.Controller.MoveDirection(dir.normalized);

			return AIResult.Running;

		}

	}
}

