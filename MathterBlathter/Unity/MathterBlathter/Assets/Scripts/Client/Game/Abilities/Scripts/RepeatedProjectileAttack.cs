﻿using System;
using Client.Game.Data;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class RepeatedProjectileAttack : AbilityBase
	{
		public RepeatedProjectileAttack ()
		{
		}

		#region implemented abstract members of AbilityBase

		float accumulator = 0f;
		int repeatCount = 0;

		float repeatDelay;
		int maxRepeats;

		public override void Start ()
		{
			maxRepeats = this.Attributes[AbilityAttributes.RepeatAmount];
			repeatDelay = this.Attributes[AbilityAttributes.RepeatDelay];

			accumulator = 0f;
			repeatCount = 0;

			ApplyEnergyCost(context.source);

			Fire();
		}

		public void Fire() {

			CameraShake();

			repeatCount ++;
			var projectileData = CharacterDataTable.FromId(context.data.spawnableDataId);

			var projectile = this.FireProjectile (projectileData, context.targetDirection, this.Attributes[AbilityAttributes.ProjectileSpeed], (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);

			PlayTimeline(context.data.Timelines[0], context.source, context.targetDirection);

			projectile.OnHit = (actor) => {
				new WeaponDamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
				context.source.Game.ActorManager.RemoveActor(projectile);

				PlayTimeline(context.data.Timelines[1], actor);
				SkipTime();
				KnockBack(actor as Actors.Character, (actor.transform.position - projectile.transform.position).normalized);

			};
			projectile.OnGeometryHit = () => {
				PlayTimeline(context.data.Timelines[1], projectile.transform.position);
			};

		}



		public override void Update (float dt)
		{


			accumulator += dt;
			if(accumulator > repeatDelay && repeatCount < maxRepeats ) {
				accumulator -= repeatDelay;
				Fire();
			}
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

