using System;
using UnityEngine;

namespace Client.Game.UI
{
	public class PauseScreen : RunUI
	{
		public PauseScreen ()
		{
		}

		void Awake () {
			Game.UIManager.PauseScreen = this;
			Hide();
		}

		#region implemented abstract members of RunUI
		private bool showing = false;
		public void Toggle() {
			if(showing)
				Hide();
			else 
				Show();
		}

		public override void Show ()
		{
			Game.Paused = true;
			showing = true;
			Time.timeScale = 0f;
			gameObject.SetActive(true);
		}

		public override void Hide ()
		{

			Game.Paused = false;
			showing = false;
			Time.timeScale = 1f;
			gameObject.SetActive(false);
		}

		#endregion
	}
}

