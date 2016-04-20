using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Abilities.Utils;
using Client.Game.Abilities;
using Client.Game.Enums;

namespace Client.Game.Actors
{
	public class ProjectileActor : Actor
	{
		public Action<Actor> OnHit;
		private Vector3 direction;
		private float speed;
		private float lifespan = 5.0f;
		private FilterList collisionFilters;

		AbilityContext context;

		private static string PROJECTILES_LAYER = Layers.Projectiles.ToString();
		private static int GEOMETRY_LAYER = LayerMask.NameToLayer(Layers.Geometry.ToString());

		public ProjectileActor ()
		{
			
		}

		public override ActorType ActorType {
			get {
				return ActorType.Projectile;
			}
		}

		public override void EnterGame (Client.Game.Core.Game game)
		{
			this.GameObject.layer = LayerMask.NameToLayer (PROJECTILES_LAYER);
			base.EnterGame (game);
		}

		public void SetMovement (Vector3 direction, float speed)
		{
			this.direction = direction;
			this.speed = speed;
			this.GameObject.GetComponent<ActorRef> ().TriggerEvent += OnTrigger;
			this.GameObject.GetComponent<ActorRef> ().CollisionEvent += OnCollision;

		}

		public void SetCollisionFilters(AbilityContext context, FilterList filters) {
			this.context = context;
			this.collisionFilters = filters;
		}

		void OnCollision (Collision collision)
		{
			Game.ActorManager.RemoveActor(this);
		}

		void OnTrigger (Collider Collider)
		{
			var actorRef = Collider.GetComponent<ActorRef>();
			if (actorRef != null && OnHit != null) {
				if(collisionFilters.Check(context, actorRef.Actor)) 
					OnHit (actorRef.Actor);
			}

			if(Collider.gameObject.layer == GEOMETRY_LAYER) {
				Game.ActorManager.RemoveActor(this);
			}
		}

		public override void Update (float dt)
		{
			this.transform.position += (direction * (speed * dt));
			lifespan -= dt;
			if (lifespan <= 0f) {
				Game.ActorManager.RemoveActor (this);
			}
		}
	}
}

