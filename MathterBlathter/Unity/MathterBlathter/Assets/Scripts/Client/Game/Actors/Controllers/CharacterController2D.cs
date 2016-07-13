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
		public float horizontalAxis = 0f;
		private Vector2 movementAccumulator = Vector2.zero;
		private float groundedDistance;
		private int groundedMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.SoftGeometry.ToString()});
		private int softGeoMask = LayerMask.GetMask(new string[]{Layers.SoftGeometry.ToString()});
		private Collider2D collider;
		int jumpFrames = 0;

		Rigidbody2D rigidBody;
		Animator animator;

		public delegate void GroundingHandler(Vector3 groundingVelocity);
		private bool wasGrounded;
		public event GroundingHandler OnGrounded;
		

		public CharacterController2D() {
			
		}

		public void SetOwner(Character actor) {
			this.Actor = actor;
			this.rigidBody = actor.GameObject.GetComponent<Rigidbody2D>();
			this.animator = actor.GameObject.GetComponentInChildren<Animator>();
			this.collider = actor.GameObject.GetComponent<Collider2D>();

			if(rigidBody == null) {
				Debug.LogError("Couldn't find rigidbody on actor " + actor + ". Did you set the wrong actor type in the data?");
			}

			groundedDistance = collider.bounds.extents.y;
			rigidBody.gravityScale = GravityScalar;

		}


		public bool Ducking { get; set;}


		public void MoveRight (float hor)
		{
			horizontalAxis = hor;

			float RunSpeed = Actor.Attributes[ActorAttributes.Speed];

			Vector2 moveVector = horizontalAxis * RunSpeed * Vector2.right;

			movementAccumulator += (moveVector * Time.deltaTime);

		}

		public void MoveDirection(Vector2 direction) {
			float RunSpeed = Actor.Attributes[ActorAttributes.Speed];

			Vector2 moveVector = direction * RunSpeed;

			movementAccumulator += (moveVector * Time.deltaTime);
		}

		public void Update (float dt) {
			SetAnimationState(movementAccumulator, wasGrounded);
		}


		public bool IsGrounded 
		{
			get {
				var hit = Physics2D.BoxCast(VectorUtils.Vector2(Actor.GameObject.transform.position), collider.bounds.size, 0f, Vector2.down, groundedDistance + .1f, groundedMask);
				var goodHit = hit.collider != null;

				return goodHit && rigidBody.velocity.y == 0f;
			}
		}

		bool UsesGravity {
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

/*
			//JUMP TUNING
			var MinJumpPower = Actor.GameObjectRef.MinJumpPower;
			var JumpBoostFrameThresh = Actor.GameObjectRef.JumpBoostFrameThresh;
			var SustainedJumpPower = Actor.GameObjectRef.SustainedJumpPower;
			var BoostFramesFloor = Actor.GameObjectRef.BoostFramesFloor;
*/
			if(jumping) {
				var grounded = IsGrounded;

				if(grounded && jumpFrames == 0) {
					var jumpHeight = Actor.Attributes[ActorAttributes.MinJumpPower];
					movementAccumulator += Vector2.up * jumpHeight;

				} else if(jumpFrames > Actor.Attributes[ActorAttributes.JumpBoostFrameFloor]
				 && jumpFrames < Actor.Attributes[ActorAttributes.JumpBoostFrameThresh]) {
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
			if(UsesGravity) {
				rigidBody.velocity = new Vector2(movementAccumulator.x, rigidBody.velocity.y + movementAccumulator.y);
			} else {
				rigidBody.velocity = movementAccumulator;
			}
			

			var grounded = IsGrounded;
			if(grounded && !wasGrounded) {
				jumpFrames = 0;
				if(OnGrounded != null) {
					OnGrounded(rigidBody.velocity);
				}
			}

			wasGrounded = grounded;

			movementAccumulator = Vector2.zero;
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

