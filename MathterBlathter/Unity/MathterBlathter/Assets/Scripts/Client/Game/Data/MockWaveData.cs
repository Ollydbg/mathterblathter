using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Data
{
	public static class MockWaveData
	{

		private static Dictionary<int, WaveData> _all;
		static void StaticInit() {
			_all = typeof(MockWaveData).GetProperties()
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

				ret.Spawns.Add(MockActorData.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(MockActorData.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(MockActorData.ENERGY_SAPPER_ENEMY);

				ret.Difficulty = 2;
				return ret;
			}
		}

		public static WaveData WAVE_2 {
			get {
				var ret = new WaveData();
				ret.Id = 2;
				ret.PreDelay = 1f;

				ret.Spawns.Add(MockActorData.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(MockActorData.FLOATING_TURRET);
				ret.Spawns.Add(MockActorData.BULLET_STAR);
				ret.Spawns.Add(MockActorData.ENERGY_SAPPER_ENEMY);
				ret.Spawns.Add(MockActorData.RAIL_SNIPER_ENEMY);

				ret.Difficulty = 2;
				return ret;
			}
		}

		public static WaveData WAVE_3 {
			get {
				var ret = new WaveData();
				ret.Id = 3;
				ret.PreDelay = 1f;

				ret.Spawns.Add(MockActorData.FLOATING_TURRET);
				ret.Spawns.Add(MockActorData.FLOATING_TURRET);
				ret.Spawns.Add(MockActorData.FLOATING_TURRET);
				ret.Spawns.Add(MockActorData.BULLET_STAR);

				ret.Difficulty = 6;
				return ret;
			}
		}



		public static WaveData WAVE_4 {
			get {
				var ret = new WaveData();
				ret.Id = 4;
				ret.PreDelay = 1f;

				ret.Spawns.Add(MockActorData.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(MockActorData.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(MockActorData.GROUNDED_RANGED_ENEMY);
				ret.Spawns.Add(MockActorData.BULLET_STAR);
				ret.Spawns.Add(MockActorData.FLOATING_TURRET);
				ret.Spawns.Add(MockActorData.FLOATING_TURRET);


				ret.Difficulty = 8;
				return ret;
			}
		}

	}
}

