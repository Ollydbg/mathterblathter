using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Client.Game.Data
{
	
	public static class MapDataTable
	{

		private static Dictionary<int, MapData> _all;
		static void StaticInit() {
			_all = typeof(MapDataTable).GetProperties()
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

				ret.Zones.Add(ZoneDataTable.DEBUG_ZONE);
				ret.Zones.Add(ZoneDataTable.ZONE_1);
				//ret.Zones.Add(ZoneDataTable.ZONE_1_BOSS);
				//ret.Zones.Add(ZoneDataTable.ZONE_2);
				//ret.Zones.Add(ZoneDataTable.ZONE_3);
				//ret.Zones.Add(ZoneDataTable.ZONE_4);


				return ret;
			}
		}
	}
}

