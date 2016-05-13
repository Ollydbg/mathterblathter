﻿using System;

namespace Client.Game.Abilities
{
	public abstract class BuffBase : AbilityBase
	{
		public BuffBase ()
		{
		}

		public virtual void Stack(AbilityContext ctx) {

		}

		public virtual void UnStack() {

		}

		public override bool isComplete ()
		{
			return false || aborted;
		}

		private bool aborted;
		public void Abort() {
			aborted = true;
		}
	}
}
