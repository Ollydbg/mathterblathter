﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Data
{
	public static class WaveDataTable
	{

		private static Dictionary<int, WaveData> _all;
		static void StaticInit() {
			_all = typeof(WaveDataTable).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as WaveData)
				.ToDictionary(p => p.Id, p=>p);

		}
		
		public static List<WaveData> All() {
			if(_all == null) StaticInit();
			return _all.Values.ToList();

		}

		public static WaveData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
		}

		
		public static WaveData EASY_BLOOD_BOTS {
			get {
				var ret = new WaveData();
				ret.Id = 1;
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.ENERGY_SAPPER_ENEMY);

				ret.Difficulty = 1;
				return ret;
			}
		}

		public static WaveData WAVE_2 {
			get {
				var ret = new WaveData();
				ret.Id = 2;
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.RAIL_SNIPER_ENEMY);

				ret.Difficulty = 2;
				return ret;
			}
		}

		public static WaveData WAVE_3 {
			get {
				var ret = new WaveData();
				ret.Id = 3;
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);

				ret.Difficulty = 6;
				return ret;
			}
		}



		public static WaveData WAVE_4 {
			get {
				var ret = new WaveData();
				ret.Id = 4;
				ret.PreDelay = 1f;

				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);
				ret.Spawns.Add(CharacterDataTable.FLOATING_TURRET);


				ret.Difficulty = 8;
				return ret;
			}
		}
		
		public static WaveData ROCKETS_2 {
			get {
				var ret = new WaveData();
				ret.Id = 5;
				ret.PreDelay = 1f;
				
				ret.Spawns.Add(CharacterDataTable.GROUND_STATIC_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLY_BOT_SPAWNER_ENEMY);



				ret.Difficulty = 5;
				return ret;
			}
		}
		
		public static WaveData ROCKETS_MIX {
			get {
				var ret = new WaveData();
				ret.Id = 6;
				ret.PreDelay = 1f;
				
				ret.Spawns.Add(CharacterDataTable.FLOATING_ROCKET_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUND_STATIC_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.QUAD_SHOT_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLY_BOT_SPAWNER_ENEMY);
				
				ret.Difficulty = 9;
				return ret;
			}
		}

		public static WaveData SNIPERS_MIX {
			get {
				var ret = new WaveData();
				ret.Id = 7;
				ret.PreDelay = 1f;
				
				ret.Spawns.Add(CharacterDataTable.RAIL_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.RAIL_SNIPER_ENEMY);
				ret.Spawns.Add(CharacterDataTable.GROUND_STATIC_TURRET_ENEMY);
				ret.Spawns.Add(CharacterDataTable.FLY_BOT_SPAWNER_ENEMY);

				ret.Difficulty = 12;
				return ret;
			}
		}

	}
}
