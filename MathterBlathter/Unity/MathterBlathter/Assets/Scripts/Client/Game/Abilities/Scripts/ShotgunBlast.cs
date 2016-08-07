using System;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using Client.Game.Enums;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class ShotgunBlast : AbilityBase
	{
		public ShotgunBlast ()
		{
		}

		private List<ProjectileActor> projectiles = new List<ProjectileActor>();

		public override void Start ()
		{
			var projectileData = CharacterDataTable.FromId(context.data.spawnableDataId);

			ApplyEnergyCost(context.source);
			CameraShake();
			int projectileCount = this.Attributes[AbilityAttributes.ProjectileCount];
			var totalSpread = this.Attributes[AbilityAttributes.ProjectileSpread];
			float spreadPer = totalSpread / projectileCount;
			for( int i = 0; i<projectileCount; i++ ) {

				int pseudoIndex = -1* (int)Mathf.Floor(projectileCount*.5f) + i;

				var spreadDegrees = pseudoIndex * spreadPer;

				var spreadDirection = Quaternion.AngleAxis(spreadDegrees, Vector3.back) * this.context.targetDirection;
				
				var projectile = this.FireProjectile (projectileData, spreadDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], AttachPoint.Muzzle);

				projectiles.Add(projectile);

				PlayTimeline(context.data.Timelines[0], context.sourceWeapon);

				projectile.OnHit = (actor) => {
					SkipTime();
					new WeaponDamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
					context.source.Game.ActorManager.RemoveActor(projectile);
					this.KnockBack((Character)actor, (actor.transform.position - projectile.transform.position).normalized);
				};
			}
		}


		public override void Update (float dt)
		{
			foreach( var proj in projectiles.ToArray() ) {
				float spd = proj.Movement.Speed + this.Attributes[AbilityAttributes.ProjectileAccel] * dt;
				if(spd >=0) {
					proj.Movement.Speed = spd;
				} else {
					proj.Game.ActorManager.RemoveActor(proj);
					projectiles.Remove(proj);
				}

			}

		}


		public override void End ()
		{
		}

	}
}

