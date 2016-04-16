﻿using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Abilities;
using Client.Game.Data;

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


		public Character PossessedActor;

		public InputManager InputManager;
		public RoomManager RoomManager;
		public CameraManager CameraManager;
		public AbilityManager AbilityManager;
		public ActorManager ActorManager;

		private IGameManager[] Managers;

		public Game ()
		{

		}

		private void Init() {

			CreateManagers();
			StartGame();
		}

		private void CreateManagers() {
			var tmp = new List<IGameManager> ();
			InputManager = new InputManager();
			ActorManager = new ActorManager(this);
			RoomManager = new RoomManager();
			CameraManager = new CameraManager();
			AbilityManager = new AbilityManager ();
			
			tmp.Add (InputManager);
			tmp.Add (AbilityManager);
			tmp.Add (RoomManager);
			tmp.Add (ActorManager);
			tmp.Add (CameraManager);

			Managers = tmp.ToArray ();
		}

		public void Restart ()
		{
			new List<IGameManager>(Managers).ForEach(p => p.Shutdown());

			StartGame();
		}

		public void StartGame() {
			
			PossessedActor = ActorManager.Spawn<PlayerCharacter> (MockActorData.PLAYER_TEST);
			CameraManager.TargetTransform = PossessedActor.transform;

			new List<IGameManager>(Managers).ForEach(p => p.Start (this));

			RoomManager.EnterRoom(PossessedActor, RoomManager.Rooms[0]);
		}

		public void Update(float dt) {

			for (int i = 0; i < Managers.Length; i++) {
				Managers [i].Update (dt);
			}


		}

		public void FixedUpdate() {
			ActorManager.FixedUpdate();
		}



	}
}

