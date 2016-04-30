﻿using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Animation;
using Client.Game.Abilities;
using Client.Game.Data;
using System.Linq;
using Client.Game.Geometry;


namespace Client.Game.Actors.Controllers
{
	public class CharacterController : ICharacterController
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

		public bool Ducking { get; set;}


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

			string animTarget = horizontalAxis != 0 ? CharacterAnimState.RUN : CharacterAnimState.IDLE ;
			Actor.Animator.RequestState(animTarget, 0);

		}

		public bool IsGrounded 
		{
			get {
				return internalController.isGrounded;
			}
		}

		bool SubjectToGravity {
			get {
				return Actor.Attributes[ActorAttributes.GravityScalar] != 0f;
			}
		}

		float GravityScalar {
			get {
				return Actor.Attributes[ActorAttributes.GravityScalar];
			}
		}


		public void Update(float dt) {

			if(!IsGrounded && SubjectToGravity) {
				gravityYv += (GRAVITY_ACC*dt * GravityScalar);
				gravityYv = Mathf.Clamp(gravityYv, MAX_DOWN_SPEED, 10);
				movementAccumulator += Vector3.up * (gravityYv);
			} else {
				jumpPowerAccumulator = 0f;
				gravityYv = (GRAVITY_ACC*dt);
			}

			ConsumeMovement();

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

			if(Ducking) {
				tryDuckJump();
				return;
			}

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


		private void tryDuckJump() {
			RaycastHit hit;
			if (Physics.Raycast(new Ray(Actor.transform.position, Vector3.down * 2f), out hit, 2.5f)) {
				var passthrough = hit.collider.gameObject.GetComponent<PassthroughPlatform>();
				if(passthrough) {
					passthrough.Passthrough(Actor);
				}
			}
		}


	}




}
