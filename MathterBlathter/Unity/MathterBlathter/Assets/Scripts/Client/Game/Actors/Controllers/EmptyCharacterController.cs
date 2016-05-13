﻿using System;

namespace Client.Game.Actors.Controllers
{
	public class EmptyCharacterController : ICharacterController
	{
		public EmptyCharacterController ()
		{
		}

		#region ICharacterController implementation

		public void Update (float dt)
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


		public bool Ducking {
			get; set;
		}
		#endregion
	}
}
