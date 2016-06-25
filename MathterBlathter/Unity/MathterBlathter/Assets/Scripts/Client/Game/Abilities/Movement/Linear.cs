using System;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Abilities.Movement
{
	public class Linear : Movement
	{
		public Vector3 Direction;

		public Linear (Actor actor, Vector3 direction, float speed) : base(actor)
		{
			this.Direction = direction;
			this.Speed = speed;
		}

		public override void Redirect (Vector3 direction)
		{
			this.Direction = direction;
		}


		public override void Update (float dt)
		{
			Target.transform.position += (Direction * (Speed * dt));

		}

		public override Vector3 Heading ()
		{
			return Direction.normalized;
		}

	}
}

