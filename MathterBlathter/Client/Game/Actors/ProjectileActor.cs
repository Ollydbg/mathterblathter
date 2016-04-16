using System;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public class ProjectileActor : Actor
	{
		public Action<Actor> OnHit;
		private Vector3 direction;
		private float speed;
		private float lifespan = 5.0f;

		private const string PROJECTILES_LAYER = "Projectiles";


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
			this.GameObject.GetComponent<ActorRef> ().TriggerEvent += onCollision;
		}

		void onCollision (Collider Collider)
		{
			var actorRef = Collider.GetComponent<ActorRef>();
			if (actorRef != null && OnHit != null) {
				OnHit (actorRef.Actor);
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

