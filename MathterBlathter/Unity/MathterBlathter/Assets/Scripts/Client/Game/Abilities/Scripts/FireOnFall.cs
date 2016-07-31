using System;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class FireOnFall : BuffBase
	{
		private Rigidbody2D rigidBody;
		private Collider2D collider;
		private bool isFalling;
		private static float EPSILON = .001f;
		private float peakFallingVelocity = 0f;
		private bool completed = false;

		public FireOnFall ()
		{
		}


		public override void Start ()
		{
			collider = Owner.GameObject.GetComponent<Collider2D>();
			rigidBody = Owner.GameObject.AddComponent<Rigidbody2D>();

			Owner.WeaponController.AimDirection = Game.Seed.RandomUnitVector();

				
		}


		public override void Update (float dt)
		{
			var normalYV = Mathf.Abs(rigidBody.velocity.y);
			peakFallingVelocity = Mathf.Max(normalYV, peakFallingVelocity);

			Owner.WeaponController.Update(dt);

			if( normalYV > EPSILON) {
				isFalling = true;
			}

			if(isFalling && normalYV <= EPSILON) {
				isFalling = false;
				completed = true;
				if(peakFallingVelocity > Owner.Attributes[ActorAttributes.FallFireVelocity]) 
					Owner.WeaponController.Attack();
				
			}

		}

		public override bool IsComplete ()
		{
			//we abort this buff when something picks up the item
			return completed || Owner.GameObject.transform.parent != null;
		}

		public override void End ()
		{
			GameObject.Destroy(rigidBody);
			collider.isTrigger = true;
		}

	}
}

