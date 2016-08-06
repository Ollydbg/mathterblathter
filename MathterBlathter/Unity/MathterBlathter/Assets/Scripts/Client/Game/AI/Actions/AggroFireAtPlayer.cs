using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Abilities;
using Client.Game.Data;
using Client.Game.Attributes;

namespace Client.Game.AI.Actions
{
	public class AggroFireAtPlayer : AIAction
	{
		public AggroFireAtPlayer ()
		{
		}


		public override AIResult Update (float dt, Character actor)
		{
			var target = PlayerMid;
			var distanceVec = target - actor.transform.position;

			AimAtTarget2D(actor, target);

			if (!inAbilityRange (distanceVec, actor)) {
				return AIResult.Failure;
			} else {
				if(ShouldTryFire(actor)) {

					ActionUtil.TryActivateAbility (PlayerMid, actor);
				}
				return AIResult.Running;
			}

		}


		public bool ShouldTryFire(Actor actor) {
			return UnityEngine.Random.value <= actor.Attributes[ActorAttributes.AIAggro];
		}


	}
}

