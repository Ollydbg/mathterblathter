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
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "                                                                        ";
				ret.AsciiMap += "            L              L                L               L       L   ";
				ret.AsciiMap += "                                                                       d";
				ret.AsciiMap += "                               @               1                        ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

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
				ret.AsciiMap += "                                                ";
				ret.AsciiMap += "                                                ";
				ret.AsciiMap += "                                                ";
				ret.AsciiMap += "                                                ";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                          1    w";
				ret.AsciiMap += "           L                    PPPPPPPPPPPPPPPw";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                 L             w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "     L                                         w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "                                      L        w";
				ret.AsciiMap += "                                               w";
				ret.AsciiMap += "           2    3         4     5              w";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffsfffffffffff";
					

				//ret.AsciiSpawnLookup['1'] = MockActorData.SNIPER;
				ret.AsciiSpawnLookup['3'] = MockActorData.WAVE_GUN;
				ret.AsciiSpawnLookup['2'] = MockActorData.HOT_RAILS;
				ret.AsciiSpawnLookup['4'] = MockActorData.RUSTY_REPEATER;
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;
				ret.AsciiSpawnLookup['T'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);
				finalize(ret);

				return ret;
			}

		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 101;
				ret.AsciiMap += "wcccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccw";
				ret.AsciiMap += "w                                                               ";
				ret.AsciiMap += "w                                                              d";
				ret.AsciiMap += "w                                    L                          ";
				ret.AsciiMap += "w                              wwwwwwwwwwww        PPPPPPPPPPPPw";
				ret.AsciiMap += "w                       PPPPPPPPPPPPPPPPPPP      ffffffffffffffw";
				ret.AsciiMap += "w                 PPPPPP                       PPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "wppppppppppp                                             L     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                PPPPPPPPP     2                               w";
				ret.AsciiMap += "w               L                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "fffffffffffff                                                  w";
				ret.AsciiMap += "wwwwwwwwwwwwwww                                                w";
				ret.AsciiMap += "ffffffffffffffffffff               ppppppppppp    pppppppppppppw";
				ret.AsciiMap += "ffffffffffffffffffff                1                          w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                    L         w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "            L                                                  w";
				ret.AsciiMap += "d                                                              w";
				ret.AsciiMap += "                                                   1           w";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

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
				ret.AsciiMap += "wcccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccw";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d            2                                   2             d";
				ret.AsciiMap += "                                     L                          ";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPP                 ppppppp       PPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                ffffffffffffffw";
				ret.AsciiMap += "w                                              PPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w           2                                                  w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                    PPPPPPPP                                  w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                             PPPPPPPPPPPPPPPPPPPPPPPPPPpppppppw";
				ret.AsciiMap += "w                                                        L     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w        2      1                                              w";
				ret.AsciiMap += "w       PPPPPPPPPPP                               PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "            L                                                  w";
				ret.AsciiMap += "d                                                              w";
				ret.AsciiMap += "                                                   1           w";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";

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
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                               w";
				ret.AsciiMap += "d                                                              w";
				ret.AsciiMap += "                        L                                      w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPP        PPPPPPPPPpppp              pppppw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w               1                                         2    w";
				ret.AsciiMap += "w       PPPPPPPPPPP                               PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w           L                                                   ";
				ret.AsciiMap += "w                                                              d";
				ret.AsciiMap += "w                                                  1            ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";

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
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "   L                                                            ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "fPPP         2                                L                f";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "f                                                              f";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "f                    fffffffffffffffffffffffffffffffffffffffffTf";
				ret.AsciiMap += "w              ffffff                    L                     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w    L                                                         w";
				ret.AsciiMap += "wPPPP                                                          w";
				ret.AsciiMap += "wPPPPPPPPP                                                     w";
				ret.AsciiMap += "w        L                                                     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "f                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "f          2                                                   w";
				ret.AsciiMap += "w   1                                                          w";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffTfffpppppw";
				ret.AsciiMap += "w                                                        L     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                            PPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                   1                                          d";
				ret.AsciiMap += "                                  C                             ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffssssssfffffff";

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

				ret.AsciiMap += "wccccccccccccccc d ccccccccccccc";
				ret.AsciiMap += "                               w";
				ret.AsciiMap += "d                              w";
				ret.AsciiMap += "                               w";
				ret.AsciiMap += "w           PPPPPPPPPPPPPPpppppw";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w           L                   ";
				ret.AsciiMap += "w                              d";
				ret.AsciiMap += "w                               ";
				ret.AsciiMap += "ffffffffffffffff d fffffffffffff";


				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_6 {
			get {
				var ret = new RoomData ();
				ret.Id = 106;

				ret.AsciiMap += "cccccccccccccc d ccccccTcccccc d cccccTTcTcTTT d cccccccccccTccc";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                    1                                         w";
				ret.AsciiMap += "w        L                                   L                 w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPppppppw";
				ret.AsciiMap += "w                                                     1        w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w        1                                                     w";
				ret.AsciiMap += "w                                                        ffffffw";
				ret.AsciiMap += "w                                                        ffffffw";
				ret.AsciiMap += "wppppPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                       L       1                              w";
				ret.AsciiMap += "w                                                      1       w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w           1                                                  w";
				ret.AsciiMap += "wpppppppppp                                                    w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                            L                 w";
				ret.AsciiMap += "w          L                                           1       w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "wppppppppppp                                                   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "                                              L                 ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.FLOATING_TURRET;
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

				ret.AsciiMap += "cccccccccccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w             L                 L              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                                              w";
				ret.AsciiMap += "w                       1                      w";
				ret.AsciiMap += "                    wwwwwwwwww                  ";
				ret.AsciiMap += "d                fffffffffffffff               d";
				ret.AsciiMap += "               wwwwwwwwwwwwwwwwwww   2          ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.SHOPKEEPER;
				ret.AsciiSpawnLookup['2'] = MockActorData.RANDOM_WEAPON_PICKUP;
				finalize(ret);

				return ret;
			}
		}


		public static RoomData ROOM_8 {
			get {
				var ret = new RoomData ();
				ret.Id = 108;

				ret.AsciiMap += "cccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w            ppppppppppppppppppppppppppppppppppppppppppppp   w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                      1           1         w";
				ret.AsciiMap += "w               L                                            w";
				ret.AsciiMap += "w               L                                            w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                      wPPPPPPPPP            w";
				ret.AsciiMap += "w                                      w                     w";
				ret.AsciiMap += "w                                      w                     w";
				ret.AsciiMap += "w                                      w                     w";
				ret.AsciiMap += "w                                  ppppw                     w";
				ret.AsciiMap += "w                                      w          PPPPPPPPPPPw";
				ret.AsciiMap += "w                                      w                     w";
				ret.AsciiMap += "w                                      w                     w";
				ret.AsciiMap += "w               L                      w                     w";
				ret.AsciiMap += "w                                      w                 2   w";
				ret.AsciiMap += "w            pppppppppppppppppppppppppppPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "w                                             L              w";
				ret.AsciiMap += "w            pppppppppppppppppppppppppppppppppppppppppppppp  w";
				ret.AsciiMap += "w                                                            w";
				ret.AsciiMap += "                                                              ";
				ret.AsciiMap += "d                                                            d";
				ret.AsciiMap += "                                                              ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.ROCKET_TURRET;
				ret.AsciiSpawnLookup['2'] = MockActorData.RANDOM_WEAPON_PICKUP;
				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_9 {
			get {
				var ret = new RoomData ();
				ret.Id = 109;

				ret.Mute = true;
				ret.AsciiMap += "ccccccccccccccccccccccccc d cccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                   ";
				ret.AsciiMap += "w                                                  d";
				ret.AsciiMap += "w    2                                   2          ";
				ret.AsciiMap += "w  ppppppppppppppppppppppppppppppppppppppppppppppppw";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w     L                                            w";
				ret.AsciiMap += "w                            1          1          w";
				ret.AsciiMap += "w  ppppppppppppppppppppppppppppppppppppppppppppppppw";
				ret.AsciiMap += "w                                      w           w";
				ret.AsciiMap += "w                                      w    L      w";
				ret.AsciiMap += "w                                      w           w";
				ret.AsciiMap += "w                                      w           w";
				ret.AsciiMap += "w                                   L  w 3    1  1 w";
				ret.AsciiMap += "w  ppppppppppppppppppppppppppppppppppppPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "                       L                            ";
				ret.AsciiMap += "d                                                  d";
				ret.AsciiMap += "                                              1     ";
				ret.AsciiMap += "ffffffffffffffffffffffffff d ffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['3'] = MockActorData.RANDOM_WEAPON_PICKUP;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_10 {
			get {
				var ret = new RoomData ();
				ret.Id = 110;

				ret.Mute = true;
				ret.AsciiMap += "ccccccccccccccccccccccccc d cccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w       2                                  2       w";
				ret.AsciiMap += "w                        PPPPPPPPPPPPPPPPPPPPppppppw";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w         1                                        w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w             1   1                     2          w";
				ret.AsciiMap += "w      1             L            L           pppppw";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w        1                                        L ";
				ret.AsciiMap += "w                                                  d";
				ret.AsciiMap += "w                                                   ";
				ret.AsciiMap += "w                                     PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                            L                     w";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffff d ffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.ROCKET_LAUNCHER;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_11 {
			get {
				var ret = new RoomData();
				ret.Id = 111;

				ret.Mute = true;
				ret.AsciiMap += "ccccccccccccccccccccccccc d cccccccccccccccccccccccc";
				ret.AsciiMap += "                                                   w";
				ret.AsciiMap += "d   L                                              w";
				ret.AsciiMap += "                                                   w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP            w";
				ret.AsciiMap += "wPPPPTPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP            w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w              L                             L      ";
				ret.AsciiMap += "w                                                  d";
				ret.AsciiMap += "w                                                   ";
				ret.AsciiMap += "w                                     PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w         2                                        4";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                       L          w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w                                                  w";
				ret.AsciiMap += "w     1                                            w";
				ret.AsciiMap += "fffffffffffffsssssssssffffffffffffff d ffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.MAX_HEALTH_BOOST;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['T'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);
				ret.AsciiSpawnLookup['4'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.right);
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;


				return ret;
			}
		}

		public static RoomData ROOM_12 {
			get {
				var ret = new RoomData();
				ret.Id = 112;

				ret.Mute = true;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccccccccccccc d cccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                   w";
				ret.AsciiMap += "d   L                                                              w";
				ret.AsciiMap += "                                                                   w";
				ret.AsciiMap += "w                                                                  w";
				ret.AsciiMap += "w                                                                  w";
				ret.AsciiMap += "w                                                                  w";
				ret.AsciiMap += "w                                                                  w";
				ret.AsciiMap += "w              L                                             L      ";
				ret.AsciiMap += "w                                                                  d";
				ret.AsciiMap += "w                                                                   ";
				ret.AsciiMap += "w                                                     PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                                  w";
				ret.AsciiMap += "w         2                               ccc                      4";
				ret.AsciiMap += "w                                                                  w";
				ret.AsciiMap += "w                                   cc                  L          w";
				ret.AsciiMap += "w                                                                  w";
				ret.AsciiMap += "w              cccccccccccccc                                      w";
				ret.AsciiMap += "w     1        cccccccccccccc                                      w";
				ret.AsciiMap += "fffffffffffffffffffffffffffffsssssssssssssssssssssss d ffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.MAX_HEALTH_BOOST;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['T'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);
				ret.AsciiSpawnLookup['4'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.right);
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;


				return ret;
			}
		}

		static void finalize(RoomData room) {
			room.Width = room.AsciiMap.Width;
			room.Height = room.AsciiMap.Height;

			addDoorsFromAscii (room);
			addSpawnsFromAscii (room);
			Debug.Log("finalizing room: " + room);

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

