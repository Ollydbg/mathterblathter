using System;
using Client.Game.Abilities;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Data;

namespace Client
{
	public abstract partial class AbilityBase
	{
		internal AbilityContext context;

		public AttributeMap Attributes = new AttributeMap (AbilityAttributes.GetAll());

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

		public ProjectileActor FireProjectile(CharacterData projectileData, float speed, AttachPoint point) {

			var projectile = context.source.Game.ActorManager.Spawn<ProjectileActor>(projectileData);

			projectile.transform.position = AttachPointPositionOnActor(point, context.source);//context.source.transform.position;
			projectile.transform.LookAt(projectile.transform.position + context.direction);
			projectile.SetMovement (context.direction, speed);


			



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

