using System;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class JumpBuff : BuffBase
	{
		public JumpBuff ()
		{
		}

		private float timeLeft = 0f;

		public override void Start ()
		{
			timeLeft = this.Attributes[AbilityAttributes.Duration];
			ApplyDirection(1);
		}

		void ApplyDirection(int dir) {
			context.targetActor.Attributes[ActorAttributes.MaxJumpPower] += (dir)*this.Attributes[ActorAttributes.MaxJumpPower];
		}

		public override void Update (float dt)
		{
			timeLeft -= dt;
		}

		public override bool isComplete ()
		{
			return timeLeft <= 0f;
		}

		public override void End ()
		{
			ApplyDirection(-1);	
		}

	}
}

