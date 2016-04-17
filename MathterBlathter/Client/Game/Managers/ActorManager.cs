﻿using System;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Data;
using System.Linq;
using Client.Game.Map;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class ActorManager : IGameManager
	{
		Dictionary<int, Actor> Actors = new Dictionary<int, Actor>();

		Game Game;

		private Dictionary<ActorType, Type> ActorTypeLookup;
		
		public ActorManager (Game game)
		{
			ActorTypeLookup = new Dictionary<ActorType, Type>();

			ActorTypeLookup[ActorType.Player] = typeof(PlayerCharacter);
			ActorTypeLookup[ActorType.Pickup] = typeof(Pickup);
			ActorTypeLookup[ActorType.Enemy] = typeof(Character);
			ActorTypeLookup[ActorType.Friendly] = typeof(Character);
			ActorTypeLookup[ActorType.Door] = typeof(DoorActor);
			ActorTypeLookup[ActorType.Projectile] = typeof(ProjectileActor);

			Game = game;
		}

		#region IGameManager implementation

		public void SetPlayerCharacter (PlayerCharacter player)
		{
		}


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


		//so nasty
		public IEnumerable<T> GetActorsOfType<T>() where T : Actor {
			return this.Actors.Values.Where(p => p.GetType() == typeof(T)).Cast<T>();
		}

		public Actor Spawn(CharacterData data) {
			//read type from the data
			var type = ActorTypeLookup[data.ActorType];
			var actor = Spawn(data.ResourcePath, type);
			actor.LoadFromData(data);
			actor.EnterGame(this.Game);
			return actor;
		}

		public T Spawn<T>(CharacterData data) where T : Actor, new() {
			return (T)Spawn(data);
		}


		public Actor Spawn(string resourceName, Type type) {

			var actor = (Actor)Activator.CreateInstance(type);
			GameObject obj;
			if (resourceName != null) {
				var loaded = Resources.Load (resourceName);
				obj = (GameObject)GameObject.Instantiate (loaded);
			} else {
				obj = new GameObject ();
			}

			BindActor (actor, obj);

			return actor;
		}

		/*
		public T Spawn<T>(string resourceName) where T : Actor, new() {
			return (T)Spawn(resourceName, typeof(T));
		}
		*/


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

