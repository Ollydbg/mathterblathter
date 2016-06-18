using System;
using Client.Game.Abilities;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts.Debuffs
{
	public class LimitedUseItemDebuff : BuffBase
	{
		public LimitedUseItemDebuff ()
		{
		}

		public override void Start ()
		{
			this.SourceWeapon.OnAttackStart += OnWeaponFire;
		}

		void OnWeaponFire (AbilityContext context)
		{
			var targetCharges = this.SourceWeapon.Attributes[ActorAttributes.Charges] -1; 
			this.SourceWeapon.Attributes[ActorAttributes.Charges] = targetCharges;

			if(targetCharges == 0) {
				SourceWeapon.Owner.WeaponController.RemoveWeapon(SourceWeapon);
			}

			
		}

		public override void Update (float dt)
		{
			
		}

		public override void End ()
		{
		}

	}
}

