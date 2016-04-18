using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Animation;
using Client.Game.Abilities;
using Client.Game.Data;
using System.Linq;

namespace Client.Game.Actors
{
	public class CharacterController
	{
		private Character Actor;
		private int angle = 90;
		UnityEngine.CharacterController internalController;
		public float facingAngle = 0f;
		public float horizontalAxis = 0f;
		private static float GRAVITY_ACC = -1.8f;
		private float gravityYv = 0f;
		private static float MAX_DOWN_SPEED = -100f;
		private float jumpPowerAccumulator = 0f;
		private bool jumpNeedsReset = false;
		private Vector3 movementAccumulator = Vector3.zero;

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

			

			Vector3 moveVector = horizontalAxis * RunSpeed * Vector3.right;
			moveVector*= Time.deltaTime;

			movementAccumulator+= moveVector;

			string animTarget = horizontalAxis != 0 ? States.RUN : States.IDLE ;
			Actor.Animator.RequestState(animTarget, 0);

		}

		public bool IsGrounded 
		{
			get {
				return internalController.isGrounded;
			}
		}



		public void FixedUpdate() {
			ConsumeMovement();


		}

		public void Update(float dt) {

			if(!IsGrounded) {
				gravityYv += (GRAVITY_ACC*dt);
				gravityYv = Mathf.Clamp(gravityYv, MAX_DOWN_SPEED, 10);
			} else {
				jumpPowerAccumulator = 0f;
				gravityYv = (GRAVITY_ACC*dt);
			}

			movementAccumulator += Vector3.up * (gravityYv);
		}

		void ConsumeMovement ()
		{

			internalController.Move(movementAccumulator);

			movementAccumulator = Vector3.zero;

		}

		public void StopJumping ()
		{
			jumpNeedsReset = false;
		}

		public void Jump() {
			
			if(IsGrounded && !jumpNeedsReset) {
				var jumpHeight = Actor.Attributes[ActorAttributes.MinJumpPower];
				internalController.Move(Vector3.up*jumpHeight);
				//gravityYv = 0;
				gravityYv = jumpHeight;
				jumpPowerAccumulator += jumpHeight;
			} else if(jumpPowerAccumulator < Actor.Attributes[ActorAttributes.MaxJumpPower] && !jumpNeedsReset) {
				var boost = Actor.Attributes[ActorAttributes.SustainedJumpPower];
				internalController.Move(Vector3.up*boost);
				
				gravityYv += boost;
				jumpPowerAccumulator += boost;
			} else {
				jumpNeedsReset = true;
			}
		}


		public void Attack () {

			var weaponIndex = Actor.Attributes[ActorAttributes.CurrentWeaponIndex];
			Actor.Game.AbilityManager.ActivateAbility (new AbilityContext(Actor, Actor.transform.forward, MockAbilityData.PLAYER_MELEE));
		}



	}




}

