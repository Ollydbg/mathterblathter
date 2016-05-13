using System;
using Client.Game.AI;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class SniperAIBuff : BuffBase
	{
		public Brain Brain;

		public SniperAIBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			Brain = new Brain(context.source);
			var seekToAction = new Client.Game.AI.Actions.SeekToPlayerLOS ();
			var fireAtAction = new Client.Game.AI.Actions.WaitThenFire ();
			seekToAction.Next = fireAtAction;
			fireAtAction.Next = seekToAction;
			Brain.CurrentAction = seekToAction;
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

