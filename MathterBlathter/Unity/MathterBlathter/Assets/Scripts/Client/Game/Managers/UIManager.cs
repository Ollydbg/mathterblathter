using System;
using Client.Game.UI.Run;
using UnityEngine;
using Client.Game.States;
using Client.Game.UI.Run.Indicators;
using Client.Game.UI.Run.Shop;
using Client.Game.UI;
using System.Collections.Generic;
using Client.Game.UI.Run.DeathScreen;


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
		public Indicators Indicators;
		public PauseScreen PauseScreen;
		public MiniMap MiniMap;
		public DeathScreenUI DeathScreen;

		private static string RUN_RESOURCE = "UI/RunUI";
		private static string GENERATION_RESOURCE = "UI/MapGenerationUI";

		private List<RunUI> Consumers = new List<RunUI>();

		public void AddInputConsumer(RunUI consumer) {
			Consumers.Add(consumer);
		}
		public void RemoveInputConsumer(RunUI consumer) {
			Consumers.Remove(consumer);
		}

		public GameObject CurrentUI;

		public void SetPlayerCharacter (Client.Game.Actors.PlayerCharacter player)
		{
		}

		public UIManager (Game game)
		{
			game.States.OnStateChanged += HandleState;

		}

		public bool TryConsume() {
			return Consumers.Count != 0;
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

