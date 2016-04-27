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


		public static RoomData LURCH_START {
			get {
				var ret = new RoomData ();
				ret.Id = 100;
				ret.SortOrder = 0;
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "                                                                                     ";
				ret.AsciiMap += "            L              L                L                L            L      L   ";
				ret.AsciiMap += "                                                                                    d";
				ret.AsciiMap += "                               @               1                                     ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.MaxInstances = 1;
				ret.AsciiSpawnLookup['1'] = MockActorData.RANDOM_WEAPON_PICKUP;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData DEBUG_ROOM {

			get {
				var ret = new RoomData();
				ret.Id = 2;
				ret.Mute = true;
				ret.AsciiMap += "                                            ";
				ret.AsciiMap += "                                            ";
				ret.AsciiMap += "                                            ";
				ret.AsciiMap += "                                            ";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "  L                                        w";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "                         cccccc     3      w";
				ret.AsciiMap += "      ppppppppp          cccccc            w";
				ret.AsciiMap += "     L                               L     5";
				ret.AsciiMap += "                                           5";
				ret.AsciiMap += "                            L              w";
				ret.AsciiMap += "                                           w";
				ret.AsciiMap += "         4                                 w";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff2222ffffff";
					

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.SPIKES;
				//ret.AsciiSpawnLookup['3'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);
				ret.AsciiSpawnLookup['4'] = MockActorData.FIXED_PICKUP;
				//ret.AsciiSpawnLookup['5'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.left);
				finalize(ret);

				return ret;
			}

		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 101;
				ret.AsciiMap += "wccccccccccccccccccccccccc d cccccccccccccccccccccw";
				ret.AsciiMap += "w                                                  ";
				ret.AsciiMap += "w                                                 d";
				ret.AsciiMap += "w                       L                          ";
				ret.AsciiMap += "w                 pppppppppppp        PPPPPPPPPPPPw";
				ret.AsciiMap += "w                                   ffffffffffffffw";
				ret.AsciiMap += "w                                 PPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "wppppppppppp                                L     w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w        2             1                          w";
				ret.AsciiMap += "w                     ppppppppppp    pppppppppppppw";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "            L                                     w";
				ret.AsciiMap += "d                                                 w";
				ret.AsciiMap += "                                      1           w";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_2 {
			get {
				var ret = new RoomData ();
				ret.Id = 102;
				ret.AsciiMap += "wccccccccccccccccccccccccc d cccccccccccccccccccccw";
				ret.AsciiMap += "                                                   ";
				ret.AsciiMap += "d                                   2             d";
				ret.AsciiMap += "                        L                          ";
				ret.AsciiMap += "wPPPPPPPPPPPPP          ppppppp       PPPPPPPPPPPPw";
				ret.AsciiMap += "w                                   ffffffffffffffw";
				ret.AsciiMap += "w                                 PPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w           2                                     w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                PPPPPPPPPPPPPPPPPPPPPPPPPPpppppppw";
				ret.AsciiMap += "w                                           L     w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w        2      1                                 w";
				ret.AsciiMap += "w       PPPPPPPPPPP                  PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "            L                                     w";
				ret.AsciiMap += "d                                                 w";
				ret.AsciiMap += "                                      1           w";
				ret.AsciiMap += "fffffffffffffffffffffffff d fffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_3 {
			get {
				var ret = new RoomData ();
				ret.Id = 103;
				ret.AsciiMap += "wccccccc d ccccccccccccccccccccccccccccccccc d cccw";
				ret.AsciiMap += "                                                  w";
				ret.AsciiMap += "d                                                 w";
				ret.AsciiMap += "                        L                         w";
				ret.AsciiMap += "w     PPPPPPPPPPPPPPPPP    pppp                   w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                      PPPPPPPPPPPw";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                          PPPPPPPPP        L     w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w               1                            2    w";
				ret.AsciiMap += "w       PPPPPPPPPPP                  PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w           L                                     w";
				ret.AsciiMap += "w                                                 w";
				ret.AsciiMap += "w                                     1           w";
				ret.AsciiMap += "fffffffffffffffffffffffff d fffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.RANDOM_WEAPON_PICKUP;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_4 {
			get {
				var ret = new RoomData ();
				ret.Id = 104;
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffff d f";
				ret.AsciiMap += "w                                                    w";
				ret.AsciiMap += "f L          2                      L                f";
				ret.AsciiMap += "w                                                    w";
				ret.AsciiMap += "f                                                    f";
				ret.AsciiMap += "w            wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww";
				ret.AsciiMap += "f          fffffffffffffffffffffffffffffffffffffffTfff";
				ret.AsciiMap += "w                              L                     w";
				ret.AsciiMap += "f                                                    f";
				ret.AsciiMap += "w                                                    w";
				ret.AsciiMap += "f          2                                         f";
				ret.AsciiMap += "w   1                                                w";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffTfffpppppw";
				ret.AsciiMap += "w                                              L     w";
				ret.AsciiMap += "w                                                    f";
				ret.AsciiMap += "w                                                    w";
				ret.AsciiMap += "w                   1                                f";
				ret.AsciiMap += "w                                                 C  w";
				ret.AsciiMap += "ffff d ffffffffffffffffffffffffffffffffffssssssfffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;
				ret.AsciiSpawnLookup['C'] = MockActorData.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['T'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_5 {
			get {
				var ret = new RoomData ();
				ret.Id = 105;
				ret.AsciiMap += "wccccccTccccccccccccccc d ccccccccccTccTcccccccw";
				ret.AsciiMap += "w                    L                         w";
				ret.AsciiMap += "w      2                                   2   w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPPPPPpppppp      PPPPPPw";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "        L                           L           ";
				ret.AsciiMap += "d                                              d";
				ret.AsciiMap += "                                                ";
				ret.AsciiMap += "wPP                            1            PPPw";
				ret.AsciiMap += "w              PPPPPPPPPPPPPPPPPPPPPP          w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "wPPPPPP                                        w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w            L                                 w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                            C                 w";
				ret.AsciiMap += "fffffffffffffffsssssssssssfffffffssssssfffffffff";
				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;
				ret.AsciiSpawnLookup['C'] = MockActorData.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['T'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_6 {
			get {
				var ret = new RoomData ();
				ret.Id = 106;
				ret.AsciiMap += "wccccccTcccTccc d cw";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w      2       2   w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w            ppppppw";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "        L           ";
				ret.AsciiMap += "d             L    d";
				ret.AsciiMap += "                    ";
				ret.AsciiMap += "wPP             PPPw";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w      L           w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "wpppppp            w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w               PPPw";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "fffffffffssfffffffff";
				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;
				ret.AsciiSpawnLookup['C'] = MockActorData.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['T'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_7 {
			get {
				var ret = new RoomData ();
				ret.Id = 107;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                     w";
				ret.AsciiMap += "w                                     w";
				ret.AsciiMap += "w                                     w";
				ret.AsciiMap += "w                                     w";
				ret.AsciiMap += "w                                     w";
				ret.AsciiMap += "w                                     w";
				ret.AsciiMap += "                                       ";
				ret.AsciiMap += "d                   L                 d";
				ret.AsciiMap += "                    1            2     ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.SHOPKEEPER;
				ret.AsciiSpawnLookup['2'] = MockActorData.RANDOM_WEAPON_PICKUP;
				finalize(ret);

				return ret;
			}
		}

		static void finalize(RoomData room) {
			room.Width = room.AsciiMap.Width;
			room.Height = room.AsciiMap.Height;

			addDoorsFromAscii (room);
			addSpawnsFromAscii (room);
		}

		static void addSpawnsFromAscii (RoomData room)
		{
			var extractor = new AsciiMeshExtractor(room.AsciiMap);
			foreach( var spawnType in room.AsciiSpawnLookup) {
				foreach( Vector3 match in extractor.getAllMatching(spawnType.Key, true)) {
					var spawn = new RoomData.Spawn(spawnType.Value.Data);
					spawn.X = match.x;
					spawn.Y = match.y;
					spawn.SpawnType = RoomSpawnType.FirstRoomEntrance;
					spawn.Facing = spawnType.Value.Facing;
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

