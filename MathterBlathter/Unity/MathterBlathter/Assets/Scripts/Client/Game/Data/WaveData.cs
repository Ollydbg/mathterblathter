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

		public WaveData ()
		{
			
		}


	}

	public class GeneratedWave : WaveData {

		public List<GeneratedSpawn> Generated = new List<GeneratedSpawn>();

		public class GeneratedSpawn {
			public CharacterData Data;
			public Vector3 Position;

			public GeneratedSpawn(CharacterData data, Vector3 position) {
				this.Data = data;
				this.Position = position;
			}
		}
	}
}

