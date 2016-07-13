using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.Data;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class ShieldBlock : BuffBase
	{
		public ShieldBlock ()
		{
		}

		#region implemented abstract members of AbilityBase

		ProjectileActor projectile;

		bool attacking;

		public override void Start ()
		{
			
			SourceWeapon.OnAttackStart += SourceWeapon_OnAttackStart;
			SourceWeapon.OnAttackEnd += SourceWeapon_OnAttackEnd;
		}

		void SourceWeapon_OnAttackEnd ()
		{
			attacking = false;
			if(projectile != null) {
				projectile.Destroy();
				projectile = null;
			}
		}

		void SourceWeapon_OnAttackStart (AbilityContext ctx)
		{
			context = ctx;
			attacking = true;
			if(projectile == null) {
				projectile = this.FireProjectile(CharacterDataTable.FromId(context.data.spawnableDataId), context.targetDirection, .1f, AttachPoint.Muzzle, Layers.Player);
				projectile.transform.rotation = Quaternion.identity;

				projectile.GameObjectRef.OnTriggerActorEnter += (Actor actor) => {
					if(actor.ActorType == ActorType.Projectile) {
						actor.Destroy();
						ApplyEnergyCost(context.source);
						CameraShake();
						PlayTimeline(context.data.Timelines[0], actor.transform.position);
					}
				};
			}
		}

		public override void Update (float dt)
		{
			if(attacking && projectile != null) {

				var aimVector = context.source.WeaponController.AimDirection;
				projectile.transform.position = context.source.transform.position + 3* aimVector;
				var angle = Vector3.Angle(Vector3.right, aimVector);
				projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
				//projectile.transform.RotateAround(context.source.HalfHeight, Vector3.forward, 10f);
				
			}
		}

		public override void End ()
		{
		}

		#endregion
	}
}

