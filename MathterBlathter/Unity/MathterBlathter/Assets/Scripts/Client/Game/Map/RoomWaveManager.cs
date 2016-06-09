using System;
using System.Collections.Generic;
using Client.Game.Data;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Map
{
	using Game = Client.Game.Core.Game;


	public class RoomWaveManager
	{
		public RoomWaveManager ()
		{
		}

		public List<GeneratedWave> Waves;
		public int currentWaveIndex = -1;

		public GeneratedWave CurrentWave {
			get {
				return Waves[currentWaveIndex];
			}
		}
		public List<Actor> AliveActors = new List<Actor>();
		public bool DidStart = false;



		public void Start(List<GeneratedWave> waves) {
			Waves = waves;
			DidStart = true;
			Advance();
		}

		public bool LastWave {
			get {
				return Waves.Count == 0 || currentWaveIndex == Waves.Count;
			}
		}

		public bool WaveComplete {
			get {
				return AliveActors.Count == 0;
			}
		}

		public Boolean IsComplete {
			get {
				return DidStart 
					&& LastWave
					&& WaveComplete;
				}
		}

		public void Advance() {
			currentWaveIndex ++;

			if(!IsComplete) {
				foreach( var spawnPair in CurrentWave.Generated ) {
					var actor = Game.Instance.ActorManager.Spawn(spawnPair.Data);
					actor.transform.position = spawnPair.Position;
					actor.OnDestroyed += (deadActor) => AliveActors.Remove(deadActor);

					actor.SpawnData = new RoomData.Spawn(spawnPair.Data);
					actor.SpawnData.Facing = Vector3.right;

					AliveActors.Add(actor);
				}
			}
			
		}

		public void Update(float dt) {
			if(DidStart && WaveComplete) {
				Advance();
			}
		}
	}
}

