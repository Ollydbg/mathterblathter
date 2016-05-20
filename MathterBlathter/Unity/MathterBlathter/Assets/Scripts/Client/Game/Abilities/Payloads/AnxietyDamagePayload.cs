using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class AnxietyDamagePayload : Payload
	{
		public float Damage;
		public Actor Target;

		public AnxietyDamagePayload (AbilityContext ctx, Actor target, int damage) : base(ctx)
		{
			this.Damage = (float)(damage * target.Attributes[ActorAttributes.AnxietyDamageScalar]);
			this.Target = target;
		}

		#region implemented abstract members of Payload

		public override void Apply ()
		{
			
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Target))
				return;

			new DamagePayload(this.Context, Target, (int)Damage).Apply();
		}

		#endregion
	}
}

