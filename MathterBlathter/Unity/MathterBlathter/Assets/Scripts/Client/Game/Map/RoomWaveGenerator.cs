using System;
using Client.Game.Data;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Data.Ascii;

namespace Client.Game.Map
{
	using Game = Game.Core.Game;

	public class RoomWaveGenerator
	{
		public RoomWaveGenerator ()
		{
		}

		List<WaveData> _sorted;

		List<Vector3> AirCoords;
		List<Vector3> GroundCoords;

		public List<WaveData> SortedWaves {
			get {
				if(_sorted == null) {
					_sorted = MockWaveData.All();
				}
				return _sorted;
			}
		}

		public List<GeneratedWave> Generate(Room room, int difficulty) {

			var extractor = new AsciiMeshExtractor(room.data.AsciiMap);
			AirCoords = extractor.getAllMatching(MeshRoomDrawer.AIR_SPAWN);
			GroundCoords = extractor.getAllMatching(MeshRoomDrawer.GROUNDED_SPAWN);

			var buff = new List<GeneratedWave>();

			foreach( var wave in GetRoomWaves(room, difficulty)) {
				var test = new GeneratedWave();
				foreach( var waveChar in wave.Spawns ) {
					var position = waveChar.SpawnType == CharacterSpawnType.Floor ? RandomFloorPosition(room) : RandomAirPosition(room);
					test.Generated.Add(new GeneratedWave.GeneratedSpawn(waveChar, position));
				}
				buff.Add(test);
			}

			return buff;
		}

		private List<WaveData> GetRoomWaves(Room room, int difficulty) {
			var buff = new List<WaveData>();

			while(difficulty > 0) {
				var random = Game.Instance.Seed.RandomInList(SortedWaves);
				difficulty-= random.Difficulty;
				buff.Add(random);
			}


			return buff;
		}

		public Vector3 RandomAirPosition(Room room) {
			var seed = Game.Instance.Seed;
			var airSpace = seed.RandomInList(AirCoords);
			return airSpace + new Vector3((float)room.X, (float)room.Y);
		}

		public Vector3 RandomFloorPosition(Room room) {
			var seed = Game.Instance.Seed;
			var airSpace = seed.RandomInList(GroundCoords);
			return airSpace + new Vector3((float)room.X, (float)room.Y);
		}
	}
}

