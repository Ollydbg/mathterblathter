using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Data
{
	public static class MockMapData
	{

		private static Dictionary<int, MapData> _all;
		static void StaticInit() {
			_all = typeof(MockMapData).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as MapData)
				.ToDictionary(p => p.Id, p=>p);

		}

		public static MapData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
		}

		public static MapData Map1 {
			get {
				var ret = new MapData();
				ret.ResourcePath = "Maps/Map1";
				ret.Id = 1;
				ret.ReadScale = 1f;
				ret.NumberOfRooms = 20;
				return ret;
			}
		}
	}
}

