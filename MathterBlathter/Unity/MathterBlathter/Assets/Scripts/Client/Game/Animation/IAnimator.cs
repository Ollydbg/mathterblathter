using System;
using UnityEngine;

namespace Client.Game.Animation
{
	public interface IAnimator
	{
		void SetGroundSpeed(float spd);
		void SetIsHit(bool isHit);
		void SetGrounded(bool grounded);
	}

	public class EmptyAnimator : IAnimator {
		#region IAnimator implementation
		public void SetGroundSpeed (float spd)
		{
		}
		public void SetIsHit (bool isHit)
		{
		}
		public void SetGrounded (bool grounded)
		{
		}
		#endregion

	}
}

