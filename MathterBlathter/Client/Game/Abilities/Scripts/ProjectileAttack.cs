using System;
using UnityEngine;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Enums;

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
			var projectile = FireProjectile (context.data.spawnableResourcePath, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

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

