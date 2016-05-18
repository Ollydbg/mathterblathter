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

		void Update() {
			if(Input.anyKey) {
				SceneManager.LoadScene("MainScene");
			}
		}
	}
}

