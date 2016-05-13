using System;
using Client.Game.UI.Run;
using UnityEngine;
using Client.Game.States;


namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class UIManager : IGameManager
	{
		public DepthMeter DepthMeter;
		public InteractionPrompt InteractionPrompt;
		public PlayerStatsHud StatsHud;
		public ZoneTitle ZoneTitle;
		public ShopUI ShopUI;

		private static String RUN_RESOURCE = "UI/RunUI";
		private static String GENERATION_RESOURCE = "UI/MapGenerationUI";

		public GameObject CurrentUI;

		public void SetPlayerCharacter (Client.Game.Actors.PlayerCharacter player)
		{
		}

		public UIManager (Game game)
		{
			game.States.OnStateChanged += HandleState;
		}


		public void Start (Game game)
		{
			

		}

		void HandleState (State from, State to)
		{

			TearDown(CurrentUI);

			if(to is GenerateMapState) {
				this.CurrentUI = (GameObject)GameObject.Instantiate(Resources.Load(GENERATION_RESOURCE));
			}

			if(to is RunState) {
				this.CurrentUI = (GameObject)GameObject.Instantiate(Resources.Load(RUN_RESOURCE));
			}


		}


		public void Update (float dt)
		{
			
		}

		void TearDown(GameObject ui) {

			if(ui != null) {
				UnityEngine.GameObject.Destroy(ui);
			}

		}

		public void Shutdown ()
		{
			
		}

	}
}

