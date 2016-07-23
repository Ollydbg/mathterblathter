using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Data.Ascii;
using Client.Game.Map;
using UnityEngine;
using Client.Game.Map.TMX;

namespace Client.Game.Data
{
	public static partial class RoomDataTable
	{
		private static Dictionary<int, RoomData> _all;
		static void StaticInit() {
			_all = typeof(RoomDataTable).GetProperties()
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
				ret.Type = RoomType.LurchStart | RoomType.NoWaves;
				ret.SortOrder = 0;
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "              L                                                                              w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                                                             w";
				ret.AsciiMap += "                                                 L                L               L       L  d";
				ret.AsciiMap += "                                                                                             d";
				ret.AsciiMap += "                                                                        l                    d";
				ret.AsciiMap += "   l                                                                                        Pw";
				ret.AsciiMap += "                                                                                           ccw";
				ret.AsciiMap += "                                                    @                             PPPPPPPPPPPw";
				ret.AsciiMap += "fdddffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.LayerData = ParallaxDataTable.OUTDOORS;
				ret.MaxInstances = 1;
				ret.SetPiece = SetPieceDataTable.INTRO;

				ret.AsciiSpawnLookup['1'] = CharacterDataTable.CURSED_RAIL_GUN_WEAPON;
				ret.AsciiSpawnLookup['2'] = CharacterDataTable.ANXIETY_DAMAGE_AOE_ITEM;
				finalize(ret);

				return ret;
			}
		}

