using System;
using UnityEngine;
using Client.Game.Actors;


namespace Client.Game.Animation
{
	using Animation = UnityEngine.Animation;

	public class CharacterAnimator3D : IAnimator
	{
		private GameObject gameObject;
		private Animation animation;

		private string currentLocomotive = CharacterAnimState.IDLE;

		public CharacterAnimator3D (Actor animationTarget)
		{
			this.gameObject = animationTarget.GameObject;
			this.animation = gameObject.GetComponent<Animation>();
		}

		private bool isLocomotive(String state) {
			return state==CharacterAnimState.RUN || state == CharacterAnimState.IDLE;
		}



		public void RequestState(string stateString) {
			RequestState(stateString, 1, 0, 0f, 0, 1f);
		}

		public void RequestState (string stateString, int activationPriority = 1, int runningPriority = 0, float startTime = 0f, int animName = 0, float animSpeed = 1f)
		{
			if(isLocomotive(stateString)) {
				if(currentLocomotive != stateString) {
					animation[stateString].layer = 0;

					animation.CrossFade(stateString, .1f, PlayMode.StopSameLayer);
					currentLocomotive = stateString;
				}

			} else {

				animation.Play (stateString, PlayMode.StopSameLayer);
				animation[stateString].layer = 1;				
			}
		}



		
	}
}
