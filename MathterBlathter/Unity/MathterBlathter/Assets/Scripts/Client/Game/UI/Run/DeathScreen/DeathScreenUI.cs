using System;
using UnityEngine;
using Client.Game.States;

namespace Client.Game.UI.Run.DeathScreen
{
	public class DeathScreenUI : Client.RunUI
	{
		public DeathScreenUI ()
		{
		}

		void Awake() {
			Game.UIManager.DeathScreen = this;
			Hide();
		}

		float timeLeft = 3f;

		void Update() {
			timeLeft -= Time.deltaTime;
			if(timeLeft <= 0f && Input.anyKeyDown) {
				StopConsuming();
				Game.Restart();
			}
		}

		public override void Show ()
		{
			StartConsuming();
			this.gameObject.SetActive(true);
		}

		
		public override void Hide ()
		{
			this.gameObject.SetActive(false);
			StopConsuming();
		}

	}
}

