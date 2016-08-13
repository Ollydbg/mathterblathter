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
            PlayTimeline(context.data.Timelines[0], context.targetActor.transform.position);
            PlayTimeline(context.data.Timelines[1], context.targetPosition);

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

