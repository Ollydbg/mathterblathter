using System;
using Client.Game.Actors;

namespace Client.Game.AI.Actions
{
	public class AimAtPlayerAction : AIAction
	{
		public AimAtPlayerAction ()
		{
		}

		#region implemented abstract members of AIAction

		public override AIResult Update (float dt, Character actor)
		{
			var player = actor.Game.PossessedActor;
			var aimDir = player.transform.position - actor.transform.position;

			actor.WeaponController.AimDirection = aimDir.normalized;

			return AIResult.Success;
		}

		#endregion
	}
}

