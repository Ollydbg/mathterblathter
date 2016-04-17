using System;
using UnityEngine;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Data;

namespace Client.Game.Abilities.Scripts
{
	public class ProjectileAttack : AbilityBase
	{
		public ProjectileAttack ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{

			var projectileData = MockActorData.FromId(context.data.spawnableDataId);

			var projectile = FireProjectile (projectileData, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

			projectile.OnHit = (actor) => {
				new DamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
				context.source.Game.ActorManager.RemoveActor(projectile);
			};
		}

		public override void Update (float dt)
		{
		}

		public override void End ()
		{
		}

		#endregion
	}
}

