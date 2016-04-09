using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;

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


		Dictionary<int, Actor> Actors = new Dictionary<int, Actor>();
		public Character PossessedActor;

		public InputManager InputManager;
		public RoomManager RoomManager;
		public CameraManager CameraManager;

		private IGameManager[] Managers;

		public Game ()
		{

		}

		private void Init() {

			CreateManagers();

			PossessedActor = Spawn<Character> ("Actors/Arthur/Prefabs/arthur_prefab");

			new List<IGameManager>(Managers).ForEach(p => p.Init ());

			RoomManager.EnterRoom(PossessedActor, RoomManager.Rooms[0]);
		}

		private void CreateManagers() {
			var tmp = new List<IGameManager> ();
			InputManager = new InputManager();
			RoomManager = new RoomManager();
			CameraManager = new CameraManager();
			
			tmp.Add(InputManager);
			tmp.Add (RoomManager);
			tmp.Add (CameraManager);
			Managers = tmp.ToArray ();
		}

		public void Update(float dt) {

			for (int i = 0; i < Managers.Length; i++) {
				Managers [i].Update (dt);
			}

			foreach( var kvp in Actors) 
				kvp.Value.Update(dt);
		}

		public T Spawn<T>(string resourceName) where T : Actor, new() {

			var actor = new T ();
			GameObject obj;
			if (resourceName != null) {
				var loaded = Resources.Load (resourceName);
				obj = (GameObject)GameObject.Instantiate (loaded);
			} else {
				obj = new GameObject ();
			}

			BindActor (actor, obj);

			actor.EnterGame(this);

			return actor;
		}


		void BindActor(Actor actor, GameObject obj) {
			obj.AddComponent<ActorRef> ();
			obj.GetComponent<ActorRef> ().Actor = actor;

			actor.GameObject = obj;

			Actors.Add (actor.Id, actor);

		}


		
	}
}

