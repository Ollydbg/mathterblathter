using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class WeaponDamagePayload : DamagePayload
	{
		
		public WeaponDamagePayload (AbilityContext ctx, Actor target, int damage) : base(ctx, target, damage)
		{
			float weaponBaseDamage = 0f;
			if(ctx.sourceWeapon != null) {
				weaponBaseDamage = (float)ctx.sourceWeapon.Attributes[ActorAttributes.BaseDamage];
			}

			Damage += weaponBaseDamage;
		}

		public WeaponDamagePayload (AbilityContext ctx, Actor target, float damage) : base(ctx, target, damage)
		{
			float weaponBaseDamage = 0f;
			if(ctx.sourceWeapon != null) {
				weaponBaseDamage = (float)ctx.sourceWeapon.Attributes[ActorAttributes.BaseDamage];
			}

			Damage += weaponBaseDamage;
		}
	}
}

