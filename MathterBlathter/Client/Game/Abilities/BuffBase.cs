using System;

namespace Client.Game.Abilities
{
	public abstract class BuffBase : AbilityBase
	{
		public BuffBase ()
		{
		}

		public virtual void Stack() {

		}

		public virtual void UnStack() {

		}

		public override bool isComplete ()
		{
			return false;
		}
	}
}

