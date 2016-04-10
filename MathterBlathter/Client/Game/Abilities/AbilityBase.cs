using System;
using Client.Game.Abilities;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;

namespace Client
{
	public abstract class AbilityBase
	{
		internal AbilityContext context;

		public AbilityBase ()
		{
		}

		public virtual void Init(AbilityContext ctx) {
			this.context = ctx;
		}

		public abstract void Start ();
		public abstract void Update (float dt);
		public abstract void End ();

		public virtual bool isComplete() {
			return false;
		}

		public ProjectileActor FireProjectile() {
			//var projectile = (GameObject)GameObject.Instantiate (Resources.Load (context.data.spawnableResourcePath));
			//projectile.transform.position = context.source.transform.position;
			var projectile = context.source.Game.Spawn<ProjectileActor>(context.data.spawnableResourcePath);
			projectile.transform.position = context.source.transform.position;
			projectile.SetMovement (context.direction, 5f);

			projectile.OnHit = (actor) => {
				new DamagePayload (context, actor, 10).Apply();
				context.source.Game.RemoveActor(projectile);
			};

			return projectile;

		}
	}
}

