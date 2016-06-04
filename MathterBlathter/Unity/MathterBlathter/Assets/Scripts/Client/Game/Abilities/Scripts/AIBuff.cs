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
			var sequence = new Sequence();
			
			var losAction = new Client.Game.AI.Actions.TestPlayerLOS();
			var seekToAction = new Client.Game.AI.Actions.SeekToPlayer ();
			var fireAtAction = new Client.Game.AI.Actions.FireAtPlayer ();
			sequence.Next = fireAtAction;
			fireAtAction.Next = sequence;
			
			sequence.Actions.Add(losAction);
			sequence.Actions.Add(seekToAction);
			
			Brain.CurrentAction = sequence;
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

