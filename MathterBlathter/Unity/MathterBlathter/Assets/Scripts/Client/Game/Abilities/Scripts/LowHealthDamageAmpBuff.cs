using System;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts
{
    public class LowHealthDamageAmpBuff : BuffBase
    {
        public override void End()
        {
        }

        public override void Start()
        {
        }

        public override void Update(float dt)
        {
        }
		
		float getDamageScalar() {
			float current = (float)(context.source.Attributes[ActorAttributes.Health]);
			float max = (float)(context.source.Attributes[ActorAttributes.MaxHealth]);
			
			var bonus = ((max - current) / max);
			
			var scaled = this.Attributes[ActorAttributes.DamageScalar] * bonus + 1f;
			return scaled;
		}
		
		public override bool OnPayloadSend(Payload payload) {
			var damagePayload = payload as DamagePayload;
			if(damagePayload != null) {
				damagePayload.DamageScalar *= getDamageScalar();
			}
			
			return false;
		}
    }
}