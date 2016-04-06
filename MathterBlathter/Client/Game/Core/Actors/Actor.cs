using System;
using UnityEngine;

namespace Client.Game.Core.Actors
{
	public class Actor
	{
		private static int LastId;
		public int Id = LastId++;
		public GameObject GameObject;

		public PlayerController Controller;

		public Actor ()
		{
			Controller = new PlayerController (this);
		}

		public void Update(float dt) {
			Controller.Update(dt);
		}
	}
}

