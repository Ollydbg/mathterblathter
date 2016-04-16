﻿using System;
using UnityEngine;

namespace Client.Game.Animation
{
	public interface IAnimator
	{
		void RequestState (string stateString, int activationPriority = 1, int runningPriority = 0, 
		                  AnimationBlendMode blendMode = 0, float startTime = 0f, int animName = 0, float animSpeed = 1f);

	}
}
