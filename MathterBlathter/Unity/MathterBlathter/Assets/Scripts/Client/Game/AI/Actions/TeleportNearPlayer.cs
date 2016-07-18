using System;
using Client.Game.Actors;

namespace Client.Game.AI.Actions
{
	public class TeleportNearPlayer : AIAction
	{
		public TeleportNearPlayer ()
		{
		}

		#region implemented abstract members of AIAction

		public override AIResult Update (float dt, Character actor)
		{
			
			return AIResult.Success;
		}

		#endregion
	}
}

