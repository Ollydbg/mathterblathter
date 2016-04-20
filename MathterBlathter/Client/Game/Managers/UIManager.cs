using System;
using Client.Game.UI.Run;


namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class UIManager : IGameManager
	{
		public DepthMeter DepthMeter;
		public ItemPickupPopup PickupPopup;
		public PlayerStatsHud StatsHud;
		public ZoneTitle ZoneTitle;


		public void SetPlayerCharacter (Client.Game.Actors.PlayerCharacter player)
		{
		}

		public UIManager ()
		{
		}


		public void Start (Game game)
		{
			
		}


		public void Update (float dt)
		{
			
		}

		public void Shutdown ()
		{
			
		}

	}
}

