using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using UnityEngine;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class AnxietyRegenBuff : BuffBase
	{
		public AnxietyRegenBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			context.source.Game.RoomManager.OnCurrentRoomUnlocked += OnRoomUnlocked;
		}

		private float refreshRate = 1f;

		float accum = 0f;
		float timeUntilBonus = 0f;
		float regenScalar = 1f;
		bool givingBoost = false;

		private void ResetIdleBonus() {
			timeUntilBonus = this.Attributes[AbilityAttributes.CalmdownBoostDelay];
			regenScalar = 1f;
			givingBoost = false;

		}

		void OnRoomUnlocked (Client.Game.Map.Room room)
		{
			context.source.Attributes[ActorAttributes.Anxiety] = 0;
			PlayTimeline(context.data.Timelines[0], context.source);
		}

		private void tickBoost(float dt) {

			if(!givingBoost) {
				timeUntilBonus -= dt;
				if(timeUntilBonus <= 0f) {
					regenScalar = this.Attributes[AbilityAttributes.AnxietyRegenScalar];
					givingBoost = true;
				}
			}
		}

		public override void Update (float dt) {
			accum += dt;

			tickBoost(dt);

			if( accum >= refreshRate) {
				accum -= refreshRate;

				var projected = context.source.Attributes[ActorAttributes.Anxiety] - (int)(regenScalar * context.source.Attributes[ActorAttributes.AnxietyRegen]);

				if(projected < 0) {
					projected = 0;
				}


				context.source.Attributes[ActorAttributes.Anxiety] = projected;

			}

		}

		public override bool OnPayloadReceive (Payload payload)
		{
			if(payload is AnxietyCostPayload) {
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

