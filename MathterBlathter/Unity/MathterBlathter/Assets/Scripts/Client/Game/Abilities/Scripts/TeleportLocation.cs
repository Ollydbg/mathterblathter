using System;
using Client.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class TeleportLocation : AbilityBase
	{
		public TeleportLocation ()
		{
		}

		public override void Start ()
		{
			context.targetActor.transform.position = this.context.targetPosition;
		}
		

		public override void Update (float dt)
		{
		}

		public override void End ()
		{
		}

	}
}

