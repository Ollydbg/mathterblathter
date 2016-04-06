using System;
using System.Collections.Generic;
using Client.Game.Map;
using Client.Game.Data;

namespace Client.Game.Data
{
	public class RoomData : GameData
	{

		public int Width;
		public int Height;
		public List<Door> Doors = new List<Door>();


		public RoomData ()
		{
		}

	}
}

