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
	public class Room
	{


		public int X;
		public int Y;
		public int Width;
		public int Height;
		public RoomData data;
		public int Id;
		private static int LastId = 0;


		public Dictionary<Guid, bool> SpawnHistory = new Dictionary<Guid, bool>();

		public List<Light> Lights;

		public List<DoorActor> Doors = new List<DoorActor>();
		public interface IRoomDrawer {
			void Draw (Room room);
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
		}
		

		public Room (RoomData data)
		{
			this.Id = ++LastId;
			this.data = data;
			initFromData (data);
		}


		public void initFromData (RoomData data)
		{
			this.Width = data.Width;
			this.Height = data.Height;
		}

		public void EnterGame(Game.Core.Game game) { 
			
		}

		public void Draw() {
			Drawer.Draw (this);
		}

	}
}

