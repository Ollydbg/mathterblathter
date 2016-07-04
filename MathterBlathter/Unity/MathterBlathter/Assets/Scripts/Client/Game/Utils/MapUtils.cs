using System;
using Client.Game.Data;
using Client.Game.Map;

namespace Client.Game.Utils
{
	public static class MapUtils
	{
		public static ZoneData ZoneForRoom(Room room, MapData mapData) {
			return room.Zone;
		}

	}
}

