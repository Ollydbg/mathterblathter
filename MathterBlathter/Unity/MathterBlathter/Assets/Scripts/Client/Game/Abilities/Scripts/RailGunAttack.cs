using System;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using Client.Game.Enums;
using Client.Game.Actors;
using UnityEngine;
using Client.Utils;
using Client.Game.Abilities.Movement;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class RailGunAttack : AbilityBase
	{
		public RailGunAttack ()
		{
		}

		private ProjectileActor currentProjectile;
		private Vector2 lastPosition;
		bool aborted;

		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var projectileData = CharacterDataTable.FromId(context.data.spawnableDataId);

			currentProjectile = this.FireProjectile<LinearCastForward> (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], AttachPoint.Muzzle);

			PlayTimeline(context.data.Timelines[2], currentProjectile);

			currentProjectile.OnHit += OnHit;
			currentProjectile.OnGeometryHit += OnGeoHit;
			var projectilePos = currentProjectile.transform.position;

			CameraShake();

			ApplyEnergyCost(context.source);
			PlayTimeline(context.data.Timelines[0], context.sourceWeapon);

		}

		public virtual void OnHit (Actor hitActor)
		{
			new WeaponDamagePayload (context, hitActor, Attributes[AbilityAttributes.Damage]).Apply();
			SkipTime();
			KnockBack(hitActor as Character);
			PlayTimeline(context.data.Timelines[1], hitActor);
		}

		void OnGeoHit ()
		{
			currentProjectile.Destroy();
			aborted = true;
		}
	
		public override void Update (float dt)
		{
			

		}

		public override bool IsComplete ()
		{
			return currentProjectile == null || currentProjectile.GameObject == null || aborted;
		}
		public override void End ()
		{
			
		}
		#endregion
	}
}

