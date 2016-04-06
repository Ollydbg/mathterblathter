using System;
using UnityEngine;

namespace Client.Game.Core.Actors
{
	public class PlayerController
	{
		private Actor Actor;

		public PlayerController(Actor actor) {
			this.Actor = actor;
		}
	


		public void MoveRight (float hor)
		{
			float RunSpeed = 1;
			Vector3 oldPos = Actor.GameObject.transform.position;

			this.Actor.GameObject.transform.position = new Vector3 (oldPos.x + hor * RunSpeed, oldPos.y, oldPos.z);


		}

		public void Update(float dt) {

		}



		public void Jump() {

		}

	}




}

