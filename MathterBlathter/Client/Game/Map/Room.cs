using System;
using System.Collections.Generic;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Core;
using Client.Game.Actors;
using Client.Game.Enums;

namespace Client.Game.Map
{
	using Game = Client.Game.Core.Game;

	public class Room
	{


		public int X;
		public int Y;
		public int Width;
		public int Height;
		public RoomData data;
		public int Id;
		private static int LastId = 0;
		public GameObject GameObject;

		List<int> unlockBlockers = new List<int>();


		public Dictionary<Guid, bool> SpawnHistory = new Dictionary<Guid, bool>();

		public List<Light> Lights;

		public List<DoorActor> Doors = new List<DoorActor>();
		public interface IRoomDrawer {
			GameObject Draw (Room room);
		}

		public override int GetHashCode ()
		{
			return Id;
		}

		private static IRoomDrawer Drawer = new MeshRoomDrawer();

		public Vector3 Position {
			get {return new Vector3(X,Y); }
		}

		public Vector3 roomCenter {
			get {
				return new Vector3 ((float)(X + Width * .5f), Height * .5f);
			}
		}

		public Vector3 floorCenter {
			get {
				return new Vector3(0, Bottom, 0);
			}
		}

		public float Left { 
			get {
				return (float)(X - .5*Width);
			}
		}

		public float Right {
			get {
				return (float)(X + .5 * Width);
			}
		}

		public float Top {
			get {
				return (float)(Y + .5 * Height);
			}
		}

		public float Bottom {
			get {
				return (float)(Y - .5 * Height);
			}
		}

		public bool TryRecordSpawn (RoomData.Spawn spawn)
		{
			if(spawn.SpawnType == RoomSpawnType.EveryRoomEntrance)
				return true;

			if(SpawnHistory.ContainsKey(spawn.Guid)) {
				return false;
			} 

			SpawnHistory[spawn.Guid] = true;
			return true;
		}

		public void PlayerLeft (Actor actor)
		{
		}

		public void PlayerEntered (Actor actor, DoorActor throughDoor)
		{
			Lights.ForEach(l => l.gameObject.SetActive(true));

			SpawnObjects();
		}
		

		public Room (RoomData data)
		{
			this.Id = ++LastId;
			this.data = data;
			initFromData (data);
		}

		public void SpawnObjects() {
			foreach (var spawn in data.Spawns) {
				if(TryRecordSpawn(spawn)) {

					var actor = Game.Instance.ActorManager.Spawn(MockActorData.FromId(spawn.ActorId));
					if(actorBlocksRoomUnlock(actor)) {
						unlockBlockers.Add(actor.Id);
					}
					actor.transform.position = spawn.RoomPosition + Position;

				}
			}
		}

		bool actorBlocksRoomUnlock (Actor actor)
		{
			return actor.ActorType == ActorType.Enemy;
		}

		public void initFromData (RoomData data)
		{
			this.Width = data.Width;
			this.Height = data.Height;
		}

		public void EnterGame(Game game) { 
			
		}

		public void Draw() {
			GameObject = Drawer.Draw (this);
		}

		private bool Locked {
			get {
				return Doors.Count > 0 && Doors[0].isClosed;
			}
		}

		/*
		public void Update(float dt) {
			
			if(Locked) {
				Actor tmp;
				bool canUnlock = unlockBlockers.All(p => !Game.Instance.ActorManager.TryFromId(p, out tmp));
				if(canUnlock) {
					Doors.ForEach(p => p.Open()); 
				}
			}

		}*/

	}
}

