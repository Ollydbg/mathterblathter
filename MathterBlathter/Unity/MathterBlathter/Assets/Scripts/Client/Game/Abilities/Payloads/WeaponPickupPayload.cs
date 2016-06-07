using System;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Abilities.Payloads
{
    public class WeaponPickupPayload : Payload
    {
		public WeaponPickupPayload(AbilityContext ctx) : base(ctx) {
			
		}
		
        public override void Apply()
        {
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			Context.source.WeaponController.AddWeapon(Context.sourceWeapon);
        }
    }
}