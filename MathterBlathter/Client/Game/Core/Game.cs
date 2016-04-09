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

		IGameManager[] Managers;

		public Game ()
		{

		}

		private void Init() {
			PossessedActor = Spawn<Character> ("Actors/Arthur/Prefabs/arthur_prefab");
			
			var tmp = new List<IGameManager> ();
			tmp.Add(new InputManager());
			tmp.Add (new RoomManager ());
			tmp.Add (new CameraManager ());
			tmp.ForEach(p=>p.Init());
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

