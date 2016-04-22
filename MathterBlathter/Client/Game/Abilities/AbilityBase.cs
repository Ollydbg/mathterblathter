using System;
using Client.Game.Abilities;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Data;
using Client.Game.Abilities.Utils;

namespace Client
{
	public abstract partial class AbilityBase
	{
		internal AbilityContext context;

		public AttributeMap Attributes = new AttributeMap (AbilityAttributes.GetAll());
		public Actor Owner {
			get {
				return this.context.source;
			}
		}
		public AbilityBase ()
		{
		}

		public virtual void Init(AbilityContext ctx) {
			this.context = ctx;
			this.Attributes.LoadFromData (ctx.data.attributeData);	
		}


		public abstract void Start ();
		public abstract void Update (float dt);
		public abstract void End ();

		public virtual bool isComplete() {
			return false;
		}

		public ProjectileActor FireProjectile(CharacterData projectileData, Vector3 direction, float speed, AttachPoint point) {

			var projectile = context.source.Game.ActorManager.Spawn<ProjectileActor>(projectileData);
			projectile.transform.position = AttachPointPositionOnActor(point, context.source);

			projectile.transform.LookAt(projectile.transform.position + direction);
			projectile.SetMovement (direction, speed);
			projectile.SetCollisionFilters(context, FilterList.QuickFilters);

			return projectile;

		}

		public Vector3 AttachPointPositionOnActor(AttachPoint point, Actor actor) {

			var components = actor.GameObject.GetComponentsInChildren<AttachPointComponent>();

			foreach( var comp in components ) {

				if(comp.Type == point) {
					return comp.gameObject.transform.position;
				}

			}


			//default just return the feet position of the actor
			return actor.GameObject.transform.position;

		}
	}
}

