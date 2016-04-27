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


		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var projectileData = MockActorData.FromId(context.data.spawnableDataId);

			currentProjectile = FireProjectile (projectileData, context.direction, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

			currentProjectile.OnHit = (actor) => {
				new DamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
			};
		}
		public override void Update (float dt)
		{
			
		}

		public override bool isComplete ()
		{
			return currentProjectile == null;
		}
		public override void End ()
		{
			
		}
		#endregion
	}
}

