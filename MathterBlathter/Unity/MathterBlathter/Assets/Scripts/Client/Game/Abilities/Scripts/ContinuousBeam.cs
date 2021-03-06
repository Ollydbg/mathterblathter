﻿using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Actors;
using Client.Game.Enums;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Utils;
using Client.Utils;
using Client.Game.Abilities.Utils;

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
		private float beamWidth;
		public override void Start ()
		{
			SourceWeapon.OnAttackStart += SourceWeapon_OnAttackStart;
			SourceWeapon.OnAttackEnd += SourceWeapon_OnAttackEnd;

			this.beamWidth = this.SourceWeapon.Attributes[ActorAttributes.ProjectileBeamWidth];
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
				projectile = this.FireProjectile(CharacterDataTable.FromId(context.data.spawnableDataId), Vector3.zero, 0f, Client.Game.Enums.AttachPoint.WeaponSlot);

				//PlayTimeline(context.data.Timelines[0], context.sourceWeapon);
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

					PlayTimeline(context.data.Timelines[1], endPosition + Vector3.down*2f);
						
				}
				
				if(hitActor != null) {
					var pl = new WeaponDamagePayload(context, hitActor, this.Attributes[AbilityAttributes.Damage]);
					KnockBack(hitActor as Actors.Character, context.targetDirection.normalized);
					pl.DamageScalar = dt;
					pl.Apply();
				}


			}
		}


		Vector3 BeamEndPosition(AbilityContext ctx, out Actor hitActor) {
			
			var startLocation = PointOnActor(Client.Game.Enums.AttachPoint.Muzzle, context.source);
			int layerMask = LayerMask.GetMask(LayerGroups.ProjectileCollision);
			var hit = Physics2D.CircleCast(startLocation, beamWidth, VectorUtils.Vector2(ctx.targetDirection), 100f, layerMask);
			if(hit != null && hit.transform != null) {
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

