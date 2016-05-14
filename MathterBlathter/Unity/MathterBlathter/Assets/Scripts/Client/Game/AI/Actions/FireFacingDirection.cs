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
			
			actor.WeaponController.Attack(actor.SpawnData.Facing);
		
			return AIResult.Running;

		}

	}
}

