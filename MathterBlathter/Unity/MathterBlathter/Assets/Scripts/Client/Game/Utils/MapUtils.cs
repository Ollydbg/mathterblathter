using System;
using Client.Game.Data;
using Client.Game.Map;

namespace Client.Game.Utils
{
	public static class MapUtils
	{
		public static ZoneData ZoneForRoom(Room room, MapData mapData) {
			return ZoneForXY(room.X, room.Y, mapData);
		}

		public static ZoneData ZoneForXY(int x, int y, MapData mapData) {
			foreach( var zone in mapData.Zones) {
				if(x >= zone.MinX
					&& x <= zone.MaxX
					&& y >= zone.MinElevation
					&& y <= zone.MaxElevation) {
					return zone;
				}
			}
			return mapData.Zones[0];
		}
	}
}

