using System;
using Client.Game.Attributes;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts
{
	public abstract class ItemBuff : BuffBase
	{
		public float TimeLeft = 0f;
		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			TimeLeft = this.Attributes[AbilityAttributes.Duration];

			ApplyDirection(1);

		}

		public abstract void ApplyDirection(int dir);
		


		public override void Update (float dt)
		{
			TimeLeft -= dt;
		}

		public override bool IsComplete() {
			return TimeLeft <= 0f;
		}

		public override void Stack (AbilityContext ctx)
		{
			context = ctx;
			ApplyDirection(+1);
		}

		public override void UnStack ()
		{
			ApplyDirection(-1);
		}

		public override void End ()
		{
			ApplyDirection(-1);
		}
		#endregion
	}
}