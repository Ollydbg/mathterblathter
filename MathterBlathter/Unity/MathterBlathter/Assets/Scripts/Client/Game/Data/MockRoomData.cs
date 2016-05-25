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
				ret.AsciiSpawnLookup['2'] = MockActorData.HOT_RAILS;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData DEBUG_ROOM {

			get {
				var ret = new RoomData();
				ret.Id = 2;
				ret.Solo = true;
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
                ret.AsciiMap += "w     1                                                         w";
                ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP         w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                  L                           L                w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                     ppppppppppw";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
				ret.AsciiMap += "w                                                               w";
				ret.AsciiMap += "wPPPP                                                           w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                PPPPPPPPPPPP                            2      w";
                ret.AsciiMap += "w                                                       ppppppppw";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                                                               w";
                ret.AsciiMap += "w                   L                                           w";
                ret.AsciiMap += "w                      PPPP                                     w";
                ret.AsciiMap += "w                      PPPP                    L                w";
                ret.AsciiMap += "                       PPPP                                      ";
                ret.AsciiMap += "d                                                               d";
                ret.AsciiMap += "                              C             1      1      11 111 ";
                ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffUffsssssffffffffffw";
					
				ret.AsciiSpawnLookup['2'] = MockActorData.GROUND_STATIC_TURRET;
				ret.AsciiSpawnLookup['U'] = MockActorData.LAUNCH_PAD;
				ret.AsciiSpawnLookup['s'] = MockActorData.SPIKES;

				ret.AsciiSpawnLookup['C'] = MockActorData.WAVE_GUN_WEAPON;
				
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
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPP          PPPPPPPppppppp       PPPPPPPPPPPPw";
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
				ret.AsciiMap += "w                 wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
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


				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "w                                                           L fw";
				ret.AsciiMap += "wpppppPPPPPPPPPPPP                            1              ppw";
				ret.AsciiMap += "w                ffffffffffffffffffffffffffffffffffffffffffffffw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "wPPPPPPPPP                                                     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w          5                                                   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                      L                                       w";
				ret.AsciiMap += "w                       3                                      w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPP                                  w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPP                                  w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                      L       w";
				ret.AsciiMap += "w                                                      2       w";
				ret.AsciiMap += "w                                                      PPPPPPPPw";
				ret.AsciiMap += "w                                                      PPPPPPPPw";
				ret.AsciiMap += "w                                                      PPPPPPPPw";
				ret.AsciiMap += "w                                                      PPPPPPPPw";
				ret.AsciiMap += "w                                                      PPPPPPPPw";
				ret.AsciiMap += "w                    L                          1      PPPPPPPPw";
				ret.AsciiMap += "w                                   cccccccccccccccccccccccccccw";
				ret.AsciiMap += "w                           PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                           PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "                   5                                            ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "wP                                                             w";
				ret.AsciiMap += "wPw                                                            w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPP                                      w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPwPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPppppw";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                         1           w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                   ffffPPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw      1                              w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPwPPPPPPPPPPPPPP                       w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                    L                w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                      ";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     d";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                               4      ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d fffffffffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['1'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['2'] = new AsciiPlacement(MockActorData.RAIL_SNIPER_ENEMY, Vector3.left);
				ret.AsciiSpawnLookup['3'] = new AsciiPlacement(MockActorData.RAIL_SNIPER_ENEMY, Vector3.right);
				ret.AsciiSpawnLookup['4'] = MockActorData.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['5'] = MockActorData.ENERGY_SAPPER_ENEMY;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_12 {
			get {
				var ret = new RoomData();
				ret.Id = 112;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                               ";
				ret.AsciiMap += "w                                                              d";
				ret.AsciiMap += "w                 L                               L             ";
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
                ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                L             w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
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
				ret.AsciiMap += "w             2          ffffffw";
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
				ret.AsciiSpawnLookup['2'] = MockActorData.SHOPKEEPER;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_13 {
			get {
				var ret = new RoomData();
				ret.Id = 115;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                               ";
				ret.AsciiMap += "w                                                              d";
				ret.AsciiMap += "w                                                               ";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                             Pw";
				ret.AsciiMap += "w                                                            ffw";
				ret.AsciiMap += "w                                                     PPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                           PPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                    PPPP                      w";
				ret.AsciiMap += "w                                    PPPP                      w";
				ret.AsciiMap += "w                         fffffffffffffff                      w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w               L                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                            L                 w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                            2                 w";
				ret.AsciiMap += "w                                            PPPPPPPPPPP       w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       w";
				ret.AsciiMap += "        PPPPPPPPPPPPPPPPP              L     PPPPPPPPPPP        ";
				ret.AsciiMap += "d       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       d";
				ret.AsciiMap += "        PPPPPPPPPPPPPPPPP             1      PPPPPPPPPPP        ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.FLY_BOT_SPAWNER;
				ret.AsciiSpawnLookup['2'] = MockActorData.GROUND_STATIC_TURRET;

				finalize(ret);
				
				return ret;
			}
		}

		public static RoomData ROOM_14 {
			get {
				var ret = new RoomData ();
				ret.Id = 116;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                               L              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "wf                          ppppppppp                          w";
				ret.AsciiMap += "wfc                                                            w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                   PPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                 2            w";
				ret.AsciiMap += "w             3                    PPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                      L                       w";
				ret.AsciiMap += "wppppppPPPPPPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP                          L          w";
				ret.AsciiMap += "wppppppPPPPPPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w                                              1               w";
				ret.AsciiMap += "w                                              ccccccccccccccccw";
				ret.AsciiMap += "w                                     L        ccccccccccccccccw";
				ret.AsciiMap += "w                                 1            ccccccccccccccccw";
				ret.AsciiMap += "                                  PPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "d                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "                                  PPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = new AsciiPlacement(MockActorData.RAIL_SNIPER_ENEMY, Vector3.left);
				ret.AsciiSpawnLookup['2'] = new AsciiPlacement(MockActorData.GROUND_STATIC_TURRET, Vector3.left);
				ret.AsciiSpawnLookup['3'] = MockActorData.FLOATING_TURRET;
				finalize(ret);

				return ret;
			}
		}


		public static RoomData Room_15 {
			get {
				var ret = new RoomData();
				ret.Id = 117;

				ret.AsciiMap += "cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w              L                                               w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                L                                             w";
				ret.AsciiMap += "w                        L                                     w";
				ret.AsciiMap += "w                   L                                          w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                        L                                     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                    L    L       L            w";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                        1                       ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = MockActorData.SHOPKEEPER;

				finalize(ret);
				return ret;
			}
		}


		public static RoomData Room_16 {
			get {
				var ret = new RoomData();
				ret.Id = 118;

				ret.SortOrder = 4;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                                                                                                ";
				ret.AsciiMap += "w                                                                                                                               d";
				ret.AsciiMap += "w                                                                                                                                ";
				ret.AsciiMap += "w                                                                    4                                                          w";
				ret.AsciiMap += "w                          PPPPPPPPPPP                                                                                          w";
				ret.AsciiMap += "w                    wwwwwwwwwwww                                                                                               w";
				ret.AsciiMap += "w                    wwwwwwwwwwww   7                                                                     L                     w";
				ret.AsciiMap += "w                              fffffffffffffffff                                           3           2                        w";
				ret.AsciiMap += "wPPPPPP                                                                                         PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                             PPPPPPPPPPPPPPPPPPP                                               w";
				ret.AsciiMap += "w                                                             PPPPPPPPPPPPPPPPPPP                                               w";
				ret.AsciiMap += "w                                                             PPPPPPPPPPPPPPPPPPP                                               w";
				ret.AsciiMap += "w                                                             PPPPPPPPPPPPPPPPPPP                                               w";
				ret.AsciiMap += "w            1                                                PPPPPPPPPPPPPPPPPPP                                               w";
				ret.AsciiMap += "wPPPPPPPPPPPPPP                                     wwwwwwwwwwPPPPPPPPPPPPPPPPPPP                                               w";
				ret.AsciiMap += "w                                 L                                                                                             w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                             4                 6                                                               w";
				ret.AsciiMap += "w                                                                            4                                                  w";
				ret.AsciiMap += "w                                     5                                                                                         w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPP                                          L                                    w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPP                                                                               w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPP                                                                               w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPP                                                                               w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPP                                                                               w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPPwwwwwwwwwwwwwwwwwwwwwww                                                        w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPPwwwwwwwwwwwwwwwwwwwwwwwww                                                      w";
				ret.AsciiMap += "wppppppppppppppppppppppppppPPPPPPPPPPPPPPPPPPPPPPwwwwwwwwwwwwwwwwwwwwwwwwwww                                                    w";
				ret.AsciiMap += "w                                                                        PPP                                                    w";
				ret.AsciiMap += "w                                                                        PPP                                                    w";
				ret.AsciiMap += "w                                                                        PPP                                                    w";
				ret.AsciiMap += "w                                                                        PPP                                                    w";
				ret.AsciiMap += "                                                                         PPP                                                    w";
				ret.AsciiMap += "d                                                                        PPP                                                    w";
				ret.AsciiMap += "                                                                         PPP                                                    w";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff d fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = new AsciiPlacement(MockActorData.RAIL_SNIPER_ENEMY, Vector3.right);
				ret.AsciiSpawnLookup['2'] = new AsciiPlacement(MockActorData.RAIL_SNIPER_ENEMY, Vector3.left);
				ret.AsciiSpawnLookup['3'] = MockActorData.ENERGY_SAPPER_ENEMY;
				ret.AsciiSpawnLookup['4'] = MockActorData.FLOATING_TURRET;
				ret.AsciiSpawnLookup['5'] = MockActorData.GROUNDED_RANGED_ENEMY;
				ret.AsciiSpawnLookup['6'] = MockActorData.GROUND_STATIC_TURRET;
				ret.AsciiSpawnLookup['7'] = MockActorData.GROUNDED_RANGED_ENEMY;

				finalize(ret);
				return ret;
			}
		}


		public static RoomData Room_17 {
			get {
				var ret = new RoomData();
				ret.Id = 119;
				ret.SortOrder = 3;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                 L                                            d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "wP                                                    1       Pw";
				ret.AsciiMap += "wcc                                                          ccw";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPpppppppppppppppPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                     1        w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w     1                                                        w";
				ret.AsciiMap += "w             2                                                w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPPpppppppp                             w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP                           L         w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP              PPPPPPPPPPP            w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP              PPPPPPPPPPP            w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP          ppppPPPPPPPPPPP            w";
				ret.AsciiMap += "w     L                                 PPPPPPPPPPP            w";
				ret.AsciiMap += "w                                       PPPPPPPPPPP            w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w            2                                                 w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwPPPP        w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww            w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww            w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww            w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww            w";
				ret.AsciiMap += "w                                                          PPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "      L                                                         ";
				ret.AsciiMap += "d                                                     1        d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";


				ret.AsciiSpawnLookup['1'] = MockActorData.ENERGY_SAPPER_ENEMY;
				ret.AsciiSpawnLookup['2'] = MockActorData.GROUND_STATIC_TURRET;

				finalize(ret);

				return ret;
			}
		}


		public static RoomData Room_18 {
			get {
				var ret = new RoomData();
				ret.Id = 120;
				ret.SortOrder = 2;
				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP                         cw";
				ret.AsciiMap += "w                                                            PPw";
				ret.AsciiMap += "w                                                      ccccccccw";
				ret.AsciiMap += "w                                                    PPPPPPPPPPw";
				ret.AsciiMap += "w                                                  ccccccccccccw";
				ret.AsciiMap += "w                                        PPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w          L                                                   w";
				ret.AsciiMap += "w                                               L              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPPwwwwwwwwwwwwwwww                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                      ccccccccw";
				ret.AsciiMap += "w                                                    PPPPPPPPPPw";
				ret.AsciiMap += "w                                                  ccccccccccccw";
				ret.AsciiMap += "w                                                PPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                    L                         w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPppppppppppPPPPPPPPPPPPPPP          w";
				ret.AsciiMap += "       wPPPPPPPPPPPPPPPPPPPP          PPPPPPPPPPPPPPPw          ";
				ret.AsciiMap += "d     PwPPPPPPPPPPPPPPPPPPPP          PPPPPPPPPPPPPPPwP        d";
				ret.AsciiMap += "     wPwPPPPPPPPPPPPPPPPPPPP          PPPPPPPPPPPPPPPwPw        ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";

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

