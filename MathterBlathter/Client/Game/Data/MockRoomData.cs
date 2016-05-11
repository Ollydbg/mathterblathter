using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Data.Ascii;
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
				ret.Type = RoomType.LurchStart;
				ret.SortOrder = 0;
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "                                                                       w";
				ret.AsciiMap += "            L              L                L               L       L   ";
				ret.AsciiMap += "                                               1     2                 d";
				ret.AsciiMap += "                               @                                        ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.MaxInstances = 1;
				ret.AsciiSpawnLookup['1'] = MockActorData.STATIC_REPEATER;
				ret.AsciiSpawnLookup['2'] = MockActorData.RUST_MACHINE;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData DEBUG_ROOM {

			get {
				var ret = new RoomData();
				ret.Id = 2;
				ret.Mute = true;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccccc";
                ret.AsciiMap += "                                                                 ";
                ret.AsciiMap += "d                                                               d";
                ret.AsciiMap += "                                                                 ";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                  L                           L                w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                pppppppppppp                                   w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                   L                                           w";
                ret.AsciiMap += "w             ppppppppppppp                                     w";
                ret.AsciiMap += "w                                              L                w";
                ret.AsciiMap += "                                                                 ";
                ret.AsciiMap += "d                                        R                      d";
                ret.AsciiMap += "                          1                                      ";
                ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffw";
					
				ret.AsciiSpawnLookup['H'] = MockActorData.RUSTY_SHIELD;
				ret.AsciiSpawnLookup['R'] = MockActorData.STATIC_REPEATER;

				ret.AsciiSpawnLookup['1'] = MockActorData.SHOPKEEPER;

				//ret.AsciiSpawnLookup['R'] = new RoomData.AsciiPlacement(MockActorData.WALL_TURRET, Vector3.right);

				
				finalize(ret);

				return ret;
			}

		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 101;

				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
                ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                     L                          ";
				ret.AsciiMap += "w                              wwwwwwwwwwww        PPPPPPPPPPPPw";
				ret.AsciiMap += "w                       PPPPPPPPPPPPPPPPPPP      ffffffffffffffw";
				ret.AsciiMap += "w                 PPPPPP                       PPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                 L     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                   PPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                PPPPPPPP      2                               w";
				ret.AsciiMap += "w               L                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "fffffffffffff                                                  w";
				ret.AsciiMap += "wwwwwwwwwwwwwww                                                w";
				ret.AsciiMap += "ffffffffffffffffffff               pppppppppp     pppppppppppppw";
				ret.AsciiMap += "ffffffffffffffffffff                1                          w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                    L         w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "            L                                                   ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                   1            ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";


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
				ret.AsciiMap += "w                    www                                       w";
				ret.AsciiMap += "w                    www                                       w";
				ret.AsciiMap += "w                    PPPPPPPP                                  w";
				ret.AsciiMap += "w                    wwwwwwwwwww                               w";
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
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w        2      1                                          1   w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPP                               PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                 PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                 PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                             fffffffffffffffffw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "            L                                                   ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                   1            ";
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
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                       L                                      w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPP        PPPPPPPPPpppp              pppppw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w               1                                         2    w";
				ret.AsciiMap += "w       PPPPPPPPPPP                               PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w           L                                                  w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                  1           w";
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
				ret.AsciiMap += "fPPP         2                                L            PPPPf";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "f                                                              f";
				ret.AsciiMap += "f                                                              f";
				ret.AsciiMap += "f                                                              f";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                    fffffffffffffffffffffffffffffffffffffffffTf";
				ret.AsciiMap += "w              PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w    L                                                         w";
				ret.AsciiMap += "wffff                                                          w";
				ret.AsciiMap += "wffffwww                                                       w";
				ret.AsciiMap += "wffffwww                                                       w";
				ret.AsciiMap += "wffffwwwffff                                                   w";
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
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                           PPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                   1                                          d";
				ret.AsciiMap += "                                  C                             ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffssssssfffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;
				ret.AsciiSpawnLookup['C'] = MockActorData.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_5 {
			get {
				var ret = new RoomData ();
				ret.Id = 105;

				ret.AsciiMap += "ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                               L                                                            L    ";
				ret.AsciiMap += "d                                                                                               L                               d";
				ret.AsciiMap += "                                                              1                                                                  ";
				ret.AsciiMap += "wf                                             2                                                 2                             fw";
				ret.AsciiMap += "wPPPPP      1                          PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP             PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                                                  PP                                           w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                           2                                                                                                   w";
				ret.AsciiMap += "w                        PPPPPPPPP                                                                                              w";
				ret.AsciiMap += "w                        wwww                                                                                                   w";
				ret.AsciiMap += "wPPPPPPPPPPPPP           wwww                                                                                                   w";
				ret.AsciiMap += "w                        wwww                                                                                                   w";
				ret.AsciiMap += "w                        wwww                                                                                     L             w";
				ret.AsciiMap += "w                        wwww                                                                                                   w";
				ret.AsciiMap += "w                     PPPwwww                                                                                                   w";
				ret.AsciiMap += "w   L                    wwww                                                                                                   w";
				ret.AsciiMap += "w          1             wwww                                                                                                   w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                PPPPPPPPwwww                                                                                                   w";
				ret.AsciiMap += "w                        wwww               L                                                                                   w";
				ret.AsciiMap += "wpppPPPP                 wwww                                 PPPPPPPPPPPPPTTTTPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w                        wwww                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w                        wwww        1                        PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w                        wwww                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w                        wwww                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w                        wwww                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w                        wwww                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "wPPPPP                   wwww                                                                                                   w";
				ret.AsciiMap += "wPPPPP                   wwww                                                                                                   w";
				ret.AsciiMap += "w                        wwww                                                                                                   w";
				ret.AsciiMap += "w                                                                                                                                ";
				ret.AsciiMap += "w                                                           L                                    L                              d";
				ret.AsciiMap += "w                                                                                                                                ";
				ret.AsciiMap += "fffffffffTfffffffffffffffffffffffffffffffffffffffffffffffffffff d ffffffffTTTTfffffffffffffffff d fffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.up);
				ret.AsciiSpawnLookup['1'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['2'] = MockActorData.GROUNDED_RANGED_ENEMY;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_6 {
			get {
				var ret = new RoomData ();
				ret.Id = 106;

				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d     L                                                  L     d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPppppcccw";
				ret.AsciiMap += "w                                                           cccw";
				ret.AsciiMap += "3                                                           cccw";
				ret.AsciiMap += "3                                                           cccw";
				ret.AsciiMap += "3           1                          1                    cccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                          wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                                          wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                  L                       wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                                          wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w         1                                wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                               fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                               fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                               fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                               fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                               fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                   wwwwwwwwwwwwfffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                   wwwwwwwwwwwwfffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                   wwwwwwwwwwwwfffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "wppppPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPTPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "                     L                                          ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "wPPPPPPPTPPPPPP                                       PPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w     1                                         1              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                   L          w";
				ret.AsciiMap += "w                    PPPPPPPPP    PPPPPPPPP                    w";
				ret.AsciiMap += "w          L         ww                  ww                    w";
				ret.AsciiMap += "w               PPPPPww                  wwPPPP                w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    wwppppppppppppppppppww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "wPPPPPP              ww                  ww             PPPPPPPw";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww         1          w";
				ret.AsciiMap += "w                    ww       2          ww                    w";
				ret.AsciiMap += "w                    wwppppppppppppppppppww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w         1          ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                PPPPww                  wwPPPP                w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww               PPPww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "                     ww                  ww                 L   ";
				ret.AsciiMap += "d                    ww     L            ww                    d";
				ret.AsciiMap += "                     ww                  ww                     ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d fffffffffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['2'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);
				ret.AsciiSpawnLookup['3'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.right);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_7 {
			get {
				var ret = new RoomData ();
				ret.Id = 107;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                         L    d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "wP         L                 PPPPPPP2         PPPPPPPPPPPPPPpppw";
				ret.AsciiMap += "w                                              3               w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w             2                                                w";
				ret.AsciiMap += "w                                                       PPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w          pppppppwwwwww                                       w";
				ret.AsciiMap += "w                 wwwwww                              PPPPPPPPPw";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w            PPPPPwwwwww                                       w";
				ret.AsciiMap += "w                 Twwwww   wwwwwwwwUwwwwwwUwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwwwpppwwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwww   Twwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "wPPPPPP           wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w  L         pppppwwwwwwppp                                    w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w                 wwwwww      L                                w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w           PPPPPPwwwwwwpp                                     w";
				ret.AsciiMap += "w                 Twwwww                                       w";
				ret.AsciiMap += "w                 wwwwww                               L       w";
				ret.AsciiMap += "                  wwwwww                                        ";
				ret.AsciiMap += "d                 wwwwww                                       d";
				ret.AsciiMap += "                  wwwwww                    1                   ";
				ret.AsciiMap += "ffffffffffUffffffffffffffffffff d ffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['3'] = MockActorData.ROCKET_TURRET;
				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.left);
				ret.AsciiSpawnLookup['U'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.up);
				

				finalize(ret);

				return ret;
			}
		}


		public static RoomData ROOM_8 {
			get {
				var ret = new RoomData ();
				ret.Mute = true;
				ret.Id = 108;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w              ppppppppppppppppppppppppppppppppppppppppppppp   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                        1           1         w";
				ret.AsciiMap += "w                 L                                            w";
				ret.AsciiMap += "w                 L                                            w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                        wPPPPPPPPP            w";
				ret.AsciiMap += "w                                        w                     w";
				ret.AsciiMap += "w                                        w                     w";
				ret.AsciiMap += "w                                        w                     w";
				ret.AsciiMap += "w                                    ppppw                     w";
				ret.AsciiMap += "w                                        w          PPPPPPPPPPPw";
				ret.AsciiMap += "w                                        w                     w";
				ret.AsciiMap += "w                                        w                     w";
				ret.AsciiMap += "w                 L                      w                     w";
				ret.AsciiMap += "w                                        w                 2   w";
				ret.AsciiMap += "w              ppppppppppppppppppppppppppPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                               L              w";
				ret.AsciiMap += "w              pppppppppppppppppppppppppppppppppppppppppppppp  w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d fffffffffffffffffffffffffffffw";

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
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccccc";
                ret.AsciiMap += "                                                                 ";
                ret.AsciiMap += "d                                        L                      d";
                ret.AsciiMap += "                                                                 ";
                ret.AsciiMap += "w                                                               w";
				ret.AsciiMap += "wpppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppw";
                ret.AsciiMap += "w            L                                                  w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                  2                            w";
                ret.AsciiMap += "w                                                               w";
				ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
				ret.AsciiMap += "w          PPPPPPPPPPP              PPPPPPPPPPPPPPPP            w";
                ret.AsciiMap += "w                                                    L          w";
                ret.AsciiMap += "w                                                               w";
				ret.AsciiMap += "w       2                                                       w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                   L                                        1  w";
				ret.AsciiMap += "w     wwwwwwwwwwwwwppppppppfffffffffffffffffffffssssssssssssffffw";
				ret.AsciiMap += "w     wwwwwwwwwwwww        fffffffffffffffffffffffffffffffffffffw";
                ret.AsciiMap += "w     wwwwwwwwwwwww                                             w";
                ret.AsciiMap += "w     wwwwwwwwwwwww                                             w";
                ret.AsciiMap += "w     wwwwwwwwwwwww   2                                         w";
                ret.AsciiMap += "w     wwwwwwwwwwwww                                             w";
                ret.AsciiMap += "w                                                               w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPPPPPPP          w";
                ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPPPPPPP          w";
                ret.AsciiMap += "w                          ffff                                 w";
                ret.AsciiMap += "w        L                 ffff                                 w";
                ret.AsciiMap += "w                          ffff                             L   w";
                ret.AsciiMap += "w       wwwwwwwwwwwwwwwwwwwwwww                                 w";
                ret.AsciiMap += "w       wwwwwwwwwwwwwwwwwwwwwww        L                        w";
                ret.AsciiMap += "        wwwwwwwwwwwwwwwwwwwwwww       wwwwwwwwwwwwwwwwwwww       ";
                ret.AsciiMap += "d       wwwwwwwwwwwwwwwwwwwwwww       wwwwwwwwwwwwwwwwwwww      d";
                ret.AsciiMap += "        wwwwwwwwwwwwwwwwwwwwwww       wwwwwwwwwwwwwwwwwwww       ";
                ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffffw";


				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['3'] = MockActorData.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_10 {
			get {
				var ret = new RoomData ();
				ret.Id = 110;

				ret.AsciiMap += "cccccccccccccTcccccccccccccccccc";
				ret.AsciiMap += "                                ";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "                                ";
				ret.AsciiMap += "wPPPPP                   PPPPPPw";
				ret.AsciiMap += "w        L                     w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                  PPPPPPPPPPPPw";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                  L           w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wPPPPPPPPP                     w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                      L       w";
				ret.AsciiMap += "w                       PPPPPPPw";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w          L                   w";
				ret.AsciiMap += "w                 wwwwwww      w";
				ret.AsciiMap += "w                 wwwwwww      w";
				ret.AsciiMap += "                  wwwwwww       ";
				ret.AsciiMap += "d                 wwwwwww      d";
				ret.AsciiMap += "                  wwwwwww       ";
				ret.AsciiMap += "fffffffffffssssfffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.ROCKET_LAUNCHER;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;
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
				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.down);
				ret.AsciiSpawnLookup['4'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.right);
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;


				return ret;
			}
		}

		public static RoomData ROOM_12 {
			get {
				var ret = new RoomData();
				ret.Id = 112;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                  L                               L             ";
				ret.AsciiMap += "w                        PPPPPPPPPPPPPPPP                      w";
				ret.AsciiMap += "w                                                        PPPPPPw";
				ret.AsciiMap += "w                                       2                      w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                              L                               w";
				ret.AsciiMap += "w                                            cccccccccR        w";
				ret.AsciiMap += "w             2                              cccccccccR        w";
				ret.AsciiMap += "w                                            cccccccccR        w";
				ret.AsciiMap += "w                                            cccccccccR        w";
				ret.AsciiMap += "w                                            cccccccccR        w";
				ret.AsciiMap += "w                                                   fff        w";
				ret.AsciiMap += "w                                                   fff        w";
				ret.AsciiMap += "w              L                                    fff   L    w";
				ret.AsciiMap += "w                      PPPPPPPPPPPPPPPPPPPP         fff        w";
				ret.AsciiMap += "w                                                   fff        w";
				ret.AsciiMap += "w                                                   fff  C     w";
				ret.AsciiMap += "w                                                   fffppppppppw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "wPPPPPPPPPPP                                                   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                          2                   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w             wwwwwwwwwwwwwww             L                    w";
				ret.AsciiMap += "              wwwwwwwwwwwwwww                                   ";
				ret.AsciiMap += "d             wwwwwwwwwwwwwww                                  d";
				ret.AsciiMap += "              wwwwwwwwwwwwwww                                   ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";


				ret.AsciiSpawnLookup['C'] = MockActorData.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['2'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['R'] = new AsciiPlacement(MockActorData.WALL_TURRET, Vector3.right);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData BUFF_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 113;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccc";
                ret.AsciiMap += "                                ";
                ret.AsciiMap += "d                              d";
                ret.AsciiMap += "                                ";
                ret.AsciiMap += "wppppppppppppppppppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppppppppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                L             w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppppppppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppppppppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w           L    L             w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "               1                ";
                ret.AsciiMap += "d       fffffffffffffff        d";
                ret.AsciiMap += "       wwwwwwwwwwwwwwwwww       ";
                ret.AsciiMap += "ffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.RANDOM_BUFF;
				finalize(ret);

				return ret;
			}
		}


		public static RoomData WEAPON_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 114;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                               ";
				ret.AsciiMap += "w      l               L       d";
				ret.AsciiMap += "w                               ";
				ret.AsciiMap += "w                        ffffffw";
				ret.AsciiMap += "w                        ffffffw";
				ret.AsciiMap += "wppppppPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w        L                     w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                           L  w";
				ret.AsciiMap += "w                       1      w";
				ret.AsciiMap += "wPPPPP                  L      w";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "wPPPPPPPPP        fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w                 fffffffffffffw";
				ret.AsciiMap += "w            PPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w            PPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w         fffffffffffffffffffffw";
				ret.AsciiMap += "          fffffffffffffffffffffw";
				ret.AsciiMap += "d      PPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "       PPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.RANDOM_WEAPON_PICKUP;
				finalize(ret);

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
			var matches = extractor.getAllMatching (MeshRoomDrawer.DOOR);
			foreach (Vector3 doorPos in matches) {
				var link = new RoomData.Link ();

				link.X = (int)doorPos.x;
				link.Y = (int)doorPos.y;
				
				if (link.X == 0) {
					link.Side = DoorRoomSide.Left;
					link.Width = 2;
					link.Height = 3;
				} else if (link.Y == 0) {
					link.Side = DoorRoomSide.Bottom;
					link.Width = 3;
					link.Height = 2;
				} else if (link.X == room.Width-1) {
					link.Side = DoorRoomSide.Right;
					link.Width = 2;
					link.Height = 3;
				} else {
					link.Side = DoorRoomSide.Top;
					link.Width = 3;
					link.Height = 2;
				}

				room.Doors.Add (link);

			}
		}

	}
}

