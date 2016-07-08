using System;

namespace Client.Game.Actors.Controllers
{
	public class EmptyCharacterController : ICharacterController
	{
		public EmptyCharacterController ()
		{
		}

		public void MoveDirection (UnityEngine.Vector2 normalizedDir)
		{
		}

		#region ICharacterController implementation

		public void Update (float dt)
		{
		}

		public void FixedUpdate ()
		{
		}

		public void Jump ()
		{
		}

		public void StopJumping ()
		{
		}

		public void MoveRight (float amt)
		{
		}

		public void KnockDirection (UnityEngine.Vector2 direction, float force)
		{
		}

		public bool Ducking {
			get; set;
		}
		#endregion
	}
}

