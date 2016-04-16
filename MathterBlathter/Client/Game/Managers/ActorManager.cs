using System;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class ActorManager : IGameManager
	{
		Dictionary<int, Actor> Actors = new Dictionary<int, Actor>();

		Game Game;

		public ActorManager (Game game)
		{
			Game = game;
		}

		#region IGameManager implementation

		public void Start (Game game)
		{
		}

		public void Update (float dt)
		{
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

		public void FixedUpdate() {
			foreach( var kvp in Actors) 
				kvp.Value.FixedUpdate();
		}


		public void Shutdown ()
		{
			
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

			actor.EnterGame(this.Game);

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

		#endregion
	}
}

