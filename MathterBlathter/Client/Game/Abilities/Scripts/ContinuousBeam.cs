using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Actors;
using Client.Game.Enums;

namespace Client.Game.Abilities.Scripts
{
	public class ContinuousBeam : BuffBase
	{
		public ContinuousBeam ()
		{
		}

		ProjectileActor projectile;
		private bool attacking;
		
		public override void Start ()
		{
			SourceWeapon.OnAttackStart += SourceWeapon_OnAttackStart;
			SourceWeapon.OnAttackEnd += SourceWeapon_OnAttackEnd;
		}


		void SourceWeapon_OnAttackEnd ()
		{
			attacking = false;
		}

		void SourceWeapon_OnAttackStart (AbilityContext ctx)
		{
			attacking = true;
			context = ctx;

			if(projectile == null) {
				projectile = FireProjectile(MockActorData.ROCKET_PROJECTILE, Vector3.zero, 0f, Client.Game.Enums.AttachPoint.Arm);
				projectile.OnDestroyed += Projectile_OnDestroyed;
			}
		}

		void Projectile_OnDestroyed (Actor actor)
		{
			projectile = null;
		}

		public override void Update (float dt)
		{
			if(attacking && projectile != null) {
				projectile.transform.position = BeamEndPosition(context);
			}
		}


		Vector3 BeamEndPosition(AbilityContext ctx) {
			RaycastHit hit;

			var startLocation = PointOnActor(Client.Game.Enums.AttachPoint.Muzzle, context.source);
			int layerMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString()});

			if(Physics.Raycast(startLocation, ctx.targetDirection, out hit, 100f, layerMask)) {
				return hit.point;
			} 


			return ctx.source.transform.position + ctx.targetDirection * 100f;
		}

		public override void End ()
		{
			
		}


	}
}

