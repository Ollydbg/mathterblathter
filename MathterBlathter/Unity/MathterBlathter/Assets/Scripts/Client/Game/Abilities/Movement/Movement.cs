using System;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Abilities.Movement
{
	public abstract class Movement
	{
		public Actor Target;
		public float Speed;

		public Movement(Actor actor){
			this.Target = actor;
		}

		public abstract Vector3 Heading();

		public abstract void Update(float dt);
	}
}

