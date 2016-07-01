 using System;
using System.Collections.Generic;
using Client.Game.Data;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Utils;
using Client.Game.Abilities.Timelines;

namespace Client.Game.Map
{
	using Game = Client.Game.Core.Game;


	public class RoomWaveManager
	{
		public delegate void ActorSpawned(Actor actor);

		public RoomWaveManager ()
		{
		}

		public float currentWaveTimer;
		public GeneratedWave CurrentWave;

		public delegate void WaveHandler();
		public event WaveHandler OnNewWave;
		public List<Actor> AliveActors = new List<Actor>();
		public List<DelayedActorSpawn> Delayed = new List<DelayedActorSpawn>();
		public bool DidStart = false;
		public TimelineRunner TimelineRunner;

		public void Start(GeneratedWave waveList) {
			
			CurrentWave = waveList;
			DidStart = true;
			TimelineRunner = new TimelineRunner();
			InitCurrentWave();
		}

		public void AddActor(Actor actor) {
			actor.OnDestroyed += (deadActor) => AliveActors.Remove(deadActor);
			AliveActors.Add(actor);
		}

		private void InitCurrentWave() {
			foreach( var spawnPair in CurrentWave.Generated ) {
				DelayedActorSpawn.Apply(spawnPair, 
					2f, 
					TimelineRunner, 
					(actor) => AddActor(actor));

				currentWaveTimer = CurrentWave.WaveData.Delay;

			}
			if(OnNewWave != null)
				OnNewWave();
		}

		public bool HasWavesRemaining {
			get {
				return CurrentWave != null && CurrentWave.Next != null;
			}
		}

		public bool WaveComplete {
			get {
				return AliveActors.Count == 0 && Delayed.Count == 0;
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

	public class DelayedActorSpawn : MonoBehaviour {

		GeneratedWave.GeneratedSpawn ActorData;
		float TTL;
		void Awake(){}
		void Start(){}

		RoomWaveManager.ActorSpawned Callback;

		void Update() {
			TTL -= Time.deltaTime;
			if(TTL <= 0f) {
				
				var actor = Game.Instance.ActorManager.Spawn(ActorData.Data);
				actor.transform.position = ActorData.Position;

				actor.SpawnData = new RoomData.Spawn(ActorData.Data);
				ActorUtils.FaceRelativeDirection(actor, ActorData.Facing);

				Callback(actor);

				GameObject.Destroy(this.gameObject);
			}
		}

		public static DelayedActorSpawn Apply(GeneratedWave.GeneratedSpawn spawn, float TTL, TimelineRunner Runner, RoomWaveManager.ActorSpawned callback) {
			var go = new GameObject();
			go.transform.position = spawn.Position;
			var das = go.AddComponent<DelayedActorSpawn>();
			das.ActorData = spawn;
			das.TTL = TTL;
			das.Callback = callback;
			var tl = TimelineDataTable.SMALL_SPAWN_TL;
			tl.Duration = TTL;
			Runner.Play(TimelineDataTable.SMALL_SPAWN_TL, go, Vector3.zero);

			return das;
			
		}

	}

	
}

