using System;
using Client.Utils;
using Client.Game.Actors;

namespace Client.Game.AI.Actions
{
	public class FireAimingContinuous : AIAction
	{
		public FireAimingContinuous ()
		{
		}



		public override AIResult Update (float dt, Character actor)
		{
			actor.WeaponController.Attack();
			return AIResult.Running;
		}

	}

	public class FireAimingOnce : AIAction
	{
		public FireAimingOnce ()
		{
		}

		public override AIResult Update (float dt, Character actor)
		{
			actor.WeaponController.Attack();
			return AIResult.Success;
		}

	}

	public class FireAimingWhileAimedAtPlayer : AIAction
	{
		public FireAimingWhileAimedAtPlayer ()
		{
		}

		public override AIResult Update (float dt, Character actor)
		{
			actor.WeaponController.Attack();

			if(IsAimedAtPlayer(actor))
				return AIResult.Running;
			
			return AIResult.Success;
		}

	}
}

