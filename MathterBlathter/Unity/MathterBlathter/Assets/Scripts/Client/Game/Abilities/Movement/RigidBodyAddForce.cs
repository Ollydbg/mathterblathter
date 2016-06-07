using System;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Abilities.Movement
{
	public class RigidBodyAddForce : Movement
	{
		public Vector3 Direction;
		public Rigidbody Rigidbody;
		public RigidBodyAddForce (Actor actor, Vector3 direction, float speed) : base(actor)
		{
			this.Speed = speed;
			this.Direction = direction;
			this.Rigidbody = actor.GameObject.GetComponent<Rigidbody>();
			Rigidbody.AddForce(Direction * speed, ForceMode.VelocityChange);
		}

		#region implemented abstract members of Movement

		public override UnityEngine.Vector3 Heading ()
		{
			return this.Direction.normalized;
		}

		public override void Update (float dt)
		{
		}

		#endregion
	}
}