		public static RoomData DEBUG_ROOM {

			get {
				var ret = new RoomData();
				ret.Id = 2;

				ret.Type = RoomType.NoWaves | RoomType.Normal;

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
                ret.AsciiMap += "w                                                              w";
                ret.AsciiMap += "w                                                              w";
                ret.AsciiMap += "w                                                              w";
                ret.AsciiMap += "w                                                              w";
                ret.AsciiMap += "w                                                              w";
                ret.AsciiMap += "w                                                              w";
                ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
                ret.AsciiMap += "d                                                              d";
                ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffw";

				//ret.AsciiSpawnLookup['U'] = new AsciiPlacement(CharacterDataTable.UPGRADEABLE_TRAP_FIXTURE, Vector3.up);
				//ret.AsciiSpawnLookup['S'] = new AsciiPlacement(CharacterDataTable.SPIKES_FIXTURE, Vector3.up);
				//ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.right);
				
				/*
				ret.AsciiSpawnLookup['4'] = CharacterDataTable.RUSTY_SHIELD_WEAPON;
				ret.AsciiSpawnLookup['5'] = CharacterDataTable.RUST_MACHINE;
				ret.AsciiSpawnLookup['6'] = CharacterDataTable.VIPER_REPEATER_WEAPON;
				ret.AsciiSpawnLookup['7'] = CharacterDataTable.WAVE_GUN_WEAPON;
				ret.AsciiSpawnLookup['8'] = CharacterDataTable.ROCKET_LAUNCHER_WEAPON;
				ret.AsciiSpawnLookup['9'] = CharacterDataTable.GRENADE_LAUNCHER_WEAPON;
				ret.AsciiSpawnLookup['#'] = CharacterDataTable.HOT_RAILS;
				ret.AsciiSpawnLookup['e'] = CharacterDataTable.CERAMIC_SHOTGUN_WEAPON;
				ret.AsciiSpawnLookup['r'] = CharacterDataTable.LONG_BARREL_SHOTGUN_WEAPON;
				ret.AsciiSpawnLookup['q'] = CharacterDataTable.MAX_HEALTH_BOOST;
				*/
				//ret.AsciiSpawnLookup['C'] = CharacterDataTable.NAIL_MACHINE;
				//ret.AsciiSpawnLookup['1'] = CharacterDataTable.ANXIETY_BALL_ENEMY;



				finalize(ret);

				return ret;
			}

		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 101;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
                ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d   L                                                     L    d";
				ret.AsciiMap += "d          ,                    ..........                     d";
				ret.AsciiMap += "wcccPPPPPPPP             ......wwwwwwwwwwww        PPPPPPPPPPPPw";
				ret.AsciiMap += "w   PPPPPPPP            PPPPPPPPPPPPPPPPPPP      ffffffffffffffw";
				ret.AsciiMap += "w   PPPPPPPP      PPPPPP                       PPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                -----------------------------------------     w";
				ret.AsciiMap += "w                -----------------------------------------     w";
				ret.AsciiMap += "w                           ------------------------------     w";
				ret.AsciiMap += "w .....................,    ------------------------------     w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP    ------------------------------     w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                   , .........................w";
				ret.AsciiMap += "w   ---------        l              PPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w   ---------                                                  w";
				ret.AsciiMap += "w   ---------                  -----------------------------   w";
				ret.AsciiMap += "w   ---------    .......,      -----------------------------   w";
				ret.AsciiMap += "w   ---------    PPPPPPPP      -----------------------------   w";
				ret.AsciiMap += "w   ---------   L              -----------------------------   w";
				ret.AsciiMap += "w   --------------------------------------------------------   w";
				ret.AsciiMap += "w   --------------------------------------------------------   w";
				ret.AsciiMap += "w                        -----------------------------------   w";
				ret.AsciiMap += "w...........             -----------------------------------   w";
				ret.AsciiMap += "fffffffffffff            -----                                 w";
				ret.AsciiMap += "wwwwwwwwwwwwwww          -----      ........       ...........,w";
				ret.AsciiMap += "ffffffffffffffffffff     -----     pppppppppp     pppppppppppppw";
				ret.AsciiMap += "ffffffffffffffffffff     -----                                 w";
				ret.AsciiMap += "w         L              -----                             L   w";
				ret.AsciiMap += "w     -----------------------------------------------------    w";
				ret.AsciiMap += "w     -----------------------------------------------------    w";
				ret.AsciiMap += "w     -----------------------------------------------------    w";
				ret.AsciiMap += "d     -----------------------------------------------------    d";
				ret.AsciiMap += "d                                 L                            d";
				ret.AsciiMap += "d  ...........................             ..............      d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_2 {
			get {
				var ret = new RoomData ();
				ret.Id = 102;
				ret.AsciiMap += "wccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccw";
				ret.AsciiMap += "d L                                                       L    d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d  .................              L                            d";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPP          PPPPPPPppppppp       PPPPPPPPPPPPw";
				ret.AsciiMap += "w                      ---                       ffffffffffffffw";
				ret.AsciiMap += "w                      ---          L          PPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w   ------------  l                                            w";
				ret.AsciiMap += "w   ------------     ,,,           -------------------------   w";
				ret.AsciiMap += "w   ------------     www           -------------------------   w";
				ret.AsciiMap += "w   ------------     www ,         -------------------------   w";
				ret.AsciiMap += "w   ------------     PPPPPPPP      -------------------------   w";
				ret.AsciiMap += "w   ------------    1wwwwwwwwwww   -------------------------   w";
				ret.AsciiMap += "w   ------------                   -------------------------   w";
				ret.AsciiMap += "w   --------------------------------------------------------   w";
				ret.AsciiMap += "w   --------------------------------------------------------   w";
				ret.AsciiMap += "w   --------------------------------------------------------   w";
				ret.AsciiMap += "w   ------------                                               w";
				ret.AsciiMap += "w   ------------                .......................        w";
				ret.AsciiMap += "w   ------------              PPPPPPPPPPPPPPPPPPPPPPPPPPpppppppw";
				ret.AsciiMap += "w   ------------              L                          L     w";
				ret.AsciiMap += "w   -------------------------------------------------------    w";
				ret.AsciiMap += "w   -------------------------------------------------------    w";
				ret.AsciiMap += "w   ------------            -------------------------------    w";
				ret.AsciiMap += "w                    l      ----------------                   w";
				ret.AsciiMap += "w  ...............          ----------------       ............w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPP         ----------------      PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                           ----------------      PPPPPPPPPPPPPw";
				ret.AsciiMap += "w  ---------------------------------------        PPPPPPPPPPPPPw";
				ret.AsciiMap += "w  ---------------------------------------    fffffffffffffffffw";
				ret.AsciiMap += "w  ---------------------------------------                   L w";
				ret.AsciiMap += "w  ---------------------------------------                     w";
				ret.AsciiMap += "w  ----------------------------------------------------------  w";
				ret.AsciiMap += "d  ----------------------------------------------------------  d";
				ret.AsciiMap += "d   L                                                          d";
				ret.AsciiMap += "d                ...........       ............................d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";
			
				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_3 {
			get {
				var ret = new RoomData ();
				ret.Id = 103;

				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                  L                                           w";
				ret.AsciiMap += "w                                             ----------  L    w";
				ret.AsciiMap += "w    ..................          ..........   ----------       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPP        PPPPPPPPPpppp  ----------  pppppw";
				ret.AsciiMap += "w                                             ----------       w";
				ret.AsciiMap += "w                     ----------------------- ----------       w";
				ret.AsciiMap += "w                     -----------------------                  w";
				ret.AsciiMap += "w        .........    -----------------------       .......... w";
				ret.AsciiMap += "w       PPPPPPPPPPP   -----------------------     PPPPPPPPPPPPPw";
				ret.AsciiMap += "w                     ----------------------- L                w";
				ret.AsciiMap += "w                     --------------------------------------   w";
				ret.AsciiMap += "w           L         --------------------------------------   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w  ....................               ........................ w";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['2'] = CharacterDataTable.RANDOM_WEAPON_PICKUP;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_4 {
			get {
				var ret = new RoomData ();
				ret.Id = 104;
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
				ret.AsciiMap += "d  L                                                           d";
				ret.AsciiMap += "d       -------------------------------------------------      d";
				ret.AsciiMap += "d       -------------------------------------------------      d";
				ret.AsciiMap += "fPPP    -------------------------------------------------  PPPPf";
				ret.AsciiMap += "w       -------------------------------------------------      w";
				ret.AsciiMap += "f       -------------------------------------------------      f";
				ret.AsciiMap += "f       -------------------------------------------------      f";
				ret.AsciiMap += "f                                                      L       f";
				ret.AsciiMap += "w       L              ............................            w";
				ret.AsciiMap += "w                    fffffffffffffffffffffffffffffffffffffffffTf";
				ret.AsciiMap += "w              PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w,,,,        L  --------------------------------------------   w";
				ret.AsciiMap += "wffff,,,        --------------------------------------------   w";
				ret.AsciiMap += "wffffwww        --------------------------------------------   w";
				ret.AsciiMap += "wffffwww,,,,    --------------------------------------------   w";
				ret.AsciiMap += "wffffwwwffff  l --------------------------------------------   w";
				ret.AsciiMap += "w               --------------------------L-----------------   w";
				ret.AsciiMap += "w               --------------------------------------------   w";
				ret.AsciiMap += "f               --------------------------------------------   w";
				ret.AsciiMap += "w               --------------------------------------------   w";
				ret.AsciiMap += "f                                                              w";
				ret.AsciiMap += "w   .......................................                    w";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffTfffpppppw";
				ret.AsciiMap += "w                                                        L     w";
				ret.AsciiMap += "w  ------------------------------------------------------      w";
				ret.AsciiMap += "w  ------------------------------------------------------      w";
				ret.AsciiMap += "w  ------------------------------------------------------      w";
				ret.AsciiMap += "w  ------------------------------------------------------      w";
				ret.AsciiMap += "w  ----------------------l-------------------------------   PPPw";
				ret.AsciiMap += "w  ------------------------------------------------------      w";
				ret.AsciiMap += "w  ------------------------------------------------------      w";
				ret.AsciiMap += "d  ------------------------------------------------------      d";
				ret.AsciiMap += "d  ------------------------------------------------------      d";
				ret.AsciiMap += "d       ..........................................             d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffssssssfffffff";

				ret.AsciiSpawnLookup['s'] = CharacterDataTable.SPIKES_FIXTURE;
				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.down);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_5 {
			get {
				var ret = new RoomData ();
				ret.Id = 105;

				ret.AsciiMap += "cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              L                                                           L   d";
				ret.AsciiMap += "d  L                                                                                            L                              d";
				ret.AsciiMap += "d            --------                                         1                                                                d";
				ret.AsciiMap += "wf   ,       --------                   ...............................                ...................................... fw";
				ret.AsciiMap += "wPPPPP       --------            l     PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP           , PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w            --------                                                              PP                                          w";
				ret.AsciiMap += "w            --------                                                                                                          w";
				ret.AsciiMap += "w                         .......,       ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w            L           PPPPPPPPP       ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w  ..........            wwww            ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "wPPPPPPPPPPPPP           wwww            ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w                        wwww            ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w                        wwww            ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w                        wwww            ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w   --------          PPPwwww            ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w   --------             wwww            ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w   --------     L       wwww            -----------------------------------------------------------------l----------------    w";
				ret.AsciiMap += "w   --------                             ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w                                        ----------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w                  .........,       ---------------------------------------------------------------------------------------    w";
				ret.AsciiMap += "w                PPPPPPPPwwww       ----------------------     L                                                               w";
				ret.AsciiMap += "w  .... L                wwww       ----------------------                        .........................................    w";
				ret.AsciiMap += "wpppPPPP                 wwww       ----------------------    PPPPPPPPPPPPPTTTTPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w                        wwww       ----------------------    PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w         -----------    wwww       ----------------------    PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w         -----------    wwww       ----------------------    PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w         -----------    wwww       ----------------------    PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w         -----------    wwww       ----------------------    PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "w ....    -----------    wwww       ----------------------    PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP   w";
				ret.AsciiMap += "wPPPPP    -----------    wwww       ----------------------                                                                     w";
				ret.AsciiMap += "wPPPPP    -----------    wwww       ----------------------------------------------------------------------------------------   w";
				ret.AsciiMap += "w         -----------    wwww       ----------------------------------------------------------------------------------------   w";
				ret.AsciiMap += "w         -----------                                     ------------------------------------------------------------------   d";
				ret.AsciiMap += "w                          L                                L                                    L                             d";
				ret.AsciiMap += "w                    .....................................                                                                     d";
				ret.AsciiMap += "fffffffffTfffffffffffffffffffffffffffffffffffffffffffffffffffffdddffffffffTTTTfffffffffffffffffdddffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.up);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_6 {
			get {
				var ret = new RoomData ();
				ret.Id = 106;

				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d     L                                                  L     d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPppppcccw";
				ret.AsciiMap += "w                                                           cccw";
				ret.AsciiMap += "3                                                           cccw";
				ret.AsciiMap += "3                                                           cccw";
				ret.AsciiMap += "3                                                    ,      cccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w                                                    fffffffcccw";
				ret.AsciiMap += "w     ----------------------                         fffffffcccw";
				ret.AsciiMap += "w     ----------------------               ,,        fffffffcccw";
				ret.AsciiMap += "w     ----------------------               wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ----------------------               wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ----------------------               wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ----------------------               wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ----------------------            ,  wwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ----------------------    fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ----------------------    fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ----------------------    fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                               fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                               fffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                   wwwwwwwwwwwwfffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w                   wwwwwwwwwwwwfffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "w     ............. wwwwwwwwwwwwfffffffffffwwwwwwwwwwfffffffcccw";
				ret.AsciiMap += "wppppPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPTPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                 ----------   w";
				ret.AsciiMap += "w                   ----------------------------  ----------   w";
				ret.AsciiMap += "w                   ----------------------------  ----------   w";
				ret.AsciiMap += "d                   ----------------------------  ----------   d";
				ret.AsciiMap += "d                   ----------------------------               d";
				ret.AsciiMap += "d                   ----------------------------      , ...... d";
				ret.AsciiMap += "wPPPPPPPTPPPPPP     ----------------------------      PPPPPPPPPw";
				ret.AsciiMap += "w                   ----------------------------               w";
				ret.AsciiMap += "w   --------------------------------------------               w";
				ret.AsciiMap += "w   --------------------------------------------               w";
				ret.AsciiMap += "w   ----------------      l                                    w";
				ret.AsciiMap += "w   ----------------                                           w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                  .......          L          w";
				ret.AsciiMap += "w                    PPPPPPPPP    PPPPPPPPP                    w";
				ret.AsciiMap += "w          L         ww                  ww                    w";
				ret.AsciiMap += "w               PPPPPww                  wwPPPP                w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww    ............  ww                    w";
				ret.AsciiMap += "w                    wwppppppppppppppppppww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w ....,              ww                  ww             ,      w";
				ret.AsciiMap += "wPPPPPP              ww       L          ww             PPPPPPPw";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww,.................ww                    w";
				ret.AsciiMap += "w                    wwppppppppppppppppppww            L       w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w       L            ww                  ww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                PPPPww                  wwPPPP                w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "w                    ww               PPPww                    w";
				ret.AsciiMap += "w                    ww                  ww                    w";
				ret.AsciiMap += "d                    ww                  ww                 L  d";
				ret.AsciiMap += "d                    ww     L            ww                    d";
				ret.AsciiMap += "d    ....            ww                  ww                    d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.down);
				ret.AsciiSpawnLookup['3'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.right);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_7 {
			get {
				var ret = new RoomData ();
				ret.Id = 107;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d  L                                                      L    d";
				ret.AsciiMap += "d                             ......          ,............    d";
				ret.AsciiMap += "wP    ------------------     PPPPPPP2         PPPPPPPPPPPPPPpppw";
				ret.AsciiMap += "w     ------------------                                       w";
				ret.AsciiMap += "w     ------------------                                       w";
				ret.AsciiMap += "w     ------------------                                ,      w";
				ret.AsciiMap += "w     ------------------                                PPPPPPPw";
				ret.AsciiMap += "w                               -----------------              w";
				ret.AsciiMap += "w                        L      -----------------              w";
				ret.AsciiMap += "w           ...........,        -----------------              w";
				ret.AsciiMap += "w          pppppppwwwwww        -----------------     , .......w";
				ret.AsciiMap += "w                 wwwwww        -----------------     PPPPPPPPPw";
				ret.AsciiMap += "w                 wwwwww        -----------------              w";
				ret.AsciiMap += "w                 wwwwww        -----------------              w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w            PPPPPwwwwww     .....          ........           w";
				ret.AsciiMap += "w                 Twwwww   wwwwwwwwUwwwwwwUwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwwwpppwwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w,.....           wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "wPPPPPP           wwwwww   wwwwwwwwwwwwwwwwwwwwwwwwww          w";
				ret.AsciiMap += "w                 wwwwww                                       w";
				ret.AsciiMap += "w  L         pppppwwwwwwppp                                    w";
				ret.AsciiMap += "w                 wwwwww          -------------------------    w";
				ret.AsciiMap += "w                 wwwwww      L   -------------------------    w";
				ret.AsciiMap += "w                 wwwwww          -------------------------    w";
				ret.AsciiMap += "w           ..... wwwwww          -------------------------    w";
				ret.AsciiMap += "w           PPPPPPwwwwwwpp        -------------------------    w";
				ret.AsciiMap += "w                 Twwwww          -------------------------    w";
				ret.AsciiMap += "w                 wwwwww          -------------------------    w";
				ret.AsciiMap += "d                 wwwwww          -------------------------    d";
				ret.AsciiMap += "d                 wwwwww                                       d";
				ret.AsciiMap += "d                 wwwwww               ....................... d";
				ret.AsciiMap += "ffffffffffUffffffffffffffffffffdddffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.left);
				ret.AsciiSpawnLookup['U'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.up);


				finalize(ret);

				return ret;
			}
		}


		public static RoomData ROOM_8 {
			get {
				var ret = new RoomData ();
				ret.Id = 108;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                .........................................     w";
				ret.AsciiMap += "w              ppppppppppppppppppppppppppppppppppppppppppppp   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w     -----------------------------                            w";
				ret.AsciiMap += "w     -----------------------------                            w";
				ret.AsciiMap += "w     -----------------------------      ,........             w";
				ret.AsciiMap += "w     -----------------------------      wPPPPPPPPP            w";
				ret.AsciiMap += "w     -----------------------------      w                     w";
				ret.AsciiMap += "w     -----------------------------      w                     w";
				ret.AsciiMap += "w     -----------------------------  ,.. w                     w";
				ret.AsciiMap += "w     -----------------------------  ppppw                     w";
				ret.AsciiMap += "w     -----------------------------      w          PPPPPPPPPPPw";
				ret.AsciiMap += "w     -----------------------------      w                     w";
				ret.AsciiMap += "w     -----------------------------      w                     w";
				ret.AsciiMap += "w    ------       L                      w                     w";
				ret.AsciiMap += "w    ------    ..........................w        C            w";
				ret.AsciiMap += "w    ------    ppppppppppppppppppppppppppPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w    ------                                                    w";
				ret.AsciiMap += "w    ------                                                    w";
				ret.AsciiMap += "w    ------                                                    w";
				ret.AsciiMap += "w    ------                                                    w";
				ret.AsciiMap += "w    ------     .........                       L              w";
				ret.AsciiMap += "w    ------    pppppppppppppppppppppppppppppppppppppppppppppp  w";
				ret.AsciiMap += "w    ------                                                    w";
				ret.AsciiMap += "d    ------                                                    d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d       ......................                                 d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffw";

				ret.AsciiSpawnLookup['C'] = CharacterDataTable.RANDOM_WEAPON_PICKUP;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_9 {
			get {
				var ret = new RoomData ();
				ret.Id = 109;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
                ret.AsciiMap += "d                                                              d";
                ret.AsciiMap += "d                                        L                     d";
                ret.AsciiMap += "d                                                              d";
                ret.AsciiMap += "w      ,...................................................... w";
				ret.AsciiMap += "wppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppppw";
                ret.AsciiMap += "w            L                                                 w";
                ret.AsciiMap += "w  ------                          ------------------------    w";
                ret.AsciiMap += "w  ------                  ------  ------------------------    w";
                ret.AsciiMap += "w  ------                  ------  ------------------------    w";
				ret.AsciiMap += "w  ------                  ------  ------------------------    w";
                ret.AsciiMap += "w  ------  ,.........,     ------                              w";
				ret.AsciiMap += "w  ------  PPPPPPPPPPP     ------   PPPPPPPPPPPPPPP            w";
                ret.AsciiMap += "w  ------                  ------                   L          w";
                ret.AsciiMap += "w  ------            L     ------                              w";
				ret.AsciiMap += "w  ------                  ------                              w";
                ret.AsciiMap += "w  ------                  ------                              w";
                ret.AsciiMap += "w                                                              w";
                ret.AsciiMap += "w      ........             .................                , w";
				ret.AsciiMap += "w     wwwwwwwwwwwwwppppppppfffffffffffffffffffffsssssssssssffffw";
				ret.AsciiMap += "w     wwwwwwwwwwwww        ffffffffffffffffffffffffffffffffffffw";
                ret.AsciiMap += "w     wwwwwwwwwwwww                                            w";
                ret.AsciiMap += "w     wwwwwwwwwwwww                                            w";
                ret.AsciiMap += "w     wwwwwwwwwwwww                                            w";
                ret.AsciiMap += "w     wwwwwwwwwwwww                                            w";
                ret.AsciiMap += "w                            ......................            w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPPPPPP          w";
                ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPPPPPP          w";
                ret.AsciiMap += "w                          ffff                                w";
                ret.AsciiMap += "w        L                 ffff        L                       w";
                ret.AsciiMap += "w              ........    ffff                            L   w";
                ret.AsciiMap += "w       wwwwwwwwwwwwwwwwwwwwwww                                w";
                ret.AsciiMap += "w       wwwwwwwwwwwwwwwwwwwwwww            ..........   ,      w";
                ret.AsciiMap += "d       wwwwwwwwwwwwwwwwwwwwwww       wwwwwwwwwwwwwwwwwww      d";
                ret.AsciiMap += "d       wwwwwwwwwwwwwwwwwwwwwww       wwwwwwwwwwwwwwwwwww      d";
                ret.AsciiMap += "d       wwwwwwwwwwwwwwwwwwwwwww       wwwwwwwwwwwwwwwwwww      d";
                ret.AsciiMap += "fffffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffw";


				ret.AsciiSpawnLookup['s'] = CharacterDataTable.SPIKES_FIXTURE;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_10 {
			get {
				var ret = new RoomData ();
				ret.Id = 110;
				ret.AsciiMap += "cccccccccccccTcccccccccccccccccc";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "d    ,                   ,     d";
				ret.AsciiMap += "wPPPPP                   PPPPPPw";
				ret.AsciiMap += "w        L                     w";
				ret.AsciiMap += "w                  ----------  w";
				ret.AsciiMap += "w  --------------  ----------  w";
				ret.AsciiMap += "w  --------------  ----------  w";
				ret.AsciiMap += "w  --------------              w";
				ret.AsciiMap += "w  --------------  ,.......... w";
				ret.AsciiMap += "w  --------------  PPPPPPPPPPPPw";
				ret.AsciiMap += "w  --------------              w";
				ret.AsciiMap += "w  --------------  L           w";
				ret.AsciiMap += "w  --------------      ------  w";
				ret.AsciiMap += "w  --------------      ------  w";
				ret.AsciiMap += "w  --------------------------  w";
				ret.AsciiMap += "w             ---------------  w";
				ret.AsciiMap += "w .....  ,    ---------------  w";
				ret.AsciiMap += "wPPPPPPPPP    ---------------  w";
				ret.AsciiMap += "w             ---------------  w";
				ret.AsciiMap += "w             ---------------  w";
				ret.AsciiMap += "w     -----------------------  w";
				ret.AsciiMap += "w     ---------        ------  w";
				ret.AsciiMap += "w     ---------                w";
				ret.AsciiMap += "w     ---------         ,      w";
				ret.AsciiMap += "w     ----------        PPPPPPPw";
				ret.AsciiMap += "w     ----------               w";
				ret.AsciiMap += "w     ----------               w";
				ret.AsciiMap += "w     ----------               w";
				ret.AsciiMap += "w   ------ L       ...         w";
				ret.AsciiMap += "w   ------        wwwwwww  --  w";
				ret.AsciiMap += "w   ------        wwwwwww  --  w";
				ret.AsciiMap += "d   ------        wwwwwww  --  d";
				ret.AsciiMap += "d   ------        wwwwwww      d";
				ret.AsciiMap += "d  ........       wwwwwww      d";
				ret.AsciiMap += "fffffffffffssssfffffffffffffffff";

				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.down);
				ret.AsciiSpawnLookup['s'] = CharacterDataTable.SPIKES_FIXTURE;

				finalize(ret);
				return ret;
			}
		}

		public static RoomData ROOM_11 {
			get {
				var ret = new RoomData();
				ret.Id = 111;

				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "w                                                           L fw";
				ret.AsciiMap += "wpppppPPPPPPPPPPPP                                           PPw";
				ret.AsciiMap += "w                ffffffffffffffffffffffffffffffffffffffffffffffw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w        ,    ---------------------------------------          w";
				ret.AsciiMap += "wPPPPPPPPP    ----------------------------------------------   w";
				ret.AsciiMap += "w             ----------------------------------------------   w";
				ret.AsciiMap += "w             ----------------------------------------------   w";
				ret.AsciiMap += "w             ----------------------------------------------   w";
				ret.AsciiMap += "w             ----------------------------------------------   w";
				ret.AsciiMap += "w             ----------------------------------------------   w";
				ret.AsciiMap += "w                      L         ---------------------------   w";
				ret.AsciiMap += "w ..........                ,    ---------------------------   w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPP    ---------------------------   w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPP    ---------------------------   w";
				ret.AsciiMap += "w                                --------------------          w";
				ret.AsciiMap += "w   ---------------------        --------------------  L       w";
				ret.AsciiMap += "w   ---------------------        --------------------  ,       w";
				ret.AsciiMap += "w   ---------------------        --------------------  PPPPPPPPw";
				ret.AsciiMap += "w   ---------------------        --------------------  PPPPPPPPw";
				ret.AsciiMap += "w   ---------------------        --------------------  PPPPPPPPw";
				ret.AsciiMap += "w   ---------------------        --------------------  PPPPPPPPw";
				ret.AsciiMap += "w   ---------------------        --------------------  PPPPPPPPw";
				ret.AsciiMap += "w   ---------------------                              PPPPPPPPw";
				ret.AsciiMap += "w   ---------------------           cccccccccccccccccccccccccccw";
				ret.AsciiMap += "w   ---------------------   PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w   ---------------------   PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w   ---------------------                                      w";
				ret.AsciiMap += "d   ---------------------                                      d";
				ret.AsciiMap += "d   ---------------------     ------------------------------   d";
				ret.AsciiMap += "d                             ------------------------------   d";
				ret.AsciiMap += "wP                            ------------------------------   w";
				ret.AsciiMap += "wPw    ................                                        w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPP                                      w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPwPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPppppw";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------       PPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------   ffffPPPPPPPPPP    w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------                     w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw   -------------    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw ............       --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPwPPPPPPPPPPPPPP      --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                    --------------   w";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                    --------------   d";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     d";
				ret.AsciiMap += "wPwPPPPPPPPPPPPPPPPPPPPPPw                                     d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffw";


				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_12 {
			get {
				var ret = new RoomData();
				ret.Id = 112;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                              d";
				ret.AsciiMap += "w                                                              d";
				ret.AsciiMap += "w                 L        .............          L            d";
				ret.AsciiMap += "w                        PPPPPPPPPPPPPPPP                ,     w";
				ret.AsciiMap += "w                                                        PPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                 ----------------------     ,                 w";
				ret.AsciiMap += "w                 ----------------------     cccccccccR        w";
				ret.AsciiMap += "w                 ----------------------     cccccccccR        w";
				ret.AsciiMap += "w    -----------------------------------     cccccccccR        w";
				ret.AsciiMap += "w    -----------------------------------     cccccccccR        w";
				ret.AsciiMap += "w    -------------                           cccccccccR        w";
				ret.AsciiMap += "w    -------------                                  fff        w";
				ret.AsciiMap += "w    -------------                                  fff        w";
				ret.AsciiMap += "w    -------------      .................           fff   L    w";
				ret.AsciiMap += "w    -------------     PPPPPPPPPPPPPPPPPPPP         fff        w";
				ret.AsciiMap += "w                                                   fff        w";
				ret.AsciiMap += "w                                                   fff  C     w";
				ret.AsciiMap += "w                -------------------                fffppppppppw";
				ret.AsciiMap += "w  ........,     -------------------                           w";
				ret.AsciiMap += "wPPPPPPPPPPP     -------------------                           w";
				ret.AsciiMap += "w                -------------------                           w";
				ret.AsciiMap += "w                -------------------------------------------   w";
				ret.AsciiMap += "w                -------------------------------------------   w";
				ret.AsciiMap += "w                -------------------------------------------   w";
				ret.AsciiMap += "w                                  -------------------------   w";
				ret.AsciiMap += "w                                  -------------------------   w";
				ret.AsciiMap += "w              .............       -------------------------   w";
				ret.AsciiMap += "w             wwwwwwwwwwwwwww      -------------------------   w";
				ret.AsciiMap += "d             wwwwwwwwwwwwwww      -------------------------   d";
				ret.AsciiMap += "d             wwwwwwwwwwwwwww                                  d";
				ret.AsciiMap += "d             wwwwwwwwwwwwwww                                  d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";


				ret.AsciiSpawnLookup['C'] = CharacterDataTable.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['R'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.right);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData BUFF_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 113;

				ret.AsciiMap += "cccccccccccccccccccccccccccccccc";
                ret.AsciiMap += "d                              d";
                ret.AsciiMap += "d                              d";
                ret.AsciiMap += "d                              d";
                ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w     ---------------------    w";
                ret.AsciiMap += "w     ---------------------    w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
				ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w    ----------------------    w";
                ret.AsciiMap += "w    ----------------------    w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w    .....         ......      w";
				ret.AsciiMap += "wppppppppppppp   ppppppppppppppw";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w   ------------------------   w";
                ret.AsciiMap += "w                              w";
                ret.AsciiMap += "d              1               d";
                ret.AsciiMap += "d       fffffffffffffff        d";
                ret.AsciiMap += "d      wwwwwwwwwwwwwwwwww      d";
                ret.AsciiMap += "ffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = CharacterDataTable.RANDOM_BUFF;

				finalize(ret);

				return ret;
			}
		}


		public static RoomData WEAPON_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 114;
				ret.Type = RoomType.Store | RoomType.NoWaves;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                              d";
				ret.AsciiMap += "w      l               L       d";
				ret.AsciiMap += "w                              d";
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
				ret.AsciiMap += "wPPPPP                   L     w";
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
				ret.AsciiMap += "d         fffffffffffffffffffffw";
				ret.AsciiMap += "d      PPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "d      PPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = CharacterDataTable.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['2'] = CharacterDataTable.SHOPKEEPER;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_13 {
			get {
				var ret = new RoomData();
				ret.Id = 115;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d               ,                 ----------------             d";
				ret.AsciiMap += "wppppPPPPPPPPPPPP    -----------------------------             w";
				ret.AsciiMap += "w    PPPPPPPPPPPP    -----------------------------            Pw";
				ret.AsciiMap += "w    PPPPPPPPPPPP    -----------------------------    ,,.....ffw";
				ret.AsciiMap += "w    PPPPPPPPPPPP    -----------------------------    PPPPPPPPPw";
				ret.AsciiMap += "wppppPPPPPPPPPPPP    -----------------------------             w";
				ret.AsciiMap += "w                    -----------------------------             w";
				ret.AsciiMap += "w                    -------------                             w";
				ret.AsciiMap += "w                    -------------                             w";
				ret.AsciiMap += "w  .......... ,      -------------          ,................. w";
				ret.AsciiMap += "wPPPPPPPPPPPPPP      -------------          PPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                    -------------                             w";
				ret.AsciiMap += "w                    -------------------------------------     w";
				ret.AsciiMap += "w     ----------------------------------------------------     w";
				ret.AsciiMap += "w     ----------------------------   ,  ,    -------------     w";
				ret.AsciiMap += "w     -----------------              PPPP    -------------     w";
				ret.AsciiMap += "w     -----------------              PPPP    -------------     w";
				ret.AsciiMap += "w     -----------------              PPPP     ------------     w";
				ret.AsciiMap += "w     -----------------   ,......... PPPP     ------------     w";
				ret.AsciiMap += "w     ----------------    fffffffffffffff     ------------     w";
				ret.AsciiMap += "w     ----------------  PP                    ------------     w";
				ret.AsciiMap += "w     ----------------      ------------------------------     w";
				ret.AsciiMap += "w     ---------------------------------------------------      w";
				ret.AsciiMap += "w     ---------------------------------------------------      w";
				ret.AsciiMap += "w                             ---------                        w";
				ret.AsciiMap += "w                             ---------      , .......         w";
				ret.AsciiMap += "w         ..............      ---------      PPPPPPPPPPP       w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       w";
				ret.AsciiMap += "d       PPPPPPPPPPPPPPPPP              L     PPPPPPPPPPP       d";
				ret.AsciiMap += "d       PPPPPPPPPPPPPPPPP                    PPPPPPPPPPP       d";
				ret.AsciiMap += "d       PPPPPPPPPPPPPPPPP ............1      PPPPPPPPPPP       d";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";


				finalize(ret);
				
				return ret;
			}
		}

		public static RoomData ROOM_14 {
			get {
				var ret = new RoomData ();
				ret.Id = 116;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                               L              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "wf                          ppppppppp                          w";
				ret.AsciiMap += "wfc                    ,                   ,                   w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                   PPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP         --------------------------    w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP         --------------------------    w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                     .......                  w";
				ret.AsciiMap += "w           --------------------   PPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w           --------------------                               w";
				ret.AsciiMap += "w           --------------------                               w";
				ret.AsciiMap += "w           --------------------                               w";
				ret.AsciiMap += "w           -----------------------------------------------    w";
				ret.AsciiMap += "w                               ---------------------------    w";
				ret.AsciiMap += "w          ,  ..........        ---------------------------    w";
				ret.AsciiMap += "wppppppPPPPPPPPPPPPPPPPPPP      ---------------------------    w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP      ---------------------------    w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP      ---------------------------    w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP      ---------------------------    w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP      ---------------------------    w";
				ret.AsciiMap += "w      PPPPPPPPPPPPPPPPPPP      ---------------------------    w";
				ret.AsciiMap += "wppppppPPPPPPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w                                              ,               w";
				ret.AsciiMap += "w                                              ccccccccccccccccw";
				ret.AsciiMap += "w     -----------------------         L        ccccccccccccccccw";
				ret.AsciiMap += "w     -----------------------                  ccccccccccccccccw";
				ret.AsciiMap += "d     -----------------------     PPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "d                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "d                                 PPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;
			}
		}


		public static RoomData Room_15 {
			get {
				var ret = new RoomData();
				ret.Id = 117;
				ret.Type = RoomType.Store | RoomType.NoWaves;
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
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                       1                      d";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['1'] = CharacterDataTable.SHOPKEEPER;

				finalize(ret);
				return ret;
			}
		}


		public static RoomData Room_16 {
			get {
				var ret = new RoomData();
				ret.Id = 118;
				ret.SortOrder = 4;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                                                                                                              d";
				ret.AsciiMap += "w                                                                                                                              d";
				ret.AsciiMap += "w                                                                                                                              d";
				ret.AsciiMap += "w                                                         -------------------           ------------------------------------   w";
				ret.AsciiMap += "w                          PPPPPPPPPPP                    -------------------           ------------------------------------   w";
				ret.AsciiMap += "w                    wwwwwwwwwwww                         -------------------                                                  w";
				ret.AsciiMap += "w                    wwwwwwwwwwww,                        -------------------                            L                     w";
				ret.AsciiMap += "w                              fffffffffffffffff                                        ,                                      w";
				ret.AsciiMap += "wPPPPPP                                                                                 pppppppPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                             PPPPPPPPPPPPPPPPPPP                                              w";
				ret.AsciiMap += "w                                           --------------    PPPPPPPPPPPPPPPPPPP                                              w";
				ret.AsciiMap += "w                                           --------------    PPPPPPPPPPPPPPPPPPP                                              w";
				ret.AsciiMap += "w                                           --------------    PPPPPPPPPPPPPPPPPPP                                              w";
				ret.AsciiMap += "w                        --------------------                 PPPPPPPPPPPPPPPPPPP                                              w";
				ret.AsciiMap += "wPPPPPPPPPPPPPP          --------------------       wwwwwwwwwwPPPPPPPPPPPPPPPPPPP                                              w";
				ret.AsciiMap += "w                        --------------------                                                                                  w";
				ret.AsciiMap += "w                        --------------------                                                                                  w";
				ret.AsciiMap += "w                        --------------------                                                                                  w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPP                                                                              w";
				ret.AsciiMap += "w    -------------------   PPPPPPPPPPPPPPPPPPPPPP                                                                              w";
				ret.AsciiMap += "w    -------------------   PPPPPPPPPPPPPPPPPPPPPP                                                                              w";
				ret.AsciiMap += "w    -------------------   PPPPPPPPPPPPPPPPPPPPPP                                                                              w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPP                                                                              w";
				ret.AsciiMap += "w                          PPPPPPPPPPPPPPPPPPPPPPwwwwwwwwwwwwwwwwwwwwwww                                                       w";
				ret.AsciiMap += "w     ..............       PPPPPPPPPPPPPPPPPPPPPPfffffffffffffffffffffffff                                                     w";
				ret.AsciiMap += "wppppppppppppppppppppppppppPPPPPPPPPPPPPPPPPPPPPPwwwwwwwwwwwwwwwwwwwwwwwwwww     -------------------------------------------   w";
				ret.AsciiMap += "w                                                                        PPP     -------------------------------------------   w";
				ret.AsciiMap += "w                                                                        PPP     -------------------------------------------   w";
				ret.AsciiMap += "w                                                                        PPP     -------------------------------------------   w";
				ret.AsciiMap += "w                                                                        PPP                                                   w";
				ret.AsciiMap += "d                                                                        PPP                                                   w";
				ret.AsciiMap += "d                                                                        PPP                                                   w";
				ret.AsciiMap += "d      ........................................                          PPP                     ..............                w";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";

				finalize(ret);
				return ret;
			}
		}


		public static RoomData Room_17 {
			get {
				var ret = new RoomData();
				ret.Id = 119;
				ret.SortOrder = 3;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                 L                                            d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "wP                                                            Pw";
				ret.AsciiMap += "wcc        ................................................. ccw";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPpppppppppppppppPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w            -------------------------                         w";
				ret.AsciiMap += "w            -------------------------   ------------------    w";
				ret.AsciiMap += "w                                        ------------------    w";
				ret.AsciiMap += "w          , ....................        ------------------    w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPPpppppppp       ------------------    w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP               ------------------    w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP                                     w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP              ,                      w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP              PPPPPPPPPPP     ----   w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP              PPPPPPPPPPP     ----   w";
				ret.AsciiMap += "w          PPPPPPPPPPPPPPP          ppppPPPPPPPPPPP     ----   w";
				ret.AsciiMap += "w     L                                 PPPPPPPPPPP     ----   w";
				ret.AsciiMap += "w                                       PPPPPPPPPPP     ----   w";
				ret.AsciiMap += "w          -----------------------                      ----   w";
				ret.AsciiMap += "w          -----------------------                      ----   w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w        ,          .................                          w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwPPPP        w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww            w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww            w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww            w";
				ret.AsciiMap += "w        wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww        ,   w";
				ret.AsciiMap += "w                                                          PPPPw";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                             ----------       w";
				ret.AsciiMap += "d     L                                       ----------       d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d     ........................                                 d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;
			}
		}


		public static RoomData Room_18 {
			get {
				var ret = new RoomData();
				ret.Id = 120;
				ret.SortOrder = 2;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                          ------              d";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP      ------             cw";
				ret.AsciiMap += "w                                          ------       ,    PPw";
				ret.AsciiMap += "w                                                      ccccccccw";
				ret.AsciiMap += "w       ----------------------------                 PPPPPPPPPPw";
				ret.AsciiMap += "w       ----------------------------      ,        ccccccccccccw";
				ret.AsciiMap += "w       ----------------------------     PPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w       ----------------------------                           w";
				ret.AsciiMap += "w       ----------------------------                           w";
				ret.AsciiMap += "w                                               L              w";
				ret.AsciiMap += "w                                        ------------------    w";
				ret.AsciiMap += "w          ....................          ------------------    w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP          ------------------    w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP          ------------------    w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPPwwwwwwwwwwwwwwww                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPPPP                                w";
				ret.AsciiMap += "w                                                      ,       w";
				ret.AsciiMap += "w                                                      ccccccccw";
				ret.AsciiMap += "w     ,                  --------------------        PPPPPPPPPPw";
				ret.AsciiMap += "wPUUUUP                  --------------------      ccccccccccccw";
				ret.AsciiMap += "wPPPPPP 1                --------------------    PPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                        --------------------                  w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w           ........................................           w";
				ret.AsciiMap += "w       PPPPPPPPPPPPPPPPPPPPppppppppppPPPPPPPPPPPPPPP          w";
				ret.AsciiMap += "d      wPPPPPPPPPPPPPPPPPPPP          PPPPPPPPPPPPPPPw         d";
				ret.AsciiMap += "d     PwPPPPPPPPPPPPPPPPPPPP          PPPPPPPPPPPPPPPwP        d";
				ret.AsciiMap += "d    wPwPPPPPPPPPPPPPPPPPPPP          PPPPPPPPPPPPPPPwPw       d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";

				ret.AsciiSpawnLookup['U'] = CharacterDataTable.LAUNCH_PAD_FIXTURE;

				finalize(ret);
				return ret;
			}
		}

		public static RoomData BOSS_FIGHT_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 121;
				ret.Type = RoomType.Boss | RoomType.NoWaves;

				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                                                                                              d";
				ret.AsciiMap += "d                                                                                                                              d";
				ret.AsciiMap += "d                                                                                                                              d";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "wppppppppppppppppPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPw";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                             B                                                                w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "w                                                                                                                              w";
				ret.AsciiMap += "d                                                                                                                              d";
				ret.AsciiMap += "d                                                                                                                              d";
				ret.AsciiMap += "d                                                                                                                              d";
				ret.AsciiMap += "ffffffUUUUUffffffffffffffffffffdddfffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";
				ret.LayerData = ParallaxDataTable.ABSTRACT;

				ret.AsciiSpawnLookup['B'] = CharacterDataTable.BOSS_1;
				ret.AsciiSpawnLookup['U'] = CharacterDataTable.LAUNCH_PAD_FIXTURE;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_19 {

			get {
				var ret = new RoomData();
				ret.Id = 122;
				ret.Type = RoomType.NoWaves;
				ret.AsciiMap += "cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "wwwwwwwwwwwwwww                                         pppppppw";
				ret.AsciiMap += "wcccccccccccccccccc1                                           w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP                                       w";
				ret.AsciiMap += "wPPPPPPPPPPPPPPPPPPPPPPP            C                C         w";
				ret.AsciiMap += "ffffffffffffffffffffffffUUUUUffffffffffffffffffffffffffffffUUUUw";

				ret.AsciiSpawnLookup['1'] = CharacterDataTable.PATCHES;
				ret.AsciiSpawnLookup['C'] = CharacterDataTable.RANDOM_WEAPON_PICKUP;
				ret.AsciiSpawnLookup['U'] = CharacterDataTable.LAUNCH_PAD_FIXTURE;


				finalize(ret);

				return ret;
			}

		}



		public static RoomData CAMERA_TEST_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 123;
				ret.Type = RoomType.NoWaves;
				ret.AsciiMap += "cccccccccccccTcccccccccccccccccc";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w    ,                   ,     w";
				ret.AsciiMap += "wPPPPP                   PPPPPPw";
				ret.AsciiMap += "w        L                     w";
				ret.AsciiMap += "w                  ----------  w";
				ret.AsciiMap += "w  --------------  ----------  w";
				ret.AsciiMap += "w  --------------  ----------  w";
				ret.AsciiMap += "w  --------------              w";
				ret.AsciiMap += "w  --------------  ,.......... w";
				ret.AsciiMap += "w  --------------  PPPPPPPPPPPPw";
				ret.AsciiMap += "w  --------------              w";
				ret.AsciiMap += "w  --------------  L           w";
				ret.AsciiMap += "w  --------------      ------  w";
				ret.AsciiMap += "w  --------------      ------  w";
				ret.AsciiMap += "w  --------------------------  w";
				ret.AsciiMap += "w             ---------------  w";
				ret.AsciiMap += "w .....  ,    ---------------  w";
				ret.AsciiMap += "wPPPPPPPPP    ---------------  w";
				ret.AsciiMap += "w             ---------------  w";
				ret.AsciiMap += "w             ---------------  w";
				ret.AsciiMap += "w     -----------------------  w";
				ret.AsciiMap += "w     ---------        ------  w";
				ret.AsciiMap += "w     ---------                w";
				ret.AsciiMap += "w     ---------         ,      w";
				ret.AsciiMap += "w     ----------        PPPPPPPw";
				ret.AsciiMap += "w     ----------               w";
				ret.AsciiMap += "w     ----------               w";
				ret.AsciiMap += "w     ----------               w";
				ret.AsciiMap += "w   ------ L       ...         w";
				ret.AsciiMap += "w   ------        wwwwwww  --  w";
				ret.AsciiMap += "w   ------        wwwwwww  --  w";
				ret.AsciiMap += "w   ------        wwwwwww  --  w";
				ret.AsciiMap += "w   ------        wwwwwww      w";
				ret.AsciiMap += "w  ........       wwwwwww      w";
				ret.AsciiMap += "fffffffffffssssfffffffffffffffff";

				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.down);
				ret.AsciiSpawnLookup['s'] = CharacterDataTable.SPIKES_FIXTURE;

				finalize(ret);
				return ret;
			}
		}



		static void finalize(RoomData room) {
			var tmx = TMXCache.Get(room);
			room.Width = tmx.Width - 1;
			room.Height = tmx.Height - 1;
			var expandedSize = new TMXRoomDrawer.IPoint(room.Width, room.Height).GridToWorld(tmx);
			room.ScreenWidth = expandedSize.x;
			room.ScreenHeight = expandedSize.y;


			addDoorsFromTMX (room, tmx);
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
					spawn.Facing = spawnType.Value.Facing;
					room.Spawns.Add(spawn);
				}
			}
		}

		static void addDoorsFromTMX (RoomData room, TiledSharp.TmxMap tmx)
		{
			var extractor = new TMXChunkExtractor(tmx);
			var matches = extractor.GetChunksOnLayer(Constants.DoorsLayer);

			foreach( var chunk in matches ) {
				var middleNode = chunk.MiddleNode;
				var doorPos = new TMXRoomDrawer.IPoint(middleNode).GridToWorld(tmx);

				var link = new RoomData.Link ();
				
				link.X = (int)doorPos.x;
				link.Y = (int)doorPos.y;

				link.ChunkData = chunk;

				if (link.X == 0) {
					link.Side = DoorRoomSide.Left;
					link.Width = 2;
					link.Height = 3;
				} else if (link.Y == 0) {
					link.Side = DoorRoomSide.Bottom;
					link.Width = 3;
					link.Height = 2;
				} else if (middleNode.x == room.Width) {
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

		static void addDoorsFromAscii (RoomData room)
		{
			//this really needs a floodfill instead
			var extractor = new AsciiMeshExtractor (room.AsciiMap);
			var matches = extractor.getChunksMatching (AsciiConstants.DOOR);
			foreach (Chunk chunk in matches) {
				var doorPos = chunk.Center;
				var link = new RoomData.Link ();
				
				link.X = (int)doorPos.x;
				link.Y = (int)doorPos.y;
				link.ChunkData = chunk;
				
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

