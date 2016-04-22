using System;

namespace Client.Game.Actors.Controllers
{
	public interface ICharacterController
	{

		void Update(float dt);
		void Jump();
		void StopJumping();
		void MoveRight(float amt);
	}
}

