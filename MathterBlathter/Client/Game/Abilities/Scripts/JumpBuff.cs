using System;
using Client.Game.Attributes;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts
{
	public class JumpBuff : ItemBuff
	{
		public JumpBuff ()
		{
		}


		#region implemented abstract members of ItemBuff
		public override void ApplyDirection (int dir)
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

