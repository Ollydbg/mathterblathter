using System;
using UnityEngine;
namespace Client.Game.Core.Actors
{
	public class PlayerAnimator3D
	{
		private GameObject gameObject;
		private Animation animation;

		public static string DEATH = "death";
		public static string IDLE01 = "idle01";
		public static string RUN = "run";
		public static string RUN_L = "run_l";
		public static string RUN_R = "run_r";
		public static string SPIN_LEFT = "spinleft";
		public static string SPIN_RIGHT = "spinright";

		private string currentState = IDLE01;

		public PlayerAnimator3D (Actor animationTarget)
		{
			this.gameObject = animationTarget.GameObject;
			this.animation = gameObject.GetComponent<Animation>();
		}

		public void RequestState(string animState) {
			if(animState != currentState) {
				animation.CrossFade(animState, .1f, PlayMode.StopAll);
				currentState = animState;
			}
		}

		
	}
}

