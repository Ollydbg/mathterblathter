using System;

namespace Client.Game.Abilities
{
	public abstract class BuffBase : AbilityBase
	{
		public BuffBase ()
		{
		}


		public override bool isComplete ()
		{
			return false;
		}
	}
}

