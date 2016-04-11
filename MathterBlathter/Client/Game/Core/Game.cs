using System;
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


		Dictionary<int, Actor> Actors = new Dictionary<int, Actor>();
		public Character PossessedActor;

		public InputManager InputManager;
		public RoomManager RoomManager;
		public CameraManager CameraManager;
		public AbilityManager AbilityManager;

		private IGameManager[] Managers;

		public Game ()
		{

		}

		private void Init() {

			CreateManagers();

			PossessedActor = Spawn<Character> (ActorDataMocker.PLAYER_TEST);
			CameraManager.TargetTransform = PossessedActor.transform;
			new List<IGameManager>(Managers).ForEach(p => p.Init ());

			RoomManager.EnterRoom(PossessedActor, RoomManager.Rooms[0]);
		}

		private void CreateManagers() {
			var tmp = new List<IGameManager> ();
			InputManager = new InputManager();
			RoomManager = new RoomManager();
			CameraManager = new CameraManager();
			AbilityManager = new AbilityManager ();
			
			tmp.Add (InputManager);
			tmp.Add (AbilityManager);
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

			while (deferredAds.Count > 0) {
				var actor = deferredAds.Dequeue ();
				Actors.Add (actor.Id, actor);
			}

			while (deferredRemoves.Count > 0) {
				var actor = deferredRemoves.Dequeue ();
				Actors.Remove (actor.Id);
				GameObject.Destroy (actor.GameObject);
			}
		}

		public T Spawn<T>(CharacterData data) where T : Character, new() {
			T actor = Spawn<T> (data.ResourcePath);
			actor.LoadFromData (data);
			return actor;
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


		private Queue<Actor> deferredRemoves = new Queue<Actor> ();
		public void RemoveActor(Actor actor) {
			deferredRemoves.Enqueue (actor);
		}

		private Queue<Actor> deferredAds = new Queue<Actor>();
		void BindActor(Actor actor, GameObject obj) {
			obj.AddComponent<ActorRef> ();
			obj.GetComponent<ActorRef> ().Actor = actor;

			actor.GameObject = obj;

			deferredAds.Enqueue (actor);

		}

	}
}

