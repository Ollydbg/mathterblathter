﻿using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Abilities;
using Client.Game.Data;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.States;

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


		public PlayerCharacter PossessedActor;

		public InputManager InputManager;
		public RoomManager RoomManager;
		public CameraManager CameraManager;
		public AbilityManager AbilityManager;
		public ActorManager ActorManager;
		public UIManager UIManager;
		public FSM States;
		private IGameManager[] Managers;


		public Seed Seed {
			get; private set;
		}

		public Game ()
		{

		}


		private void Init() {

			this.Seed = new Seed(UnityEngine.Random.Range(0, int.MaxValue));

			CreateManagers();
			States.Start(this);

		}

		private void CreateManagers() {
			var tmp = new List<IGameManager> ();

			States = new FSM();

			InputManager = new InputManager();
			AbilityManager = new AbilityManager ();
			ActorManager = new ActorManager(this);
			RoomManager = new RoomManager();
			CameraManager = new CameraManager();
			UIManager = new UIManager(this);


			Managers = tmp.ToArray ();


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

