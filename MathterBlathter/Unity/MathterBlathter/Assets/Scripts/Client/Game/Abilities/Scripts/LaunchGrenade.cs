using System;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using Client.Game.Enums;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Abilities.Movement;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class LaunchGrenade : AbilityBase
	{
		
		public LaunchGrenade ()
		{
        }

        public override void Start()
        {
			var projectileData = CharacterDataTable.FromId(context.data.spawnableDataId);
			
			ApplyEnergyCost(context.source);
			
			int projectileCount = this.Attributes[AbilityAttributes.ProjectileCount];
			
			for(int i = 0; i<projectileCount; i++) {
				var projectile = FireProjectile(projectileData, context.targetDirection, 0f, (AttachPoint)this.Attributes[AbilityAttributes.FiresFromJoint]);
				projectile.Movement = new RigidBodyAddForce(projectile, context.targetDirection, this.SourceWeapon.Attributes[ActorAttributes.ProjectileSpeed]);

				PlayTimeline(this.context.data.Timelines[0], projectile);
				
				projectile.OnDestroyed += (Actor actor) => {
					PlayTimeline(this.context.data.Timelines[1], projectile.transform.position);

					CameraShake();
					SkipTime();
					var inRange = AbilityUtils.OverlapCircle(projectile.transform.position, context, this.Attributes[AbilityAttributes.SplashRadius], new FilterList(Filters.Hittable));
					foreach( Actor tgt in inRange) {
						new WeaponDamagePayload (context, tgt, Attributes[AbilityAttributes.Damage]).Apply();
					}
				};
			}
		}

        public override void End()
        {}

        public override void Update(float dt)
        {
			
        }
    }
}