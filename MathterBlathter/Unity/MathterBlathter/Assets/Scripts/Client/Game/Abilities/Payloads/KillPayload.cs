using System;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Abilities.Payloads
{
	public class KillPayload : Payload
	{
		Actor Target;

		public KillPayload(AbilityContext ctx, Actor target) : base(ctx) {
			Target = target;
		}


		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Target))
				return;
		
			new KillRewardPayload(Context, Target, Context.source).Apply();

			new DropPayload(Context, Target).Apply();
			
			Target.Destroy();
		}


	}

}

