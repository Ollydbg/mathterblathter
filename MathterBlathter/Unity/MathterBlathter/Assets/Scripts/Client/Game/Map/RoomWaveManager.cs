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
		public delegate void ActorSpawned(DelayedActorSpawn pending, Actor actor);

		public RoomWaveManager ()
		{
		}

		public float currentWaveTimer;
		public GeneratedWave CurrentWave;

		public delegate void WaveHandler();
		public event WaveHandler OnActorEntered;
		public List<Actor> AliveActors = new List<Actor>();
		public List<DelayedActorSpawn> PendingActors = new List<DelayedActorSpawn>();
		public bool DidStart = false;
		public TimelineRunner TimelineRunner;

		public void Start(GeneratedWave waveList) {
			
			CurrentWave = waveList;
			DidStart = true;
			TimelineRunner = new TimelineRunner();
			InitCurrentWave();
		}

		public void AddActor(Actor actor) {
			AliveActors.Add(actor);
			if(OnActorEntered != null)
				OnActorEntered();
		}

		private void ConvertPending(DelayedActorSpawn pending, Actor actor) {
			PendingActors.Remove(pending);
			AddActor(actor);
			//TimelineRunner.Play(TimelineDataTable.SMALL_ACTOR_ENTERED_TL, actor, Vector3.zero);
		}

		private void InitCurrentWave() {
			float i = 0f;
			foreach( var spawnPair in CurrentWave.Generated ) {
				var pending = DelayedActorSpawn.Apply(spawnPair, 
					.75f + .1f*i++, 
					TimelineRunner, 
					ConvertPending);
				
				PendingActors.Add(pending);

				currentWaveTimer = CurrentWave.WaveData.Delay;

			}
		}

		public bool HasWavesRemaining {
			get {
				return CurrentWave != null && CurrentWave.Next != null;
			}
		}

		public bool WaveComplete {
			get {
				return AliveActors.Count == 0 && PendingActors.Count == 0;
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

				if(ActorData.Facing.HasValue)
					actor.WeaponController.AimDirection = ActorData.Facing.GetValueOrDefault(Vector3.right);


				Callback(this, actor);

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

			Runner.Play(tl, go, Vector3.zero);

			return das;
			
		}

	}

	
}

