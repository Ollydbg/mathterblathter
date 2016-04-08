using System;
using UnityEngine;

namespace Client.Game.Core.Actors
{
	public class PlayerController
	{
		private CharacterActor Actor;
		private int angle = 90;
		Rigidbody body;
		public PlayerController(CharacterActor actor) {
			this.Actor = actor;
			body = this.Actor.GameObject.GetComponent<Rigidbody> ();
		}
	
		public void MoveRight (float hor)
		{
			float RunSpeed = .5f;
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
			
			this.body.AddForce (Vector3.up * 25f, ForceMode.VelocityChange);
		}

	}




}

