using System;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Abilities.Payloads;
using Client.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class SwapActorPositions : AbilityBase
	{
		public SwapActorPositions ()
		{
		}

		private ProjectileActor currentProjectile;
		private Vector2 SampledPosition;
		bool aborted;

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var projectileData = CharacterDataTable.FromId(context.data.spawnableDataId);

			currentProjectile = FireProjectile (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], AttachPoint.Muzzle);
			Sample(currentProjectile);
			var projectilePos = currentProjectile.transform.position;


			ApplyEnergyCost(context.source);
			PlayTimeline(context.data.Timelines[0], context.sourceWeapon);

		}


		Vector2 Sample (ProjectileActor currentProjectile)
		{
			if(currentProjectile.GameObject != null) {
				SampledPosition = VectorUtils.Vector2(currentProjectile.transform.position);
			}
			return SampledPosition;
		}

		void Swap (Actor source, Actor hitActor)
		{
			var sourcePos = source.transform.position;
			var targetPos = hitActor.transform.position;

			
			source.transform.position = targetPos;
			hitActor.transform.position = sourcePos;
		}

		public override void Update (float dt)
		{
			if(currentProjectile.GameObject != null) {

				var hitInfo = Physics2D.Raycast(SampledPosition, VectorUtils.Vector2(context.targetDirection), (Sample(currentProjectile) - SampledPosition).magnitude );

				if(hitInfo != null) {

					Actor hitActor;
					var result = currentProjectile.TestTrigger(hitInfo.collider, out hitActor);
					if(result == TriggerTestResult.Ok) {
						
						Swap(context.source, hitActor);
						new WeaponDamagePayload(context, hitActor, Attributes[AbilityAttributes.Damage]).Apply();
			
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

