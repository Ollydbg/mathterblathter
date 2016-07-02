using System;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Abilities.Movement
{
	public class RigidBodyAddForce : Movement
	{
		public Vector2 Direction;
		public Rigidbody2D Rigidbody;
		public RigidBodyAddForce (Actor actor, Vector3 direction, float speed) : base(actor)
		{
			this.Speed = speed;
			this.Direction = direction;
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

