using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Game.UI.Titles
{
	public class TitleScreen : MonoBehaviour
	{
		public string RunScene = "MainScene";

		void Awake() {}
		void Start() {}

		public void NewRun() {
			SceneManager.LoadScene(RunScene);
		}

		public void Daily() {

		}

		public void Tutorial() {

		}
		public void Stats() {

		}

		public void Options() {

		}

	}
}

