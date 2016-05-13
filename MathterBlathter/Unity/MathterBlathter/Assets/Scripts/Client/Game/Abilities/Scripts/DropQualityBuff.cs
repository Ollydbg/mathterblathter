using System;
using System.Collections.Generic;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class DropQualityBuff : ItemBuff
	{
		public DropQualityBuff ()
		{
		}

		#region implemented abstract members of ItemBuff

		public override void ApplyDirection (int dir)
		{
			context.targetActor.Attributes[ActorAttributes.DropQuality] += (dir)*this.context.source.Attributes[ActorAttributes.DropQuality];
			context.targetActor.Attributes[ActorAttributes.DropRate] += (dir)*this.context.source.Attributes[ActorAttributes.DropRate];

		}

		#endregion


	}
}

