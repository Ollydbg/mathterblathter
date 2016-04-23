using System;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using Client.Game.Enums;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts
{
	public class ShotgunBlast : BuffBase
	{
		public ShotgunBlast ()
		{
		}


		public override void Start ()
		{
			var projectileData = MockActorData.FromId(context.data.spawnableDataId);

			int projectileCount = this.Attributes[AbilityAttributes.ProjectileCount];
			var totalSpread = this.Attributes[AbilityAttributes.ProjectileSpread];
			float spreadPer = totalSpread / projectileCount;
			for( int i = 0; i<projectileCount; i++ ) {


				int pseudoIndex = -1* (int)Mathf.Floor(projectileCount*.5f) + i;

				var spreadDegrees = pseudoIndex * spreadPer;

				var spreadDirection = Quaternion.AngleAxis(spreadDegrees, Vector3.back) * this.context.direction;
				
				var projectile = FireProjectile (projectileData, spreadDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

				projectile.OnHit = (actor) => {
					new DamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
					context.source.Game.ActorManager.RemoveActor(projectile);
				};
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

