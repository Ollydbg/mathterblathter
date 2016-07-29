using System;
using UnityEngine;

namespace Client.Game.Data
{
	using ZReq = ZoneData.Requirement;

	public static class ZoneDataTable
	{

		public static ZoneData DEBUG_ZONE {
			get {
				var ret = new ZoneData();
				ret.Solo = true;
				ret.Name = "Debug Zone";
				ret.Requirements.Add(new ZReq(RoomDataTable.DEBUG_ROOM, 1, ZoneData.Occurance.Guaranteed));
				ret.Difficulty = 3;
				ret.DrawColor = new Color(.45f, .33f, .40f);
				ret.MaxRooms = 3;
				return ret;
			}
		}

		public static ZoneData ZONE_1 {
			get {
				var ret = new ZoneData();
				ret.Name = "New Parish";
				ret.Requirements.Add(new ZReq(RoomType.LurchStart, 1, ZoneData.Occurance.Guaranteed));
				ret.Requirements.Add(new ZReq(RoomType.Normal, 30, ZoneData.Occurance.Guaranteed));
				ret.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));

				ret.DrawColor = new Color(.45f, .33f, .40f);
				ret.MaxRooms = 25;
				ret.Difficulty = 4;
				return ret;
			}
		}


		public static ZoneData ZONE_1_BOSS {
			get {
				var ret = new ZoneData();
				ret.Id = 1;
				ret.MaxRooms = 1;
				ret.Name = "Prophet 5";
				ret.Requirements.Add(new ZReq(RoomDataTable.BOSS_FIGHT_1, 1, ZoneData.Occurance.Guaranteed));
				ret.DrawColor = new Color(.65f, .23f, .30f);

				return ret;
			}
		}


		public static ZoneData ZONE_2 {
			get {
				var ret = new ZoneData();
				ret.Id = 2;
				ret.Name = "The Vestry";
				ret.Requirements.Add(new ZReq(RoomType.Normal, 20, ZoneData.Occurance.Guaranteed));
				//ret.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				ret.MaxRooms = 20;
				ret.DrawColor = new Color(.55f, .43f, .20f);
				ret.Difficulty = 10;
				return ret;
			}
		}

		public static ZoneData ZONE_3 {
			get {
				var ret = new ZoneData();
				ret.Id = 4;
				ret.Name = "Power Center";
				ret.Requirements.Add(new ZReq(RoomType.Normal, 20, ZoneData.Occurance.Guaranteed));
				//ret.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				ret.MaxRooms = 20;
				ret.DrawColor = new Color(.65f, .33f, .20f);
				ret.Difficulty = 14;
				return ret;
			}
		}

		public static ZoneData ZONE_4 {
			get {
				var ret = new ZoneData();
				ret.Id = 6;
				ret.Name = "The Lab";
				ret.Requirements.Add(new ZReq(RoomType.Normal, 15, ZoneData.Occurance.Guaranteed));
				//ret.Requirements.Add(new ZReq(RoomType.Store, 1, ZoneData.Occurance.Guaranteed));
				ret.DrawColor = new Color(.25f, .53f, .30f);
				ret.Difficulty = 18;
				ret.MaxRooms = 20;
				return ret;
			}
		}

	}
}

