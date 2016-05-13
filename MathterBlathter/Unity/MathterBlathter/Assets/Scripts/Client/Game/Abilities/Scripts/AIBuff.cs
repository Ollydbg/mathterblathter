using System;
using Client.Game.AI;

namespace Client.Game.Abilities.Scripts
{
	public class AIBuff : BuffBase
	{

		public Brain Brain;

		public AIBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			Brain = new Brain(context.source);
			var seekToAction = new Client.Game.AI.Actions.SeekToPlayer ();
			var fireAtAction = new Client.Game.AI.Actions.FireAtPlayer ();
			fireAtAction.Next = seekToAction;
			seekToAction.Next = fireAtAction;

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

