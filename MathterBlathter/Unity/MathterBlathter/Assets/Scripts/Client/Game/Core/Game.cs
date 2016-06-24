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
		private static Game _instance;
		public static Game Instance {
			get {
				if( _instance == null) {
					_instance = new Game();
					_instance.Init();
				}
				return _instance;
			}
		}

		public bool Paused;

		public PlayerCharacter PossessedActor;

		public InputManager InputManager;
		public RoomManager RoomManager;
		public CameraManager CameraManager;
		public AbilityManager AbilityManager;
		public ActorManager ActorManager;
		public UIManager UIManager;
		public WorldFXManager WorldFXManager;
		public FSM States;

		public AudioMixer AudioMixer;

		public Seed Seed {
			get; private set;
		}

		public Game ()
		{

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
			RoomManager = new RoomManager();
			CameraManager = new CameraManager();
			UIManager = new UIManager(this);
			WorldFXManager = new WorldFXManager();
		}

		public void Restart ()
		{
			States.CurrentState = new InitState();
		}



		public void Update(float dt) {
			States.Update(dt);
		}


		public void FixedUpdate() {
			ActorManager.FixedUpdate();
		}



	}
}

