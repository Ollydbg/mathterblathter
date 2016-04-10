using System;
using UnityEngine;

namespace Client.Game.Actors
{
	public class ProjectileActor : Actor
	{
		public Action<Actor> OnHit;
		private Vector3 direction;
		private float speed;
		private float lifespan = 5.0f;


		public ProjectileActor ()
		{
			
		}



		public void SetMovement (Vector3 direction, float speed)
		{
			this.direction = direction;
			this.speed = speed;
		}

		public override void Update (float dt)
		{
			this.transform.position += (direction * (speed * dt));
			lifespan -= dt;
			if (lifespan <= 0f) {
				Game.Remove (this);
			}
		}
	}
}

