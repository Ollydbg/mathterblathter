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
		private float jumpPowerAccumulator = 0f;
		private bool jumpNeedsReset = false;
		private Vector2 movementAccumulator = Vector2.zero;
		private float groundedDistance;
		private int groundedMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.SoftGeometry.ToString()});
		private int softGeoMask = LayerMask.GetMask(new string[]{Layers.SoftGeometry.ToString()});

		Rigidbody2D rigidBody;
		Animator animator;

		public delegate void GroundingHandler(Vector3 groundingVelocity);
		private bool wasGrounded;
		public event GroundingHandler OnGrounded;


		public CharacterController2D(Character actor) {
			this.Actor = actor;
			this.rigidBody = actor.GameObject.GetComponent<Rigidbody2D>();
			this.animator = actor.GameObject.GetComponent<Animator>();
			var collider = actor.GameObject.GetComponent<CircleCollider2D>();
			
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

		public void Update (float dt) {
			SetAnimationState();

		}


		public bool IsGrounded 
		{
			get {
				var hit = Physics2D.Raycast(VectorUtils.Vector2(Actor.GameObject.transform.position), Vector2.down, groundedDistance + .2f, groundedMask);
				var goodHit = hit.collider != null;

				return goodHit;
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


		public void FixedUpdate() {
			
			if(wasGrounded) {
				jumpPowerAccumulator = 0f;
			}

			ConsumeMovement();
		}

		void SetAnimationState ()
		{
			if(animator != null) {
				animator.SetFloat("speed", Math.Abs(rigidBody.velocity.x));
				animator.SetBool("grounded", IsGrounded);
				animator.SetFloat("yVelocity", Math.Abs(rigidBody.velocity.y));
			}
			
		}

		void ConsumeMovement ()
		{
			//hits wall?
			var hit = Physics2D.Raycast(rigidBody.position, (Vector2.right * movementAccumulator.x).normalized, movementAccumulator.x * Time.fixedDeltaTime, groundedMask);
			if(hit.transform != null) {
				movementAccumulator.x = -rigidBody.velocity.x;
			}

			rigidBody.velocity = new Vector2(movementAccumulator.x, rigidBody.velocity.y + movementAccumulator.y);
			
			//Actor.transform.position += movementAccumulator;
			var grounded = IsGrounded;
			if(grounded && !wasGrounded) {
				if(OnGrounded != null) {
					OnGrounded(rigidBody.velocity);
				}

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
			var aref = this.Actor.GameObjectRef;

			if(IsGrounded && !jumpNeedsReset) {
				var jumpHeight = aref.MinJumpPower;//Actor.Attributes[ActorAttributes.MinJumpPower];
				movementAccumulator += Vector2.up * jumpHeight;
				jumpPowerAccumulator += jumpHeight;

			} else if(jumpPowerAccumulator < aref.MaxJumpPower && !jumpNeedsReset) {
				var boost = aref.SustainedJumpPower;//Actor.Attributes[ActorAttributes.SustainedJumpPower];
				movementAccumulator += Vector2.up * boost * Time.deltaTime;
				jumpPowerAccumulator += boost * Time.deltaTime;
			} else {
				jumpNeedsReset = true;
			}


		}

		public void KnockDirection (Vector3 direction, float force)
		{
			direction.z = 0;
			movementAccumulator += (VectorUtils.Vector2(direction) * force);
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

