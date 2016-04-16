using System;
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


		public override AIResult Update (float dt, Actor actor)
		{
			var target = PlayerMid;
			var distanceVec = target - actor.transform.position;


			FaceTarget(actor, target);

			if (!inAbilityRange (distanceVec, actor)) {
				accumulator = 0;
				return AIResult.Failure;
			} else {

				TryActivateAbility (dt, actor);
				return AIResult.Incomplete;
			}


		}


		float accumulator = 0.0f;
		float COOLDOWN = 1.0f;
		void TryActivateAbility (float dt, Actor selfActor)
		{
			accumulator += dt;
			if (accumulator > COOLDOWN) {
				accumulator = 0;
				var context = new AbilityContext ((Character)selfActor, (PlayerMid - selfActor.transform.position).normalized, MockAbilityData.ENEMY_PROJECTILE_TEST);
				selfActor.Game.AbilityManager.ActivateAbility (context);
			}
		}
	}
}

