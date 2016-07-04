using System;
using System.Collections.Generic;
using System.Linq;

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
				
				var zone1 = new ZoneData();
				zone1.Id = 0;
				zone1.Name = "New Parish";
				zone1.Requirements.Add(new ZReq(RoomType.LurchStart, 1, ZoneData.Occurance.Guaranteed));
				zone1.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone1.Requirements.Add(new ZReq(RoomType.Normal, 20, ZoneData.Occurance.Guaranteed));

				zone1.MinElevation = 0;
				zone1.MaxElevation = 120;
				zone1.MaxRooms = 25;
				ret.Zones.Add(zone1);


				var z1b = new ZoneData();
				z1b.Id = 1;
				z1b.MaxRooms = 1;
				z1b.Name = "Prophet 5";
				z1b.Requirements.Add(new ZReq(RoomDataTable.BOSS_FIGHT_1, 1, ZoneData.Occurance.Guaranteed));
				z1b.MinElevation = 120;
				z1b.MaxElevation = 150;
				ret.Zones.Add(z1b);

				/*

				var zone2 = new ZoneData();
				zone2.Id = 2;
				zone2.Name = "The Vestry";
				zone2.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone2.Requirements.Add(new ZReq(RoomType.Terminal, 2, ZoneData.Occurance.Optional));
				zone2.MinElevation = 200;
				zone2.MaxElevation = 250;
				zone2.MaxRooms = 20;
				ret.Zones.Add(zone2);
				
				var zone3 = new ZoneData();
				zone3.Id = 4;
				zone3.Name = "Power Center";
				zone3.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone3.Requirements.Add(new ZReq(RoomType.Terminal, 2, ZoneData.Occurance.Optional));
				zone3.MinElevation = 250;
				zone3.MaxElevation = 400;
				zone3.MaxRooms = 20;
				ret.Zones.Add(zone3);

				var zone4 = new ZoneData();
				zone4.Id = 6;
				zone4.Name = "The Lab";
				zone4.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone4.Requirements.Add(new ZReq(RoomType.Terminal, 2, ZoneData.Occurance.Optional));
				zone4.MinElevation = 400;
				zone4.MaxElevation = 600;
				zone4.MaxRooms = 20;
				ret.Zones.Add(zone4);

				*/
				return ret;
			}
		}
	}
}

