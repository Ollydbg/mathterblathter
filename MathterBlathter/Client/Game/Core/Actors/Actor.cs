using System;
using UnityEngine;

namespace Client.Game.Core.Actors
{
	public class Actor
	{
		private static int LastId;
		public int Id = LastId++;
		public GameObject GameObject;

		public PlayerAnimator3D Animator;
		public PlayerController Controller;


		public Actor ()
		{

		}

		public virtual void EnterGame(Game game) {
			Controller = new PlayerController (this);
			Animator = new PlayerAnimator3D(this);
		}

		public virtual void Update(float dt) {
			Controller.Update(dt);
		}
	}
}

