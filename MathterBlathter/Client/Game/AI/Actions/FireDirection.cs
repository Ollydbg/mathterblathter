using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Abilities;
using Client.Game.Actors;

namespace Client.Game.AI.Actions
{
	public class FireDirection : AIAction
	{
		public FireDirection (Vector3 firingDirection)
		{
			this.direction = firingDirection;
		}


		float accumulator = 0f;

		Vector3 direction;

		float speed = 1f;

		public override AIResult Update (float dt, Actor actor)
		{
			accumulator += dt;

			if(accumulator >= speed) {
				accumulator -= speed;
				actor.WeaponController.Attack(direction);

			}

			return AIResult.Running;
		}

	}
}

