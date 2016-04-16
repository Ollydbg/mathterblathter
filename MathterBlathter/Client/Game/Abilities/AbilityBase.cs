using System;
using Client.Game.Abilities;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;

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

		public ProjectileActor FireProjectile(string projectileResourcePath) {

			var projectile = context.source.Game.ActorManager.Spawn<ProjectileActor>(projectileResourcePath);
			projectile.transform.position = context.source.transform.position;
			projectile.SetMovement (context.direction, 5f);



			return projectile;

		}
	}
}

