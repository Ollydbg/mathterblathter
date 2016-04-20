using System;
using Client.Game.UI.Run;
using UnityEngine;


namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class UIManager : IGameManager
	{
		public DepthMeter DepthMeter;
		public ItemPickupPopup PickupPopup;
		public PlayerStatsHud StatsHud;
		public ZoneTitle ZoneTitle;

		private static String Run_Resource = "UI/RunUI";

		public GameObject GameObject;

		public void SetPlayerCharacter (Client.Game.Actors.PlayerCharacter player)
		{
		}

		public UIManager ()
		{
		}


		public void Start (Game game)
		{
			this.GameObject = (GameObject)GameObject.Instantiate(Resources.Load(Run_Resource));
		}


		public void Update (float dt)
		{
			
		}

		public void Shutdown ()
		{
			UnityEngine.GameObject.Destroy(this.GameObject);
			this.GameObject = null;
		}

	}
}

