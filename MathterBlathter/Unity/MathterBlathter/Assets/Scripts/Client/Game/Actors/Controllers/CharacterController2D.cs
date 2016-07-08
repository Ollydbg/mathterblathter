using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Animation;
using Client.Game.Abilities;
using Client.Game.Data;
using System.Linq;
using Client.Game.Geometry;
using Client.Utils;
using Client.Game.Enums;


namespace Client.Game.Actors.Controllers
{
	public class CharacterController2D : ICharacterController
	{
		

		private Character Actor;
		private float xScale = 1;
		Vector3 originalScale;
		public float horizontalAxis = 0f;
		private Vector2 movementAccumulator = Vector2.zero;
		private float groundedDistance;
		private int groundedMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.SoftGeometry.ToString()});
		private int softGeoMask = LayerMask.GetMask(new string[]{Layers.SoftGeometry.ToString()});
		int jumpFrames = 0;

		Rigidbody2D rigidBody;
		Animator animator;

		public delegate void GroundingHandler(Vector3 groundingVelocity);
		private bool wasGrounded;
		public event GroundingHandler OnGrounded;


		public CharacterController2D(Character actor) {
			this.Actor = actor;
			this.rigidBody = actor.GameObject.GetComponent<Rigidbody2D>();
			this.animator = actor.GameObject.GetComponentInChildren<Animator>();
			var collider = actor.GameObject.GetComponent<Collider2D>();

			if(rigidBody == null) {
				Debug.LogError("Couldn't find rigidbody on actor " + actor + ". Did you set the wrong actor type in the data?");
			}

			groundedDistance = collider.bounds.extents.y;
			rigidBody.gravityScale = GravityScalar;

			originalScale = actor.GameObject.transform.localScale;
			xScale = originalScale.x;
		}

		public bool Ducking { get; set;}


		public void MoveRight (float hor)
		{
			if(hor > 0) 
				xScale = 1 * originalScale.x;
			else if(hor < 0)
				xScale = -1 * originalScale.x;

			horizontalAxis = hor;

			var scale = Actor.GameObject.transform.localScale;
			scale.x = xScale;
			Actor.GameObject.transform.localScale = scale;

			float RunSpeed = Actor.Attributes[ActorAttributes.Speed];

			Vector2 moveVector = horizontalAxis * RunSpeed * Vector2.right;

			movementAccumulator += moveVector;

		}

		public void MoveDirection(Vector2 direction) {
			if(direction.x > 0) 
				xScale = 1 * originalScale.x;
			else if(direction.x < 0)
				xScale = -1 * originalScale.x;
			
			var scale = Actor.GameObject.transform.localScale;
			scale.x = xScale;
			Actor.GameObject.transform.localScale = scale;

			float RunSpeed = Actor.Attributes[ActorAttributes.Speed];

			Vector2 moveVector = direction * RunSpeed;

			movementAccumulator += moveVector;
		}

		public void Update (float dt) {
			
		}


		public bool IsGrounded 
		{
			get {
				var hit = Physics2D.Raycast(VectorUtils.Vector2(Actor.GameObject.transform.position), Vector2.down, groundedDistance + .1f, groundedMask);
				var goodHit = hit.collider != null;

				return goodHit && rigidBody.velocity.y == 0f;
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

		void AddJump ()
		{
			if(jumping) {
				var grounded = IsGrounded;

				if(grounded && jumpFrames == 0) {
					var jumpHeight = Actor.Attributes[ActorAttributes.MinJumpPower];
					movementAccumulator += Vector2.up * jumpHeight;

				} else if(jumpFrames == Actor.Attributes[ActorAttributes.JumpBoostFrameThresh]) {
					movementAccumulator += Vector2.up * Actor.Attributes[ActorAttributes.SustainedJumpPower];
				}

				jumpFrames ++;

			}

		}

		public void FixedUpdate() {

			AddJump();
			ConsumeMovement();
		}

		void SetAnimationState (Vector2 velocity, bool grounded)
		{
			if(animator != null) {
				animator.SetFloat("speed", Math.Abs(velocity.x));
				animator.SetBool("grounded", grounded);
			}
			
		}

		void ConsumeMovement ()
		{
			rigidBody.velocity = new Vector2(movementAccumulator.x, rigidBody.velocity.y + movementAccumulator.y);
			
			//Actor.transform.position += movementAccumulator;
			var grounded = IsGrounded;
			if(grounded && !wasGrounded) {
				jumpFrames = 0;
				if(OnGrounded != null) {
					OnGrounded(rigidBody.velocity);
				}
			}

			wasGrounded = grounded;

			SetAnimationState(movementAccumulator, grounded);

			movementAccumulator = Vector3.zero;

		}

		bool jumping = false;
		public void StopJumping ()
		{
			jumping = false;
		}

		public void Jump() {
			if(Ducking) {
				tryDuckJump();
				return;
			}

			jumping  = true;

		}

		public void KnockDirection (Vector2 direction, float force)
		{
			movementAccumulator += (direction * force);
		}

		private void tryDuckJump() {
			RaycastHit2D hit = Physics2D.Raycast(VectorUtils.Vector2(Actor.transform.position), Vector2.down, 2.5f, softGeoMask);
			if (hit.transform != null) {
				var passthrough = hit.collider.gameObject.GetComponent<PassthroughPlatform>();
				if(passthrough) {
					passthrough.Passthrough(Actor);
				}
			}
		}


	}




}

