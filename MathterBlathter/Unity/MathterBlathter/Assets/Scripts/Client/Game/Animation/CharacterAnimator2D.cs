using System;
using UnityEngine;
using Client.Game.Actors;


namespace Client.Game.Animation
{
	using Animation = UnityEngine.Animation;

	public class CharacterAnimator2D : IAnimator
	{
		
		Animator animator;
		private bool enabled;

		public CharacterAnimator2D (Actor owner)
		{
			animator = owner.GameObject.GetComponentInChildren<Animator>();
			enabled = animator != null;
		}


		public void SetGroundSpeed (float spd)
		{
			if(!enabled) return;	
			animator.SetFloat("speed", spd);
		}

		public void SetIsHit (bool isHit)
		{

			if(!enabled) return;
			animator.SetBool("isHit", isHit);
		}

		public void SetGrounded (bool grounded)
		{

			if(!enabled) return;
			animator.SetBool("grounded", grounded);
		}

	}
}

