﻿using System;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using Client.Game.Enums;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class RocketProjectileAttack : AbilityBase
	{
		public RocketProjectileAttack ()
		{
		}

		private ProjectileActor currentProjectile;
		String impactPath = "Projectiles/VFX/rocketExplosion_prefab";

		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var projectileData = MockActorData.FromId(context.data.spawnableDataId);

			currentProjectile = FireProjectile (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

			currentProjectile.OnGeometryHit = OnHit;
			currentProjectile.OnHit = (actor) => OnHit();

		}

		private void OnHit() {

			ProjectileImpactEffect(currentProjectile, impactPath);
			currentProjectile.Game.ActorManager.RemoveActor(currentProjectile);
			var inRange = AbilityUtils.CollideSphere(currentProjectile.transform.position, context, this.Attributes[AbilityAttributes.SplashRadius], new FilterList(Filters.Hittable));
			foreach( Actor tgt in inRange) {
				new DamagePayload (context, tgt, Attributes[AbilityAttributes.Damage]).Apply();
			}
		}

		public override void Update (float dt)
		{
			if(currentProjectile != null) {
				currentProjectile.Speed += this.Attributes[AbilityAttributes.ProjectileAccel] * dt;
			}

		}


		public override void End ()
		{

		}
		#endregion
	}
}

