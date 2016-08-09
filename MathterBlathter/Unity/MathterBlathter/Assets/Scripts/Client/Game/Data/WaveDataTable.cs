using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Data
{
	public static class WaveDataTable
	{

		private static List<WaveData> _all;
		static void StaticInit() {
			_all = typeof(WaveDataTable).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as WaveData)
				.ToList();

		}
		
		public static List<WaveData> All() {
			if(_all == null) StaticInit();
			return _all.ToList();

		}

		public static WaveData DEBUG_WAVE {
			get {
				var ret = new WaveData();
				ret.Id = 0;
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);

				ret.RestrictToZones.Add(ZoneDataTable.DEBUG_ZONE);

				ret.Difficulty = 3;

				return ret;
			}
		}

		public static WaveData EASY_BLOOD_BOTS {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);

				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);

				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);

				ret.Difficulty = 1;
				return ret;
			}
		}

		public static WaveData AIR_GHOSTS {
			get {
				var ret = new WaveData();
				ret.Spawns.Add(CharacterDataTable.FLYING_WALL_PHASER);
				ret.Spawns.Add(CharacterDataTable.FLYING_WALL_PHASER);
				ret.Spawns.Add(CharacterDataTable.FLYING_WALL_PHASER);

				ret.Spawns.Add(CharacterDataTable.SHOTGUN_GHOST);

				ret.Difficulty = 2;
				return ret;

			}
		}

		public static WaveData WAVE_2 {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.SHOTGUN_GHOST);
				ret.Spawns.Add(CharacterDataTable.FLYING_WALL_PHASER);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);

				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);

				ret.Difficulty = 2;
				return ret;
			}
		}

		public static WaveData WAVE_3 {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);

				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);

				ret.Difficulty = 6;
				return ret;
			}
		}



		public static WaveData WAVE_4 {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);

				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);

				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);


				ret.Difficulty = 8;
				return ret;
			}
		}
		
		public static WaveData SHOTGUN_TURRETS_1 {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;
				
				ret.Spawns.Add(CharacterDataTable.FLOATING_SCATTER_GUN_ENEMY);
				ret.Spawns.Add(CharacterDataTable.ANXIETY_BALL_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLOATING_SCATTER_GUN_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLOATING_SCATTER_GUN_ENEMY);
				
				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);


				ret.Difficulty = 5;
				return ret;
			}
		}
		
		public static WaveData ROCKETS_MIX {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;
				
				ret.Spawns.Add(CharacterDataTable.FLOATING_SCATTER_GUN_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_VIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_VIPER_ENEMY);
				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);

				ret.Difficulty = 9;
				return ret;
			}
		}

		public static WaveData SNIPERS_MIX {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;
				
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);

				ret.Difficulty = 12;
				return ret;
			}
		}

		public static WaveData TWO_VIPERS {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.GROUNDED_VIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_VIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLOATING_SCATTER_GUN_ENEMY);
				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);


				ret.Difficulty = 10;
				return ret;
			}
		}


		public static WaveData VIPER_SNIPER_MIX {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.GROUNDED_VIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);

				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_VIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);

				ret.Difficulty = 14;
				return ret;
			}
		}

		public static WaveData GHOSTS_AND_SNIPERS {
			get {
				var ret = new WaveData();
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.SHOTGUN_GHOST);
				ret.Spawns.Add(CharacterDataTable.SHOTGUN_GHOST);
				ret.Spawns.Add(CharacterDataTable.SHOTGUN_GHOST);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.BULLET_SNIPER_ENEMY);
				ret.RestrictToZones.Add(ZoneDataTable.ZONE_1);

				ret.Difficulty = 17;
				return ret;
			}
		}

	}
}

