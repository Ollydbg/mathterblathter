using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.Abilities.Payloads
{
	public class KnockbackPayload : Payload
	{
		public Character Target;
        Vector3 Direction;
        public float SourceAmt;
		public float WeapontAmt;
		public float Scalar = 1f;
        public KnockbackPayload (AbilityContext ctx, Character target, Vector3 direction) : base(ctx)
		{
			
			this.Target = target;
			
			this.Direction = direction;
			
			this.SourceAmt = ctx.source.Attributes[ActorAttributes.KnockbackForce];
			this.WeapontAmt = ctx.sourceWeapon.Attributes[ActorAttributes.KnockbackForce];
			
		}

		#region implemented abstract members of Payload

		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Target))
				return;
			
			var targetAmt = Scalar * (SourceAmt + WeapontAmt);
			
			if(targetAmt > 0f) {
				Target.Controller.KnockDirection(Direction, targetAmt);	
			}

		}

		#endregion
	}
}

