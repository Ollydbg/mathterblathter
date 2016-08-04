using System;
using Client.Utils;
using Client.Game.Actors;
using Client.Game.Utils;

namespace Client.Game.AI.Actions
{
	public class FireSpawnDirection : AIAction
	{
		public FireSpawnDirection ()
		{
		}



		public override AIResult Update (float dt, Character actor)
		{
			var facing = actor.SpawnData.Facing;
			
			actor.WeaponController.Attack(facing);
		
			return AIResult.Running;

		}

	}

	public class FireFacingDirection : AIAction
	{
		public FireFacingDirection ()
		{
		}



		public override AIResult Update (float dt, Character actor)
		{
			var facing = ActorUtils.GetTransformFacing(actor);

			actor.WeaponController.Attack(facing);

			return AIResult.Running;

		}

	}
}

