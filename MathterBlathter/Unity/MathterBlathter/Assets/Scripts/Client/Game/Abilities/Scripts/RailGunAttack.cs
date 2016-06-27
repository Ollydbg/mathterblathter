using System;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using Client.Game.Enums;
using Client.Game.Actors;
using UnityEngine;
using Client.Utils;

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

			currentProjectile = FireProjectile (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], AttachPoint.Muzzle);
			Sample(currentProjectile);
			var projectilePos = currentProjectile.transform.position;

			CameraShake();

			ApplyEnergyCost(context.source);
			PlayTimeline(context.data.Timelines[0], context.sourceWeapon);

		}

		Vector2 Sample (ProjectileActor currentProjectile)
		{
			if(currentProjectile.GameObject != null) {
				lastPosition = VectorUtils.Vector2(currentProjectile.transform.position);
			}
			return lastPosition;
		}

		public override void Update (float dt)
		{
			if(currentProjectile.GameObject != null) {
				var lastFrame = lastPosition;
				var currentFrame = Sample(currentProjectile);

				var hits = Physics2D.LinecastAll(lastFrame, currentFrame);
				foreach( var hit in hits ) {
					Actor hitActor;
					var result = currentProjectile.TestTrigger(hit.collider, out hitActor);
					if(result == TriggerTestResult.Ok) {
						new WeaponDamagePayload (context, hitActor, Attributes[AbilityAttributes.Damage]).Apply();
						SkipTime();
						PlayTimeline(context.data.Timelines[1], hitActor);

					} else if (result == TriggerTestResult.Geometry) {
						aborted = true;
					}
				}
			}

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

