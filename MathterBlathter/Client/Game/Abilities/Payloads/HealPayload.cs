using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class HealPayload : Payload
	{

		public float HealAmount;
		public Actor Target;

		public HealPayload (AbilityContext ctx, Actor target, int amt) : base(ctx)
		{
			this.Target = target;
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
			newHealth = newHealth > Target.Attributes[ActorAttributes.MaxHealth] ? Target.Attributes[ActorAttributes.MaxHealth] : newHealth;
			Target.Attributes [ActorAttributes.Health] = newHealth;

		}

		#endregion
	}
}

