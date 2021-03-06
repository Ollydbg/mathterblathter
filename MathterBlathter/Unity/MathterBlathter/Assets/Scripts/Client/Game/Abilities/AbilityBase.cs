﻿using System;
using Client.Game.Abilities;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Data;
using Client.Game.Abilities.Utils;
using System.Collections.Generic;
using Client.Game.Abilities.Timelines;
using Client.Game.Abilities.Movement;
using Client.Utils;

namespace Client
{
	public abstract partial class AbilityBase
	{
		internal AbilityContext context;
		public InstanceId InstanceId;
		public TimelineRunner TimelineRunner = new TimelineRunner();
		public AttributeMap Attributes = new AttributeMap (AbilityAttributes.GetAll());

		public Actor Owner {
			get {
				return this.context.source;
			}
		}
		
		public Game.Core.Game Game {
			get {
				return this.context.source.Game;
			}
		}

		public List<Actor> SpawnedActors = new List<Actor>();

		public AbilityBase ()
		{
		}

		public void SkipTime() {
			Game.SkipTime(SourceWeapon.Attributes[ActorAttributes.TimeSkipDuration], SourceWeapon.Attributes[ActorAttributes.TimeSkipAmount]);
		}

		public WeaponActor SourceWeapon {
			get {
				return context.source.ActorType == ActorType.Weapon ? (WeaponActor)context.source : context.sourceWeapon;
			}
		}


		public virtual void Init(AbilityContext ctx) {
			this.context = ctx;
			this.Attributes.LoadFromData (ctx.data.attributeData);	
			this.Attributes.LoadFromData(ctx.source.Data.overrideAttributes);

			if(context.sourceWeapon != null) 
				this.Attributes.LoadFromData(context.sourceWeapon.Data.overrideAttributes);
		}


		public abstract void Start ();
		public abstract void Update (float dt);
		public abstract void End ();

		public virtual bool IsComplete() {
			return SpawnedActors.Count == 0 && TimelineRunner.IsComplete();
		}

		public GameObject ProjectileImpactEffect(ProjectileActor projectile, String resourcePath) {
			Quaternion targetRotation = projectile.transform.rotation;
			var go = (GameObject)GameObject.Instantiate(Resources.Load(resourcePath), projectile.transform.position, targetRotation);
			EffectTTL.AddToObject(go, 2f);
			return go;
		}
		public void KnockBack(Character actor) {
			KnockBack(actor, context.targetDirection.normalized);
		}
		public void KnockBack(Character actor, Vector3 direction) {
			new KnockbackPayload(context, actor, direction).Apply();
		}
        public void KnockBack(Character actor, Vector2 dir) { KnockBack(actor, VectorUtils.Vector3(dir)); }
		public void CameraShake() {
			if(context.source.Id == Game.PossessedActor.Id)
				Game.CameraManager.Shake(SourceWeapon.Attributes[ActorAttributes.CameraShakeForce] * -context.targetDirection);
		}





		public void ApplyEnergyCost(Actor actor) {
			new AnxietyCostPayload(context, actor,context.sourceWeapon.Attributes[ActorAttributes.WeaponAnxietyCost])
				.Apply();
		}

		
		public void PlayTimeline (TimelineData timelineData, Actor target) { PlayTimeline(timelineData, target, Vector3.right); }
		public void PlayTimeline (TimelineData timelineData, Actor target, Vector3 direction)
		{
			target.TimelineRunner.Play(timelineData, target, direction);
			//TimelineRunner.Play(timelineData, target, direction);
		}

		public void PlayTimeline (TimelineData timelineData, Vector3 position) { PlayTimeline(timelineData, position, Vector3.right); }
		public void PlayTimeline (TimelineData timelineData, Vector3 position, Vector3 direction)
		{
			TimelineRunner.Play(timelineData, position, direction);
		}


		public virtual bool OnPayloadSend(Payload payload){
			return false;
		}
		public virtual bool OnPayloadReceive(Payload payload){
			return false;
		}

		public Vector3 PointOnActor(AttachPoint point, Actor actor) {
			return AttachPointComponent.AttachPointPositionOnActor(point, actor);
		}


	}
}

