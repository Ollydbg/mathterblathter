using System;
using Client.Game.Core.Managers;
using System.Collections.Generic;
using Client.Game.Core.Actors;
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
		public Actor PossessedActor;

		IGameManager[] Managers;

		public Game ()
		{

		}

		private void Init() {
			PossessedActor = Spawn ("Actors/Arthur/Prefabs/arthur_prefab");
			
			var tmp = new List<IGameManager> ();
			tmp.Add(new InputManager());
			
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

		public Actor Spawn(string name) {

			var actor = new Actor ();

			var loaded = Resources.Load (name);

			var obj = (GameObject)GameObject.Instantiate (loaded);

			BindActor (actor, obj);

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

