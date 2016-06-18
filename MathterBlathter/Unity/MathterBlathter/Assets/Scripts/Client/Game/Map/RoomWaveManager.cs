 using System;
using System.Collections.Generic;
using Client.Game.Data;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Utils;

namespace Client.Game.Map
{
	using Game = Client.Game.Core.Game;


	public class RoomWaveManager
	{
		public RoomWaveManager ()
		{
		}

		public float currentWaveTimer;
		public GeneratedWave CurrentWave;

		
		public List<Actor> AliveActors = new List<Actor>();
		public bool DidStart = false;



		public void Start(GeneratedWave waveList) {
			
			CurrentWave = waveList;
			DidStart = true;
			InitCurrentWave();
		}
		
		private void InitCurrentWave() {
			foreach( var spawnPair in CurrentWave.Generated ) {

				var actor = Game.Instance.ActorManager.Spawn(spawnPair.Data);
				actor.transform.position = spawnPair.Position;
				actor.OnDestroyed += (deadActor) => AliveActors.Remove(deadActor);
				
				actor.SpawnData = new RoomData.Spawn(spawnPair.Data);
				ActorUtils.FaceRelativeDirection(actor, spawnPair.Facing);
				
				currentWaveTimer = CurrentWave.WaveData.Delay;
				AliveActors.Add(actor);

			}
		}

		public bool HasWavesRemaining {
			get {
				return CurrentWave != null && CurrentWave.Next != null;
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
					&& !HasWavesRemaining
					&& WaveComplete;
				}
		}

		public void Advance() {
			if(HasWavesRemaining) {
				CurrentWave = CurrentWave.Next;
				
				InitCurrentWave();
			}
			
		}

		public void Update(float dt) {
			if(HasWavesRemaining) {
				currentWaveTimer -= dt;
				if(DidStart && (WaveComplete || currentWaveTimer <= 0f)) {
					Advance();
				}
			}
		}
	}
}

