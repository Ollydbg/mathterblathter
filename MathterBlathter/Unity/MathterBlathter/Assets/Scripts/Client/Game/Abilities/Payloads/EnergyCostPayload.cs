using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class EnergyCostPayload : Payload
	{
		public float Cost;
		public Actor Target;
		public EnergyCostPayload (AbilityContext ctx, Actor target, int amount ) : base(ctx)
		{
			this.Target = target;
			this.Cost = (float)amount;
		}

		#region implemented abstract members of Payload

		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Target))
				return;

			int total = (int)Cost;
			Target.Attributes[ActorAttributes.Energy] -= total;
		}

		#endregion
	}
}

