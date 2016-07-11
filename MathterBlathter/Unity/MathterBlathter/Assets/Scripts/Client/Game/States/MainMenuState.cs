using System;
using UnityEngine.SceneManagement;

namespace Client.Game.States
{
	public class MainMenuState : State
	{
		public MainMenuState ()
		{
		}

		#region implemented abstract members of State

		public override void Enter ()
		{
			SceneManager.LoadSceneAsync("MainMenu");
		}

		public override void Exit ()
		{
			
		}

		public override void Update (float dt)
		{
			
		}

		#endregion
	}
}

