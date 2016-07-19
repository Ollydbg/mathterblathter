using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Abilities;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.States;
using UnityEngine.Audio;

namespace Client.Game.Core
{
	public class Game
	{
		public static Game Instance { get; private set; }

		public bool Paused;

		public PlayerCharacter PossessedActor;

		public InputManager InputManager;
		public MapManager RoomManager;
		public CameraManager CameraManager;
		public AbilityManager AbilityManager;
		public ActorManager ActorManager;
		public UIManager UIManager;
		public WorldFXManager WorldFXManager;
		public FSM States;
		public MusicManager MusicManager;

		public AudioMixer AudioMixer;

		public Seed Seed {
			get; private set;
		}

		public Game ()
		{
			Instance = this;
			Init();
		}

		
		float skipTime = 0f;
		public void SkipTime (float duration, float amt)
		{
			skipTime += duration;
			Time.timeScale = amt;
		}
		

		private void Init() {

			this.Seed = new Seed(DateTime.UtcNow.Millisecond);
			AudioMixer = Resources.Load("AudioMix/GameMix") as AudioMixer;

			CreateManagers();
			States.Start(this);

		}

		private void CreateManagers() {
			
			States = new FSM();

			InputManager = new InputManager();
			AbilityManager = new AbilityManager ();
			ActorManager = new ActorManager(this);
			RoomManager = new MapManager();
			CameraManager = new CameraManager();
			UIManager = new UIManager(this);
			WorldFXManager = new WorldFXManager();
			MusicManager = new MusicManager();

		}

		public void Restart ()
		{
			States.CurrentState = new MainMenuState();
		}



		public void Update(float dt) {
			
			if(skipTime > 0f) {
				skipTime-= Time.unscaledDeltaTime;
			} else {
				Time.timeScale = 1f;
			}
			States.Update(dt);
		}


		public void FixedUpdate() {
			ActorManager.FixedUpdate();
		}



	}
}

