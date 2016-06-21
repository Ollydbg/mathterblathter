using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Animation;
using Client.Game.Abilities;
using Client.Game.Data;
using System.Linq;
using Client.Game.Geometry;


namespace Client.Game.Actors.Controllers
{
	public class CharacterController2D : ICharacterController
	{
		private Character Actor;
		private float xScale = 20;
		public float facingAngle = 0f;
		public float horizontalAxis = 0f;
		private static float GRAVITY_ACC = -1.8f;
		private float gravityYv = 0f;
		private static float MAX_DOWN_SPEED = -1000f;
		private float jumpPowerAccumulator = 0f;
		private bool jumpNeedsReset = false;
		private Vector3 movementAccumulator = Vector3.zero;

		public delegate void GroundingHandler(Vector3 groundingVelocity);
		private bool wasGrounded;
		public event GroundingHandler OnGrounded;


		public CharacterController2D(Character actor) {
			this.Actor = actor;
		}

		public bool Ducking { get; set;}


		public void MoveRight (float hor)
		{
			if(hor > 0) 
				xScale = 20;
			else if(hor < 0)
				xScale = -20;
			facingAngle = xScale;
			horizontalAxis = hor;


			var scale = Actor.GameObject.transform.localScale;
			scale.x = xScale;
			Actor.GameObject.transform.localScale = scale;

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
				return true;
				//return internalController.isGrounded;
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

			if(SubjectToGravity) {
				gravityYv += (GRAVITY_ACC*dt * GravityScalar);
				gravityYv = Mathf.Clamp(gravityYv, MAX_DOWN_SPEED, 1000);
				movementAccumulator += Vector3.up * (gravityYv);
			} 

			if(wasGrounded) {
				jumpPowerAccumulator = 0f;
			}

			ConsumeMovement();

		}

		void ConsumeMovement ()
		{
			Actor.transform.position += movementAccumulator;
			var grounded = IsGrounded;
			if(grounded && !wasGrounded) {
				if(OnGrounded != null) {
					//OnGrounded(internalController.velocity);
				}

			}
			if(grounded) {
				gravityYv = 0;
			}
			wasGrounded = grounded;

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
				movementAccumulator += Vector3.up * jumpHeight;
				gravityYv = jumpHeight;
				jumpPowerAccumulator += jumpHeight;

			} else if(jumpPowerAccumulator < Actor.Attributes[ActorAttributes.MaxJumpPower] && !jumpNeedsReset) {
				var boost = Actor.Attributes[ActorAttributes.SustainedJumpPower];
				movementAccumulator += Vector3.up * boost * Time.deltaTime;
				gravityYv += boost * Time.deltaTime;
				jumpPowerAccumulator += boost * Time.deltaTime;
			} else {
				jumpNeedsReset = true;
			}
		}

		public void KnockDirection (Vector3 direction, float force)
		{
			direction.z = 0;
			movementAccumulator += (direction * force);
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

