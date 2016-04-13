using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Animation;
using Client.Game.Abilities;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public class CharacterController
	{
		private Character Actor;
		private int angle = 90;
		UnityEngine.CharacterController internalController;
		public float facingAngle = 0f;
		public float horizontalAxis = 0f;
		private static float GRAVITY_ACC = -20.8f;
		private float gravityYv = 0f;
		private static float MAX_DOWN_SPEED = -10f;

		public CharacterController(Character actor) {
			this.Actor = actor;
			internalController = this.Actor.GameObject.GetComponent<UnityEngine.CharacterController>();
		}
	



		public void MoveRight (float hor)
		{
			if(hor > 0) 
				angle = 90;
			else if(hor < 0)
				angle = -90;
			facingAngle = angle;
			horizontalAxis = hor;


			var transform = Actor.GameObject.transform;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

			float RunSpeed = Actor.Attributes[ActorAttributes.Speed];
			Vector3 oldPos = Actor.GameObject.transform.position;

			Vector3 moveVector = horizontalAxis * RunSpeed * Vector3.right;
			//gravity
			moveVector.y = gravityYv;

			internalController.Move(Time.deltaTime * moveVector);

			string animTarget = horizontalAxis != 0 ? States.RUN : States.IDLE ;
			Actor.Animator.RequestState(animTarget, 0);

		}

		public bool IsGrounded 
		{
			get {
				return internalController.isGrounded;
			}
		}

		public void SwitchWeapon ()
		{

		}

		

		public void Update(float dt) {
			
			if(!IsGrounded) {
				gravityYv += (GRAVITY_ACC*dt);
				gravityYv = Mathf.Clamp(gravityYv, MAX_DOWN_SPEED, 10);

			} else {
				gravityYv = GRAVITY_ACC;
			}
		}


		public void Jump() {

			if(IsGrounded) {
				var jumpHeight = Actor.Attributes[ActorAttributes.JumpHeight];
				gravityYv += jumpHeight;

			}
		}

		public void Attack () {
			Actor.Game.AbilityManager.ActivateAbility (new AbilityContext(Actor, Actor.transform.forward, MockAbilityData.PLAYER_MELEE));
		}



	}


	

}

