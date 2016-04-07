using System;
using UnityEngine;

namespace Client.Game.Core.Actors
{
	public class PlayerController
	{
		private Actor Actor;
		private int angle = 90;

		public PlayerController(Actor actor) {
			this.Actor = actor;

		}
	
		public void MoveRight (float hor)
		{
			float RunSpeed = 1;
			Vector3 oldPos = Actor.GameObject.transform.position;

			var transform = Actor.GameObject.transform;

			transform.position = new Vector3 (oldPos.x + hor * RunSpeed, oldPos.y, oldPos.z);

			if(hor > 0) 
				angle = 90;
			else if(hor < 0)
				angle = -90;

			string animTarget = hor != 0 ? PlayerAnimator3D.RUN : PlayerAnimator3D.IDLE01;
			Actor.Animator.RequestState(animTarget);
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

		}

		public void Update(float dt) {

		}



		public void Jump() {

		}

	}




}

