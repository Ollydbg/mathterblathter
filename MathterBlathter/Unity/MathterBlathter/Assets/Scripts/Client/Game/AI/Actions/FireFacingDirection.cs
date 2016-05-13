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

			var rotation = VectorUtils.GetFacingVector(actor.GameObject);

			actor.WeaponController.Attack(rotation.normalized);
		
			return AIResult.Running;

		}

	}
}

