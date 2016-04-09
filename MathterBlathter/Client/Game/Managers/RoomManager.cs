﻿using System;
using Client.Game.Data;
using Client.Game.Map;
using System.Collections.Generic;

namespace Client.Game.Managers
{
	public class RoomManager : IGameManager
	{

		public List<Room> Rooms;


		public RoomManager ()
		{
			
		}


		public void Init ()
		{
			//make rooms
			var mockedRooms = new RoomDataMocker().Mock(4);
			var generator = new MapGenerator ();
			Rooms = generator.GenerateFromDataSet (mockedRooms);
			Rooms.ForEach (p => p.Draw());
		}

		public void Update (float dt)
		{
			
		}

	}
}
