using System;
using Client.Game.Data;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Data.Ascii;

namespace Client.Game.Map
{
    using System.Linq;
    using Game = Game.Core.Game;

    public class RoomWaveGenerator
	{
		public RoomWaveGenerator ()
		{
			if(sorted == null) 
				StaticInit();

			SpawnFactoryLookup[AsciiConstants.AIR_SPAWN] = RandomAirPosition;
			SpawnFactoryLookup[AsciiConstants.GROUNDED_SPAWN] = RandomFloorPosition;
			SpawnFactoryLookup[AsciiConstants.GROUND_SNIPER_PERCH] = RandomSniperPosition;
			
		}

		private static List<WaveData> sorted;
		private static Dictionary<int, List<WaveData>> waveBuckets = new Dictionary<int, List<WaveData>>();
		List<Vector3> AirCoords;
		List<Vector3> GroundCoords;
		List<Vector3> SniperCoords;

		private delegate Vector3 RandomRoomPosition(Room room);
		private Dictionary<char, RandomRoomPosition> SpawnFactoryLookup = new Dictionary<char, RandomRoomPosition>();

		public static List<WaveData> StaticInit() {
			if(sorted == null) {
				sorted = WaveDataTable.All();
				sorted.Sort(new WaveSorter());
				
				foreach( var wave in sorted) {
					if(!waveBuckets.ContainsKey(wave.Difficulty))
						waveBuckets[wave.Difficulty] = new List<WaveData>();
						
					waveBuckets[wave.Difficulty].Add(wave);
					
				}
			}
			return sorted;
			
		}
		
		public List<WaveData> WavesForDifficulty(int difficulty, ZoneData zone, out int remainder) {
			//errs on easier
			var buffer = new List<WaveData>();
			int matchedDifficulty = difficulty;
			
			while(matchedDifficulty > 0) {
				if(waveBuckets.ContainsKey(matchedDifficulty)) {
					buffer = waveBuckets[matchedDifficulty]
						.Where(p=>p.RestrictToZones.Count == 0 || p.RestrictToZones.Contains(zone))
						.ToList();
					break;
				} else {
					matchedDifficulty--;
				}		
			}
			
			remainder = difficulty - matchedDifficulty;
			
			return buffer;
		}

		public GeneratedWave Generate(Room room, int difficulty) {
			
			var extractor = new AsciiMeshExtractor(room.data.AsciiMap);
			AirCoords = extractor.getAllMatching(AsciiConstants.AIR_SPAWN);
			GroundCoords = extractor.getAllMatching(AsciiConstants.GROUNDED_SPAWN);
			SniperCoords = extractor.getAllMatching(AsciiConstants.GROUND_SNIPER_PERCH);

			GeneratedWave waveHead = null;
			GeneratedWave tail = null;
			
			foreach( var wave in GetRoomWaves(room, difficulty)) {
				
				var newWave = new GeneratedWave();
				newWave.WaveData = wave;
				
				foreach( var waveChar in wave.Spawns ) {
					
					if(SpawnFactoryLookup.ContainsKey(waveChar.SpawnType)) {
						var position = SpawnFactoryLookup[waveChar.SpawnType](room);
						if(position == default(Vector3)) {
							Debug.Log("Couldn't find spawn location for type: " + waveChar.SpawnType);
						} else {
							newWave.Generated.Add(new GeneratedWave.GeneratedSpawn(waveChar, position));
						}
					}
				}
				
				
				if(tail != null) {
					tail.Next = newWave;
				}
				
				
				if(waveHead == null)
					waveHead = newWave;
				
				tail = newWave;
			}

			return waveHead;
		}

		private List<WaveData> GetRoomWaves(Room room, int difficulty) {
			var buff = new List<WaveData>();
			
			
			while(difficulty > 0) {
				Debug.Log("Generating for difficulty: " + difficulty);
				var waves = WavesForDifficulty(difficulty, room.Zone, out difficulty);
				if(waves.Count == 0)
					break;
					
				var random = Game.Instance.Seed.RandomInList(waves);
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

		public Vector3 RandomSniperPosition(Room room) {
			var seed = Game.Instance.Seed;
			var airSpace = seed.RandomInList(SniperCoords);
			return airSpace + new Vector3((float)room.X, (float)room.Y);
		}
	}
}

