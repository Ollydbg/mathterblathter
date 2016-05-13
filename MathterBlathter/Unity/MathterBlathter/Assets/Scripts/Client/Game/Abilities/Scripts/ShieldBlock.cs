﻿using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.Data;

namespace Client.Game.Abilities.Scripts
{
	public class ShieldBlock : BuffBase
	{
		public ShieldBlock ()
		{
		}

		#region implemented abstract members of AbilityBase

		ProjectileActor projectile;

		bool attacking;

		public override void Start ()
		{
			
			SourceWeapon.OnAttackStart += SourceWeapon_OnAttackStart;
			SourceWeapon.OnAttackEnd += SourceWeapon_OnAttackEnd;
		}

		void SourceWeapon_OnAttackEnd ()
		{
			attacking = false;
		}

		void SourceWeapon_OnAttackStart (AbilityContext ctx)
		{
			context = ctx;
			attacking = true;
			if(projectile == null) {
				projectile = FireProjectile(MockActorData.FromId(context.data.spawnableDataId), context.targetDirection, .1f, AttachPoint.Muzzle);


			}
		}

		public override void Update (float dt)
		{
			if(attacking && projectile != null) {
				
			}
		}

		public override void End ()
		{
		}

		#endregion
	}
}
