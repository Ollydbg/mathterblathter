using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class AnxietyCostPayload : Payload
	{
		public float Cost;
		public Actor Target;
		public AnxietyCostPayload (AbilityContext ctx, Actor target, int amount ) : base(ctx)
		{
			this.Target = target;
			this.Cost = (float)amount;
		}
		
		public AnxietyCostPayload (AbilityContext ctx, Actor target, float amount) : base(ctx)
		{
			this.Target = target;
			this.Cost = amount;
		}

		#region implemented abstract members of Payload

		public override void Apply ()
		{
			if(Target.Attributes[ActorAttributes.UsesAnxiety]) {
				
				if (AbilityManager.NotifyPayloadReceiver (this, Target))
					return;

				int addition = (int)Cost;

				var max = Target.Attributes[ActorAttributes.MaxAnxiety];
				var newTotal = Target.Attributes[ActorAttributes.Anxiety] + addition;

				if(newTotal > max) {
					var overage = newTotal - max;
					new AnxietyDamagePayload(Context, Target, overage).Apply();
					newTotal = max;
				}

				Target.Attributes[ActorAttributes.Anxiety] = newTotal;

			}
		}

		#endregion
	}
}

