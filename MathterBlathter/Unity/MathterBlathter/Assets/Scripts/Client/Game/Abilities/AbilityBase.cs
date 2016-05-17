using System;
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

		private List<Actor> SpawnedActors = new List<Actor>();

		public AbilityBase ()
		{
		}

		public WeaponActor SourceWeapon {
			get {
				return context.source.ActorType == ActorType.Weapon ? (WeaponActor)context.source : context.sourceWeapon;
			}
		}

		public virtual void Init(AbilityContext ctx) {
			this.context = ctx;
			this.Attributes.LoadFromData (ctx.data.attributeData);	
		}


		public abstract void Start ();
		public abstract void Update (float dt);
		public abstract void End ();

		public virtual bool isComplete() {
			return SpawnedActors.Count == 0;
		}

		public GameObject ProjectileImpactEffect(ProjectileActor projectile, String resourcePath) {
			Quaternion targetRotation = projectile.transform.rotation;
			var go = (GameObject)GameObject.Instantiate(Resources.Load(resourcePath), projectile.transform.position, targetRotation);
			EffectTTL.AddToObject(go, 2f);
			return go;
		}

		public ProjectileActor FireProjectile(CharacterData projectileData, Vector3 direction, float speed, AttachPoint point) {
			
			Vector3 adjustedDirection = AbilityUtils.AdjustWithInaccuracy(direction, context);


			var projectile = context.source.Game.ActorManager.Spawn<ProjectileActor>(projectileData);
			projectile.transform.position = AttachPointComponent.AttachPointPositionOnActor(point, context.source);

			projectile.transform.LookAt(projectile.transform.position + adjustedDirection);
			projectile.SetMovement (adjustedDirection, speed);
			projectile.SetCollisionFilters(context, FilterList.QuickFilters);
			projectile.GameObject.layer = UnityEngine.LayerMask.NameToLayer(Layers.Projectiles.ToString());
			SpawnedActors.Add(projectile);

			projectile.OnDestroyed += (Actor actor) => {
				SpawnedActors.Remove(actor);
			};



			return projectile;
		}


		public void ApplyEnergyCost(Actor actor) {
			new AnxietyCostPayload(context, actor,context.sourceWeapon.Attributes[ActorAttributes.WeaponAnxietyCost])
				.Apply();
		}


		public void PlayTimeline (TimelineData timelineData, Actor target)
		{
			TimelineRunner.Play(timelineData, target);
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

