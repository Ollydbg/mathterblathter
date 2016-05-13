using System;
using Client.Game.AI;

namespace Client.Game.Abilities.Scripts
{
	public class SentryAIBuff : BuffBase
	{

		public Brain Brain;

		public SentryAIBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			Brain = new Brain(context.source);
			var aimAction = new Client.Game.AI.Actions.AimScanForPlayer();
			var fireAtAction = new Client.Game.AI.Actions.FireAimingDirectionAtPlayer();
			aimAction.Next = fireAtAction;
			fireAtAction.Next = aimAction;

			Brain.CurrentAction = aimAction;
		}

		public override void Update (float dt)
		{
			Brain.Update(dt);

		}

		public override void End ()
		{

		}

		#endregion
	}
}

