using System;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class EnergySap : AbilityBase
	{
		public EnergySap ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var target = context.source.Game.PossessedActor;

			target.Attributes[ActorAttributes.Energy] -= this.Attributes[AbilityAttributes.Damage];
			PlayTimeline(context.data.Timelines[0], target);
			PlayTimeline(context.data.Timelines[0], context.source);
		}

		public override void Update (float dt)
		{
			
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

