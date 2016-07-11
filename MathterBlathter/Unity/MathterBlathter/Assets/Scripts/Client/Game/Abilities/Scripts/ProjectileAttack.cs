using System;
using UnityEngine;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Data;
using Client.Game.Abilities.Utils;

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

			var projectileData = CharacterDataTable.FromId(context.data.spawnableDataId);

			var projectile = this.FireProjectile (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

			projectile.OnHit = (actor) => {
				new WeaponDamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
				context.source.Game.ActorManager.RemoveActor(projectile);
			};

			//PlayTimeline(context.data.Timelines[0], context.source);
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

