using System;
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

		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var projectileData = CharacterDataTable.FromId(context.data.spawnableDataId);

			
			currentProjectile = this.FireProjectile (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

			currentProjectile.OnGeometryHit = OnHit;
			currentProjectile.OnHit = (actor) => OnHit();
			PlayTimeline(context.data.Timelines[0], currentProjectile);

			ApplyEnergyCost(context.source);
		}

		private void OnHit() {

			PlayTimeline(context.data.Timelines[1], currentProjectile.transform.position);
			currentProjectile.Game.ActorManager.RemoveActor(currentProjectile);
			var inRange = AbilityUtils.OverlapCircle(currentProjectile.transform.position, context, this.Attributes[AbilityAttributes.SplashRadius], new FilterList(Filters.Hittable));
			foreach( Actor tgt in inRange) {
				new WeaponDamagePayload (context, tgt, Attributes[AbilityAttributes.Damage]).Apply();
			}
		}

		public override void Update (float dt)
		{
			if(currentProjectile != null) {
				currentProjectile.Movement.Speed += this.Attributes[AbilityAttributes.ProjectileAccel] * dt;
			}

		}


		public override void End ()
		{

		}
		#endregion
	}
}

