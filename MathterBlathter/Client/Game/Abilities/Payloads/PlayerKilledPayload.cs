using System;

namespace Client.Game.Abilities.Payloads
{
	public class PlayerKilledPayload : Payload
	{
		public PlayerKilledPayload (AbilityContext ctx) : base (ctx)
		{
			
		}


		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Context.target))
				return;

			//this doesn't actually do anything at the moment
			
		}

	}
}

