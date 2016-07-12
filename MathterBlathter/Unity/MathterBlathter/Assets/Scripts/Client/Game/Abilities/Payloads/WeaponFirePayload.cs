using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.Abilities.Payloads
{
	public class WeaponFirePayload : Payload
	{
		WeaponActor Weapon;

		public WeaponFirePayload (AbilityContext ctx, WeaponActor weapon) : base (ctx)
		{
			this.Weapon = weapon;
		}


		public override void Apply ()
		{
			if(AbilityManager.NotifyPayloadSender(this, Context.source)) {
				return;
			}

			AbilityManager.ActivateAbility(Context);

			Weapon.Attributes[ActorAttributes.LastFiredTime] = Time.realtimeSinceStartup;
			Weapon.AttackStart(Context);
		}

	}
}

