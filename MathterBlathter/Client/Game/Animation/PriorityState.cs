using System;
using UnityEngine;

namespace Client.Game.Animation
{
	public class PriorityState
	{
		public int Handle;
		public int RunningPriority;
		public int ActivationPriority;
		public AnimationState AnimState;
		public AnimationBlendMode BlendMode;
		public float StartTime;
		public int AnimName;
		public float AnimSpeed;


		public PriorityState()
		{
		}

		public PriorityState(AnimationState state, int runningPriority, int activationPriority, AnimationBlendMode blendMode, float startTime, int handle, int animName, float animSpeed)
		{
			Handle = handle;
			AnimState = state;
			RunningPriority = runningPriority;
			ActivationPriority = activationPriority;
			BlendMode = blendMode;
			StartTime = startTime;
			AnimName = animName;
			AnimSpeed = animSpeed;
		}

		public override string ToString()
		{
			return string.Format("State Name:{0} Activation: {1} Running:{2} BlendMode:{3}", AnimState.name, ActivationPriority, RunningPriority, BlendMode);
		}
	}
}
