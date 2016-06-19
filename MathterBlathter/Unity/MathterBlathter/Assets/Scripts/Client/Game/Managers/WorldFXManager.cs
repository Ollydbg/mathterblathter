using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Map;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;


	public class WorldFXManager : IGameManager
	{
		GameObject weatherObj;
		Game Game;
		public WorldFXManager ()
		{
		}

		#region IGameManager implementation

		public void Start (Game game)
		{
			this.Game = game;
			weatherObj = GameObject.Find("WeatherFX");
			game.RoomManager.OnRoomEntered += OnRoomEntered;

		}

		void OnRoomEntered (Actor actor, Room oldRoom, Room newRoom)
		{
			if(weatherObj != null) {
				var center = newRoom.roomCenter;
				var ceilingCenter = new Vector3(center.x, newRoom.Top, center.z);
				weatherObj.transform.position = ceilingCenter;
			}
		}

		public void Update (float dt)
		{
		}

		public void Shutdown ()
		{
			Game.RoomManager.OnRoomEntered -= OnRoomEntered;
		}

		public void SetPlayerCharacter (PlayerCharacter player)
		{
		}

		#endregion
	}
}

