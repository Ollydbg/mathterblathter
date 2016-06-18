using System;
using Client.Utils;

namespace Client.Game.AI.Actions
{
	public class FireFacingDirection : AIAction
	{
		public FireFacingDirection ()
		{
		}



		public override AIResult Update (float dt, Client.Game.Actors.Actor actor)
		{
			var facing = GetFacingVector(actor);
			
			actor.WeaponController.Attack(facing);
		
			return AIResult.Running;

		}

	}
}

