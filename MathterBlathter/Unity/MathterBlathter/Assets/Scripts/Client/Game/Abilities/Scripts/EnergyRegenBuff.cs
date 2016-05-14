using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class EnergyRegenBuff : BuffBase
	{
		public EnergyRegenBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
		}

		private float refreshRate = 1f;

		float accum = 0f;
		float timeUntilBonus = 0f;
		float regenScalar = 1f;
		bool givingBoost = false;

		private void ResetIdleBonus() {
			timeUntilBonus = this.Attributes[AbilityAttributes.EnergyRegenBoostDelay];
			regenScalar = 1f;
			givingBoost = false;
		}

		private void tickBoost(float dt) {

			if(!givingBoost) {
				timeUntilBonus -= dt;
				if(timeUntilBonus <= 0f) {
					regenScalar = this.Attributes[AbilityAttributes.EnergyRegenScalar];
					givingBoost = true;
				}
			}
		}

		public override void Update (float dt) {
			accum += dt;

			tickBoost(dt);

			if( accum >= refreshRate) {
				accum -= refreshRate;

				var max = context.source.Attributes[ActorAttributes.MaxEnergy];
				var projected = context.source.Attributes[ActorAttributes.Energy] + (int)(regenScalar * context.source.Attributes[ActorAttributes.EnergyRegen]);

				if(projected > max) {
					projected = max;
				}


				context.source.Attributes[ActorAttributes.Energy] = projected;

			}

		}

		public override bool OnPayloadReceive (Payload payload)
		{
			if(payload is EnergyCostPayload) {
				ResetIdleBonus();
			}

			return base.OnPayloadReceive(payload);
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

