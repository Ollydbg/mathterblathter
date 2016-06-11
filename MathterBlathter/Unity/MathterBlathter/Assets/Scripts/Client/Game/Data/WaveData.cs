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
		public float Delay = 4f;
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

			public GeneratedSpawn(CharacterData data, Vector3 position) {
				this.Data = data;
				this.Position = position;
			}
		}
	}

    public class WaveSorter : IComparer<WaveData>
    {
        public int Compare(WaveData x, WaveData y)
        {
			return x.Difficulty.CompareTo(y.Difficulty);
        }
    }
}

