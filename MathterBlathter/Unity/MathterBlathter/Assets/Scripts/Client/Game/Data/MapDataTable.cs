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
				ret.MaxRooms = 40;
				
				var lurchZone = new ZoneData();
				lurchZone.Id = 0;
				lurchZone.Name = "The Lurch";
				lurchZone.Requirements.Add(new ZReq(RoomType.LurchStart, 1, ZoneData.Occurance.Guaranteed));
				lurchZone.Requirements.Add(new ZReq(RoomDataTable.BOSS_FIGHT_1, 1, ZoneData.Occurance.Guaranteed));
				lurchZone.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				lurchZone.Requirements.Add(new ZReq(RoomType.WeaponRoom | RoomType.ItemRoom, 1, ZoneData.Occurance.Guaranteed));
				
				lurchZone.Requirements.Add(new ZReq(RoomType.Terminal, 2, ZoneData.Occurance.Optional));

				lurchZone.MinElevation = 0;
				lurchZone.MaxElevation = 120;
				ret.Zones.Add(lurchZone);
				
				
				var zone1 = new ZoneData();
				zone1.Id = 1;
				zone1.Name = "The Vestry";
				zone1.Requirements.Add(new ZReq(RoomDataTable.BOSS_FIGHT_1, 1, ZoneData.Occurance.Guaranteed));
				zone1.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone1.Requirements.Add(new ZReq(RoomType.Terminal, 2, ZoneData.Occurance.Optional));
				zone1.MinElevation = 120;
				zone1.MaxElevation = 250;
				ret.Zones.Add(zone1);
				
				var zone2 = new ZoneData();
				zone2.Id = 2;
				zone2.Name = "New Parish";
				zone2.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone2.Requirements.Add(new ZReq(RoomType.Terminal, 2, ZoneData.Occurance.Optional));
				zone2.MinElevation = 250;
				zone2.MaxElevation = 400;
				ret.Zones.Add(zone2);

				var zone3 = new ZoneData();
				zone3.Id = 3;
				zone3.Name = "The Temple";
				zone3.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				zone3.Requirements.Add(new ZReq(RoomType.Terminal, 2, ZoneData.Occurance.Optional));
				zone3.MinElevation = 400;
				zone3.MaxElevation = 600;
				ret.Zones.Add(zone3);
				
				
				return ret;
			}
		}
	}
}

