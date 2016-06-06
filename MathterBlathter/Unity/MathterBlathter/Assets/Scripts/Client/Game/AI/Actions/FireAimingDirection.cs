using System;
using Client.Utils;

namespace Client.Game.AI.Actions
{
	public class FireAimingDirection : AIAction
	{
		public FireAimingDirection ()
		{
		}



		public override AIResult Update (float dt, Client.Game.Actors.Actor actor)
		{
			actor.WeaponController.Attack();
			return AIResult.Running;
		}

	}
}

