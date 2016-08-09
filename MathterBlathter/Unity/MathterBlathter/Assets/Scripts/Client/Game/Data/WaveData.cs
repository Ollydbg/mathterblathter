using System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game.Data
{
	public class WaveData : GameData
	{

		public List<CharacterData> Spawns = new List<CharacterData>();
		public float PreDelay;
		public int Difficulty;
		public float Delay = 6f;
		public List<ZoneData> RestrictToZones = new List<ZoneData>();

		public WaveData ()
		{
			
		}


	}

	public class GeneratedWave  {

		public List<GeneratedSpawn> Generated = new List<GeneratedSpawn>();
		public WaveData WaveData;
		public GeneratedWave Next;
		
		public class GeneratedSpawn {
			
			public CharacterData Data;
			public Vector3 Position;
			public Vector3? Facing;

			public GeneratedSpawn(CharacterData data, Vector3 position, Vector3 facingDirection) {
				this.Data = data;
				this.Position = position;
				this.Facing = facingDirection;
			}
			public GeneratedSpawn(CharacterData data, Vector3 position) {
				this.Data = data;
				this.Position = position;

				this.Facing = null;
			}
		}
	}

    public class WaveSorter : IComparer<WaveData>
    {
        public int Compare(WaveData x, WaveData y)
        {
			var diffCompare = x.Difficulty.CompareTo(y.Difficulty);

			if(diffCompare == 0) {
				return Client.Game.Core.Game.Instance.Seed.RollAgainst(.5f)? -1 : 1;
			} else {
				return diffCompare;
			}
        }
    }
}

