using System;
using Client.Utils;
using Client.Game.Actors;

namespace Client.Game.AI.Actions
{
	public class FireAimingDirection : AIAction
	{
		public FireAimingDirection ()
		{
		}



		public override AIResult Update (float dt, Character actor)
		{
			actor.WeaponController.Attack();
			return AIResult.Running;
		}

	}
}

