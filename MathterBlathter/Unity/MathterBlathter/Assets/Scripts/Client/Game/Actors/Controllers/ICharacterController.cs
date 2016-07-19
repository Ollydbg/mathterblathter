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
		void MoveDirection(Vector2 normalizedDir, bool andFace = false);
		void KnockDirection(Vector2 direction, float force);
		void FixedUpdate();
		void SetOwner(Character owner);
		void MoveTo(Vector2 position);

		bool Ducking {
			get; set;
		}
	}
}

