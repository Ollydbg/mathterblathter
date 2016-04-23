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

			if (AbilityManager.NotifyPayloadReceiver (this, Context.target))
				return;
		
			new KillRewardPayload(Context, Target, Context.source).Apply();

			Target.Game.AbilityManager.RemoveActor(Target);
			Target.Game.ActorManager.RemoveActor (Target);
		}


	}

}

