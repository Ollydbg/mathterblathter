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
		public Action OnGeometryHit;

		private Vector3 direction;
		public float Speed;
		private float lifespan = 5.0f;
		private float lifetime = 0f;
		private FilterList collisionFilters;

		AbilityContext context;

		private static string PROJECTILES_LAYER = Layers.Projectiles.ToString();
		private static int HARD_GEOMETRY_LAYER = LayerMask.NameToLayer(Layers.HardGeometry.ToString());
		private static int SOFT_GEOMETRY_LAYER = LayerMask.NameToLayer(Layers.SoftGeometry.ToString());

		public ProjectileActor ()
		{
			
		}


		public override void EnterGame (Client.Game.Core.Game game)
		{
			this.GameObject.layer = LayerMask.NameToLayer (PROJECTILES_LAYER);
			base.EnterGame (game);
		}

		public void SetMovement (Vector3 direction, float speed)
		{
			this.direction = direction;
			this.Speed = speed;
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

		public TriggerTestResult TestTrigger(Collider collider, out Actor actor) {
			if(collider.gameObject.layer == HARD_GEOMETRY_LAYER) {
				actor = null;
				return TriggerTestResult.Geometry;
			}

			var actorRef = collider.GetComponent<ActorRef>();
			if (actorRef != null) {
				
				if (collisionFilters.Check(context, actorRef.Actor)) {
					actor = actorRef.Actor;
					return TriggerTestResult.Ok;
				}
			}

			actor = null;

			return TriggerTestResult.Bad;
		}

		void OnTrigger (Collider Collider)
		{

			Actor actor;
			var result = TestTrigger(Collider, out actor);
			if(OnHit != null && result == TriggerTestResult.Ok) {
				OnHit(actor);
			}

			if(lifetime > .1f) {
				if(result == TriggerTestResult.Geometry) {
					if(OnGeometryHit != null)
						OnGeometryHit();
					Game.ActorManager.RemoveActor(this);

				}
			}
		}

		public override void Update (float dt)
		{
			this.transform.position += (direction * (Speed * dt));
			lifetime += dt;

			if (lifetime >= lifespan) {
				Game.ActorManager.RemoveActor (this);
			}
		}

	}

	public enum TriggerTestResult {
		Ok,
		Bad,
		Geometry
	}
}

