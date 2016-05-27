using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Actors;
using Client.Game.Enums;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class ContinuousBeam : BuffBase
	{
		public ContinuousBeam ()
		{
		}


		private LineRenderer lineRenderer;
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
			projectile.Game.ActorManager.RemoveActor(projectile);
			projectile = null;
		}

		void SourceWeapon_OnAttackStart (AbilityContext ctx)
		{
			attacking = true;
			context = ctx;

			if(projectile == null) {
				projectile = FireProjectile(MockActorData.FromId(context.data.spawnableDataId), Vector3.zero, 0f, Client.Game.Enums.AttachPoint.WeaponSlot);
				this.lineRenderer = projectile.GameObject.GetComponent<LineRenderer>();
				projectile.OnDestroyed += Projectile_OnDestroyed;

			}
		}

		void Projectile_OnDestroyed (Actor actor)
		{
			projectile = null;
		}


		float accum = 0f;
		float costAccum = 0f;
		float tickRate = .1f;
		
		public override void Update (float dt)
		{
			
			if(attacking && projectile != null) {
				accum += dt;
				Actor hitActor;
				var endPosition = BeamEndPosition(context, out hitActor);
				projectile.transform.position = endPosition;

				var startPosition = PointOnActor(Client.Game.Enums.AttachPoint.Muzzle, context.source);
				var midPoint = startPosition + (endPosition - startPosition)/2;

				var wiggle = 60f;
				var wiggleAmt = (endPosition - startPosition).magnitude / 20f;
				var wiggleVector = wiggleAmt * new Vector3((float)Math.Cos(accum * wiggle), (float)Math.Sin(accum * wiggle));
				midPoint += wiggleVector;

				lineRenderer.SetVertexCount(3);
				lineRenderer.SetPositions(new Vector3[]{startPosition, midPoint, endPosition});


				costAccum += dt;
				if(costAccum > tickRate) {
					costAccum -= tickRate;
					new AnxietyCostPayload(context, context.source, context.sourceWeapon.Attributes[ActorAttributes.WeaponAnxietyCost] * tickRate)
						.Apply();
						
				}
				
				if(hitActor != null) {
					new DamagePayload(context, hitActor, this.Attributes[AbilityAttributes.Damage] * dt).Apply();
				}


			}
		}


		Vector3 BeamEndPosition(AbilityContext ctx, out Actor hitActor) {
			RaycastHit hit;

			var startLocation = PointOnActor(Client.Game.Enums.AttachPoint.Muzzle, context.source);
			int layerMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Player.ToString()});

			if(Physics.Raycast(startLocation, ctx.targetDirection, out hit, 100f, layerMask)) {
				ActorUtils.TryHitToActor(hit, out hitActor);
				return hit.point;
			} 

			hitActor = null;
			return ctx.source.transform.position + ctx.targetDirection * 100f;
		}

		public override void End ()
		{
			
		}


	}
}

