using System;
using Client.Utils;
using Client.Game.Actors;

namespace Client.Game.AI.Actions
{
	public class FireFacingDirection : AIAction
	{
		public FireFacingDirection ()
		{
		}



		public override AIResult Update (float dt, Character actor)
		{
			var facing = GetFacingVector(actor);
			
			actor.WeaponController.Attack(facing);
		
			return AIResult.Running;

		}

	}
}

