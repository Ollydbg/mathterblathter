using System;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using Client.Game.Enums;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class RailGunAttack : AbilityBase
	{
		public RailGunAttack ()
		{
		}

		private ProjectileActor currentProjectile;
		private Vector3 SampledPosition;
		bool aborted;

		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var projectileData = MockActorData.FromId(context.data.spawnableDataId);

			currentProjectile = FireProjectile (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], AttachPoint.Muzzle);
			Sample(currentProjectile);
			var projectilePos = currentProjectile.transform.position;


			ApplyEnergyCost(context.source);
			PlayTimeline(context.data.Timelines[0], context.sourceWeapon);

		}

		Vector3 Sample (ProjectileActor currentProjectile)
		{
			if(currentProjectile.GameObject != null) {
				SampledPosition = currentProjectile.transform.position;
			}
			return SampledPosition;
		}

		public override void Update (float dt)
		{
			if(currentProjectile.GameObject != null) {

				Ray ray = new Ray(SampledPosition, context.targetDirection);

				var hits = Physics.RaycastAll(ray, (Sample(currentProjectile) - ray.origin).magnitude );
				foreach( var hit in hits ) {
					Actor hitActor;
					var result = currentProjectile.TestTrigger(hit.collider, out hitActor);
					if(result == TriggerTestResult.Ok) {
						new WeaponDamagePayload (context, hitActor, Attributes[AbilityAttributes.Damage]).Apply();

						PlayTimeline(context.data.Timelines[1], hitActor);

					} else if (result == TriggerTestResult.Geometry) {
						aborted = true;
					}
				}
			}

		}

		public override bool isComplete ()
		{
			return currentProjectile == null || currentProjectile.GameObject == null || aborted;
		}
		public override void End ()
		{
			
		}
		#endregion
	}
}

