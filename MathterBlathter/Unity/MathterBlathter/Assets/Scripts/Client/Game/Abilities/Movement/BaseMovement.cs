using System;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Abilities.Movement
{
	public abstract class BaseMovement
	{
		public ProjectileActor Target;
		public float Speed;

		public Vector2 Direction;

		public BaseMovement(){}

		public BaseMovement(ProjectileActor actor, Vector2 direction, float speed){
			Init(actor, direction, speed);
		}

		public void Init(ProjectileActor actor, Vector2 direction, float speed) {
			this.Target = actor;
			this.Direction = direction;
			this.Speed = speed;
		}



		public abstract Vector3 Heading();
		public abstract void Redirect(Vector3 direction);
		public abstract void Update(float dt);
	}
}

