using System;
using Client.Game.Data;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Data.Ascii;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Map.TMX;

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

			SpawnFactoryLookup[SpawnType.Air] = RandomAirPosition;
			SpawnFactoryLookup[SpawnType.Grounded] = RandomFloorPosition;
			SpawnFactoryLookup[SpawnType.GroundedSniper] = RandomSniperPosition;
			
		}

		private static List<WaveData> sorted;
		private static Dictionary<int, List<WaveData>> waveBuckets = new Dictionary<int, List<WaveData>>();
		List<Vector3> AirCoords;
		List<Vector3> GroundCoords;
		List<Vector3> SniperCoords;

		private delegate Vector3 RandomRoomPosition(Room room);
		private Dictionary<SpawnType, RandomRoomPosition> SpawnFactoryLookup = new Dictionary<SpawnType, RandomRoomPosition>();

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
						.Where(p=>p.RestrictToZones.Count == 0 || p.RestrictToZones.Any(s => s.Id == zone.Id))
						.ToList();
					break;
				} else {
					matchedDifficulty--;
				}		
			}
			
			remainder = difficulty - matchedDifficulty;
			
			return buffer;
		}

		public GeneratedWave Generate(Room room, Actor forActor) {
			
			var extractor = new TMXChunkExtractor(room);
			AirCoords = extractor.AllOnLayer(Constants.AirSpawnLayer).ToList();
			GroundCoords = extractor.AllOnLayer(Constants.GroundSpawnLayer).ToList();
			SniperCoords = GroundCoords;

			GeneratedWave waveHead = null;
			GeneratedWave tail = null;
			var extraDifficulty = forActor.Attributes[ActorAttributes.WaveDifficulty];

			foreach( var wave in GetRoomWaves(room, extraDifficulty)) {
				
				var newWave = new GeneratedWave();
				newWave.WaveData = wave;
				
				foreach( var waveChar in wave.Spawns ) {
					
					if(SpawnFactoryLookup.ContainsKey(waveChar.SpawnType)) {
						var position = SpawnFactoryLookup[waveChar.SpawnType](room);
						if(position == default(Vector3)) {
							Debug.Log("Couldn't find spawn location for type: " + waveChar.SpawnType);
						} else {
							//always try to face into the center of the room
							var facingDirection = position.x < room.roomCenter.x? Vector3.right : Vector3.left;
							newWave.Generated.Add(new GeneratedWave.GeneratedSpawn(waveChar, position, facingDirection));
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

		private List<WaveData> GetRoomWaves(Room room, int actorDifficulty) {
			var buff = new List<WaveData>();

			var difficulty = room.Zone.Difficulty + actorDifficulty;

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

			return new TMXRoomDrawer.IPoint(airSpace)
					.GridToWorldTL(room.data.TmxMap)
					+ new Vector3((float)room.X, (float)room.Y);

		}

		public Vector3 RandomFloorPosition(Room room) {
			var seed = Game.Instance.Seed;
			var groundSpace = seed.RandomInList(GroundCoords);

			return new TMXRoomDrawer.IPoint(groundSpace)
				.GridToWorldTL(room.data.TmxMap)
				+ new Vector3((float)room.X, (float)room.Y);
		}

		public Vector3 RandomSniperPosition(Room room) {
			var seed = Game.Instance.Seed;
			var sniperPos = seed.RandomInList(SniperCoords);

			return new TMXRoomDrawer.IPoint(sniperPos)
				.GridToWorldTL(room.data.TmxMap)
				+ new Vector3((float)room.X, (float)room.Y);

		}
	}
}

