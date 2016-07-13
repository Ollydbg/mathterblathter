using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Client.Game.Data
{
	using ZReq = ZoneData.Requirement;
	
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

				var debugZone = new ZoneData();
				debugZone.Solo = true;
				debugZone.Name = "Debug Zone";
				debugZone.Requirements.Add(new ZReq(RoomDataTable.LURCH_START, 1, ZoneData.Occurance.Guaranteed));
				debugZone.DrawColor = new Color(.45f, .33f, .40f);
				debugZone.MaxRooms = 1;
				ret.Zones.Add(debugZone);


				var zone1 = new ZoneData();
				zone1.Id = 0;
				zone1.Name = "New Parish";
				zone1.Requirements.Add(new ZReq(RoomType.LurchStart, 1, ZoneData.Occurance.Guaranteed));
				zone1.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone1.Requirements.Add(new ZReq(RoomType.Normal, 20, ZoneData.Occurance.Guaranteed));
				zone1.DrawColor = new Color(.45f, .33f, .40f);
				zone1.MaxRooms = 25;
				ret.Zones.Add(zone1);


				var z1b = new ZoneData();
				z1b.Id = 1;
				z1b.MaxRooms = 1;
				z1b.Name = "Prophet 5";
				z1b.Requirements.Add(new ZReq(RoomDataTable.BOSS_FIGHT_1, 1, ZoneData.Occurance.Guaranteed));
				z1b.DrawColor = new Color(.65f, .23f, .30f);

				ret.Zones.Add(z1b);



				var zone2 = new ZoneData();
				zone2.Id = 2;
				zone2.Name = "The Vestry";
				zone2.Requirements.Add(new ZReq(RoomType.Normal, 20, ZoneData.Occurance.Guaranteed));
				zone2.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone2.MaxRooms = 20;
				zone2.DrawColor = new Color(.55f, .43f, .20f);

				ret.Zones.Add(zone2);


				var zone3 = new ZoneData();
				zone3.Id = 4;
				zone3.Name = "Power Center";
				zone3.Requirements.Add(new ZReq(RoomType.Normal, 20, ZoneData.Occurance.Guaranteed));
				zone3.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone3.MaxRooms = 20;
				zone3.DrawColor = new Color(.65f, .33f, .20f);

				ret.Zones.Add(zone3);



				var zone4 = new ZoneData();
				zone4.Id = 6;
				zone4.Name = "The Lab";
				zone4.Requirements.Add(new ZReq(RoomType.Normal, 15, ZoneData.Occurance.Guaranteed));
				zone4.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone4.DrawColor = new Color(.25f, .53f, .30f);

				zone4.MaxRooms = 20;
				ret.Zones.Add(zone4);


				return ret;
			}
		}
	}
}

