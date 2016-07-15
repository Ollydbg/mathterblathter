using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Utils;
using Client.Game.Attributes;

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
		float range = 0f;

		Vector2 StartPosition;
		Vector2 GoalPosition;

		public override void Start (Actor selfActor)
		{
			StartPosition = selfActor.transform.position;
			range = selfActor.Attributes[ActorAttributes.AIIdleRange];

			CreateGoal(selfActor);
		}

		bool Flying (Actor actor)
		{
			return actor.Attributes[ActorAttributes.GravityScalar] == 0;
		}

		void CreateGoal (Actor actor)
		{
			accum = 0f;
			float yComp = 0f;
			if(Flying(actor)) {
				yComp = Random.Range(-range, range);
			}
			
			GoalPosition = StartPosition + new Vector2(Random.Range(-range, range), yComp);
		}

		private const float EPSILON = .01f;

		public override AIResult Update (float dt, Character actor)
		{
			accum += dt;

			if(accum >= frequency)
				CreateGoal(actor);


			var dir = GoalPosition - VectorUtils.Vector2(actor.transform.position);

			if(dir.sqrMagnitude <= EPSILON) {
				CreateGoal(actor);
				return Update(dt, actor);
			}

			actor.Controller.MoveDirection(dir.normalized, true);

			return AIResult.Running;

		}

	}
}

