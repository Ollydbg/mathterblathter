using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class KillRewardPayload : Payload
	{
		Actor Killer;
		Actor Killed;
		public KillRewardPayload (AbilityContext ctx, Actor killed, Actor killedBy) : base(ctx)
		{
			this.Killer = killedBy;
			this.Killed = killed;
		}

		public override void Apply() {

			if(AbilityManager.NotifyPayloadReceiver(this, Killer)){
				return;
			}

			this.Killer.Attributes[ActorAttributes.BloodBalance] += this.Killed.Attributes[ActorAttributes.BloodBounty];

		}
	}
}

