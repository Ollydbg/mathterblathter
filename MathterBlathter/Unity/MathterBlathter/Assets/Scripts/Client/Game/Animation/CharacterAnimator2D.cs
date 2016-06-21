using System;
using UnityEngine;
using Client.Game.Actors;


namespace Client.Game.Animation
{
	using Animation = UnityEngine.Animation;

	public class CharacterAnimator2D : IAnimator
	{
		public CharacterAnimator2D (Actor owner)
		{
		}

		#region IAnimator implementation

		public void RequestState (string stateString, int activationPriority = 1, int runningPriority = 0, float startTime = 0f, int animName = 0, float animSpeed = 1f)
		{
		}

		#endregion
	}
}

