using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Map.Ascii;
using Client.Game.Map;
using UnityEngine;

namespace Client.Game.Data
{
	public class MockRoomData
	{
		private static Dictionary<int, RoomData> _all;
		static void StaticInit() {
			_all = typeof(MockRoomData).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as RoomData)
				.ToDictionary(p => p.Id, p=>p);

		}

		public static List<RoomData> GetAll() {
			if(_all == null) StaticInit();
			return _all.Values.ToList();
		}


		public static RoomData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
		}


		public static RoomData DEATH_TEST_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 0;

				ret.AsciiMap += "ccccccccccc d ccccccccccccccc";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                            ";
				ret.AsciiMap += "w                           d";
				ret.AsciiMap += "w                            ";
				ret.AsciiMap += "w                       ppppw";
				ret.AsciiMap += "w                       f   w";
				ret.AsciiMap += "w                   ppppp   w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w      L          L         w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "                         L   ";
				ret.AsciiMap += "d                           d";
				ret.AsciiMap += "                      1      ";
				ret.AsciiMap += "fffffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;

				ret.AsciiSpawnLookup['1'] = MockActorData.RANDOM_WEAPON_PICKUP;

				addDoorsFromAscii (ret);
				addSpawnsFromAscii (ret);
				return ret;
			}
		}


		public static RoomData STORE_ROOM_TEST {
			get {
				var ret = new RoomData ();
				ret.Id = 1;

				ret.AsciiMap += "ccccccccccc d ccccccccccccccc";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w         L                 w";
				ret.AsciiMap += "w                          L ";
				ret.AsciiMap += "w                           d";
				ret.AsciiMap += "w        ppppppp             ";
				ret.AsciiMap += "w                       ppppw";
				ret.AsciiMap += "w                       f   w";
				ret.AsciiMap += "w  L                ppppp   w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "         L      L          L ";
				ret.AsciiMap += "d                           d";
				ret.AsciiMap += "             1               ";
				ret.AsciiMap += "fffffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;

				ret.AsciiSpawnLookup['1'] = MockActorData.SHOPKEEPER;

				addDoorsFromAscii (ret);
				addSpawnsFromAscii (ret);
				return ret;
			}
		}



		public static RoomData TALL_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 2;

				ret.AsciiMap += "ccccccccccccccc d ccccccccccccccccccc";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w             fff                   w";
				ret.AsciiMap += "w             pppppppp              w";
				ret.AsciiMap += "w                         L         w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                              1    w";
				ret.AsciiMap += "w                        pppppppppp w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w    L       ppppppppppp            w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wpppppppppp                         w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w         pppppppppppppppppp        w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "                                     ";
				ret.AsciiMap += "d      L                     L      d";
				ret.AsciiMap += "                                     ";
				ret.AsciiMap += "wpppppppp                   ppppppppw";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w     1                             w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w      L      L      L      L       w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wp                                  w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wppp                                w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wppppppppppppppppppppppp            w";
				ret.AsciiMap += "  L                             L   w";
				ret.AsciiMap += "d                                   w";
				ret.AsciiMap += "                                    w";
				ret.AsciiMap += "fffffffffffffffffffffffffffff d fffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;

				addDoorsFromAscii (ret);
				addSpawnsFromAscii(ret);
				return ret;
			}
		}


	


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 4;

				ret.AsciiMap += "cccccccccccccccccccccc d cccccccccccccccccccccc";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w    1                                        w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                              ";
				ret.AsciiMap += "w                                             d";
				ret.AsciiMap += "w                                              ";
				ret.AsciiMap += "w                    L      L            pppppw";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "                        ppppp            L     ";
				ret.AsciiMap += "d                       fffff                 d";
				ret.AsciiMap += "               pppppppppppppp                  ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff d ffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				addDoorsFromAscii (ret);
				addSpawnsFromAscii(ret);
				return ret;
			}
		}

		public static RoomData ROOM_2 {
			get {
				var ret = new RoomData ();
				ret.Id = 5;
				ret.AsciiMap += "ccccccccccc d ccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w             L                     1         w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "         pppppppp                             w";
				ret.AsciiMap += "d                                             w";
				ret.AsciiMap += "                                              w";
				ret.AsciiMap += "wppp                                          w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "wpppppppppp                                 ppw";
				ret.AsciiMap += "                                 L             ";
				ret.AsciiMap += "d                                             d";
				ret.AsciiMap += "                                               ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff d ffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				addDoorsFromAscii (ret);
				addSpawnsFromAscii(ret);
				return ret;
			}
		}

		static void addSpawnsFromAscii (RoomData room)
		{
			var extractor = new AsciiMeshExtractor(room.AsciiMap);
			foreach( var spawnType in room.AsciiSpawnLookup) {
				foreach( Vector3 match in extractor.getAllMatching(spawnType.Key, true)) {
					var spawn = new RoomData.Spawn(spawnType.Value);
					spawn.X = match.x;
					spawn.Y = match.y;
					room.Spawns.Add(spawn);
				}
			}
		}


		static void addDoorsFromAscii (RoomData room)
		{
			//this really needs a floodfill instead
			var extractor = new AsciiMeshExtractor (room.AsciiMap);
			var matches = extractor.getAllMatching (AsciiMap.DOOR);
			foreach (Vector3 doorPos in matches) {
				var link = new RoomData.Link ();
				link.Height = 1;
				link.Width = 1;
				link.X = (int)doorPos.x;
				link.Y = (int)doorPos.y;

				if (link.X == 0) {
					link.Side = DoorRoomSide.Left;
					link.Width = 1;
					link.Height = 3;
				} else if (link.Y == 0) {
					link.Side = DoorRoomSide.Bottom;
					link.Width = 3;
					link.Height = 1;
				} else if (link.X == room.Width-1) {
					link.Side = DoorRoomSide.Right;
					link.Width = 1;
					link.Height = 3;
				} else {

					link.Side = DoorRoomSide.Top;
					link.Width = 3;
					link.Height = 1;
				}

				room.Doors.Add (link);

			}
		}

	}
}

