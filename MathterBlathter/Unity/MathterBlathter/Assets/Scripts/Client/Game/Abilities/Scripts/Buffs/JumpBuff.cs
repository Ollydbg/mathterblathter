﻿using System;
using Client.Game.Attributes;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class JumpBuff : ItemBuff
	{
		public JumpBuff ()
		{
		}


		#region implemented abstract members of ItemBuff
		public override void ApplyDirection (int dir)
		{
			context.targetActor.Attributes[ActorAttributes.MaxJumpPower] += dir * Attributes[ActorAttributes.MaxJumpPower];
		}
		#endregion
	}
}

