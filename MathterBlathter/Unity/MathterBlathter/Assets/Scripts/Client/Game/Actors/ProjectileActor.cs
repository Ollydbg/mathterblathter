﻿using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Abilities.Utils;
using Client.Game.Abilities;
using Client.Game.Enums;
using Client.Game.Abilities.Movement;
using Client.Game.Attributes;

namespace Client.Game.Actors
{
	public class ProjectileActor : Actor
	{
		public Action<Actor> OnHit;
		public Action OnGeometryHit;

		private float lifespan = 5.0f;
		private float lifetime = 0f;
		private bool destroyOnGeometry;
		private FilterList collisionFilters;

		public AbilityContext Context;

		private static string PROJECTILES_LAYER = Layers.Projectiles.ToString();
		private static int HARD_GEOMETRY_LAYER = LayerMask.NameToLayer(Layers.HardGeometry.ToString());

		public Movement Movement;

		public ProjectileActor ()
		{
			
		}


		public override void EnterGame (Client.Game.Core.Game game)
		{
			this.GameObject.layer = LayerMask.NameToLayer (PROJECTILES_LAYER);
			this.lifespan = this.Attributes[ActorAttributes.ProjectileLifespan];
			this.destroyOnGeometry = this.Attributes[ActorAttributes.ProjectileDestroyOnGeometry];

			base.EnterGame (game);
		}

		public void SetMovement(Movement movement) {
			this.Movement = movement;
			this.GameObject.GetComponent<ActorRef> ().TriggerEvent += OnTrigger;
			this.GameObject.GetComponent<ActorRef> ().CollisionEvent += OnCollision;
		}


		public void SetCollisionFilters(AbilityContext context, FilterList filters) {
			this.Context = context;
			this.collisionFilters = filters;
		}

		void OnCollision (Collision2D collision)
		{
			Game.ActorManager.RemoveActor(this);
		}

		public void Point(Vector3 direction) {
			transform.LookAt(direction);
		}

		public TriggerTestResult TestTrigger(Collider2D collider, out Actor actor) {
			if(collider.gameObject.layer == HARD_GEOMETRY_LAYER) {
				actor = null;
				return TriggerTestResult.Geometry;
			}

			var actorRef = collider.GetComponent<ActorRef>();
			if (actorRef != null) {
				
				if (collisionFilters.Check(Context, actorRef.Actor)) {
					actor = actorRef.Actor;
					return TriggerTestResult.Ok;
				}
			}

			actor = null;

			return TriggerTestResult.Bad;
		}

		void OnTrigger (Collider2D Collider)
		{

			Actor actor;
			var result = TestTrigger(Collider, out actor);
			if(OnHit != null && result == TriggerTestResult.Ok) {
				OnHit(actor);
			}

			if(result == TriggerTestResult.Geometry) {
				if(OnGeometryHit != null)
					OnGeometryHit();
				
				if(destroyOnGeometry)
					Game.ActorManager.RemoveActor(this);

			}

		}

		public override void Update (float dt)
		{
			if(Movement != null)
				this.Movement.Update(dt);

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

