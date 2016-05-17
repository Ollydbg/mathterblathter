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
			var aim = new Client.Game.AI.Actions.AimScanForPlayer();
			var waitThenFire = new Client.Game.AI.Actions.WaitThenFire ();

			aim.Next = waitThenFire;
			waitThenFire.Next = aim;
			Brain.CurrentAction = aim;
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

