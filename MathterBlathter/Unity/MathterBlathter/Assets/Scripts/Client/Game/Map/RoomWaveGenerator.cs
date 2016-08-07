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

		private static List<WaveData> sorted;
		private static Dictionary<int, List<WaveData>> waveBuckets = new Dictionary<int, List<WaveData>>();
		List<Vector3> AirCoords;
		List<Vector3> GroundCoords;
		List<Vector3> SniperCoords;

		Room Room;
		public RoomWaveGenerator (Room room)
		{
			this.Room = room;
			var extractor = new TMXChunkExtractor(room);
			AirCoords = extractor.AllOnLayer(Constants.AirSpawnLayer).ToList();
			GroundCoords = extractor.AllOnLayer(Constants.GroundSpawnLayer).ToList();
			SniperCoords = GroundCoords;

			if(sorted == null) 
				StaticInit();

			SpawnFactoryLookup[SpawnType.Air] = RandomAirPosition;
			SpawnFactoryLookup[SpawnType.Grounded] = RandomFloorPosition;
			SpawnFactoryLookup[SpawnType.GroundedSniper] = RandomSniperPosition;
			
		}


		private delegate Vector3 RandomRoomPosition();
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

		public GeneratedWave Generate(Actor forActor) {
			

			GeneratedWave waveHead = null;
			GeneratedWave tail = null;
			var extraDifficulty = forActor.Attributes[ActorAttributes.WaveDifficulty];

			foreach( var wave in GetRoomWaves(Room, extraDifficulty)) {
				
				var newWave = new GeneratedWave();
				newWave.WaveData = wave;
				
				foreach( var waveChar in wave.Spawns ) {
					
					if(SpawnFactoryLookup.ContainsKey(waveChar.SpawnType)) {
						var position = RandomSpawnLocationForType(waveChar.SpawnType);
						if(position == default(Vector3)) {
							Debug.Log("Couldn't find spawn location for type: " + waveChar.SpawnType);
						} else {
							//always try to face into the center of the room
							var facingDirection = position.x < Room.roomCenter.x? Vector3.right : Vector3.left;
							Debug.DrawRay(position, Vector3.forward*100f, Color.blue, 100000f);
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

		public Vector3 RandomSpawnLocationForType(SpawnType type) {
			return SpawnFactoryLookup[type]();
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

		public Vector3 RandomAirPosition() {
			var seed = Game.Instance.Seed;
			var airSpace = seed.RandomInList(AirCoords);

			return new GridPoint(airSpace)
				.GridToWorldBL(Room.data.TmxMap)
				+ new Vector3((float)Room.X, (float)Room.Y);

		}

		public Vector3 RandomFloorPosition() {
			var seed = Game.Instance.Seed;
			var groundSpace = seed.RandomInList(GroundCoords);

			return new GridPoint(groundSpace)
				.GridToWorldBL(Room.data.TmxMap)
				+ new Vector3((float)Room.X, (float)Room.Y);
		}

		public Vector3 RandomSniperPosition() {
			var seed = Game.Instance.Seed;
			var sniperPos = seed.RandomInList(SniperCoords);

			return new GridPoint(sniperPos)
				.GridToWorldBL(Room.data.TmxMap)
				+ new Vector3((float)Room.X, (float)Room.Y);

		}
	}
}

