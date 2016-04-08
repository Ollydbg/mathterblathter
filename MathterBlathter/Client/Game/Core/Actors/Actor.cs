using System;
using UnityEngine;

namespace Client.Game.Core.Actors
{
	public class Actor
	{
		private static int LastId;
		public int Id = LastId++;
		public GameObject GameObject;




		public Actor ()
		{

		}



		public virtual void EnterGame(Game game) {
			
		}



		public virtual void Update(float dt) {
			
		}
	}
}

