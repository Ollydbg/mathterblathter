using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class HealPayload : Payload
	{

		public float HealAmount;
		public Actor Target;

		public HealPayload (AbilityContext ctx, int amt) : base(ctx)
		{
			this.Target = ctx.source;
			this.HealAmount = (float)amt;

		}

		#region implemented abstract members of Payload

		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Target))
				return;


			int total = (int)HealAmount;

			int newHealth = Target.Attributes [ActorAttributes.Health] + total;

			Target.Attributes [ActorAttributes.Health] = newHealth;


		}

		#endregion
	}
}

