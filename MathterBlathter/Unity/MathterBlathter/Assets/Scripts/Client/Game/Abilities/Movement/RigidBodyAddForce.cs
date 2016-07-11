using System;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Abilities.Movement
{
	public class RigidBodyAddForce : BaseMovement
	{
		public Rigidbody2D Rigidbody;
		public RigidBodyAddForce (ProjectileActor actor, Vector2 direction, float speed) : base(actor, direction, speed)
		{
			this.Rigidbody = actor.GameObject.GetComponent<Rigidbody2D>();
			Rigidbody.AddForce(Direction * speed, ForceMode2D.Impulse);
		}


		public override UnityEngine.Vector3 Heading ()
		{
			return this.Direction.normalized;
		}


		public override void Redirect (Vector3 direction)
		{
			this.Direction = direction;
		}


		public override void Update (float dt)
		{
		}

	}
}

