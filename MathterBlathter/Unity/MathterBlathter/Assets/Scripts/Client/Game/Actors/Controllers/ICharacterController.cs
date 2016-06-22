using System;
using UnityEngine;

namespace Client.Game.Actors.Controllers
{
	public interface ICharacterController
	{

		void Update(float dt);
		void Jump();
		void StopJumping();
		void MoveRight(float amt);
		void KnockDirection(Vector3 direction, float force);
		void FixedUpdate();

		bool Ducking {
			get; set;
		}
	}
}

