using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Utils;

namespace Client.Game.Abilities.Movement
{
	public class Linear : BaseMovement
	{
		
		public Linear() {}

		public Linear (ProjectileActor actor, Vector2 direction, float speed) : base(actor, direction, speed)
		{
		
		}

		public override void Redirect (Vector3 direction)
		{
			this.Direction = direction;
		}


		public override void Update (float dt)
		{
			Target.transform.position += VectorUtils.Vector3((Direction * (Speed * dt)));

		}

		public override Vector3 Heading ()
		{
			return Direction.normalized;
		}

	}
}

