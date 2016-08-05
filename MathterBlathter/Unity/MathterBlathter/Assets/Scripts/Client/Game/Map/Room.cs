using System;
using System.Collections.Generic;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Core;
using Client.Game.Actors;
using Client.Game.Enums;
using Client.Game.Utils;
using Client.Game.Attributes;

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
		public ZoneData Zone;
		public RoomTraversalGrid Grid;

		public int Id;
		private static int LastId = 0;
		public GameObject GameObject;
		public GameObject SetPiecePrefab;

		public delegate void OnUnlock(Room room);
		public event OnUnlock UnlockEvent;

		public List<Light> Lights;
		private List<Actor> Spawns = new List<Actor>();
		public List<DoorActor> Doors = new List<DoorActor>();
		public List<DoorActor> SealedDoors = new List<DoorActor>();
		

		public interface IRoomDrawer {
			GameObject Draw (Room room, Game inGame);
		}

		public RoomType Type = RoomType.Normal;
		public RoomWaveManager Waves = new RoomWaveManager();

		public override int GetHashCode ()
		{
			return Id;
		}

		private static IRoomDrawer Drawer = new TMXRoomDrawer();

		public Vector3 Position {
			get {return new Vector3(X,Y); }
		}

		public Vector3 roomCenter {
			get {
				return new Vector3 ((float)(X + Width * .5f), Y + Height * .5f);
			}
		}

		public Vector3 floorCenter {
			get {
				return new Vector3(0, Bottom, 0);
			}
		}

		public float Left { 
			get {
				return (float)(X);
			}
		}

		public float Right {
			get {
				return (float)(X + Width);
			}
		}

		public float Top {
			get {
				return (float)(Y + Height);
			}
		}

		public float Bottom {
			get {
				return (float)(Y);
			}
		}

		public Rect RoomRect {
			get {
				return new Rect(X, Y, Width, Height);
			}
		}

		public void Seal(DoorActor door) {
			door.IsSealed = true;
			this.Doors.Remove(door);
			this.SealedDoors.Add(door);
		}

		public void PlayerLeft (Actor actor)
		{
			if(SetPiecePrefab != null)
				GameObject.Destroy(SetPiecePrefab);

			Lights.ForEach(l => l.gameObject.SetActive(false));
			Spawns.ForEach( p => p.Destroy());
			Spawns.Clear();

		}

		public void PlayerEntered (Actor actor, DoorActor throughDoor)
		{
			this.Grid = new RoomTraversalGrid(this);
			Lights.ForEach(l => l.gameObject.SetActive(true));
			SpawnObjects(actor);
		}
		

		public Room (RoomData data)
		{
			this.Id = ++LastId;
			this.data = data.Clone();
			initFromData (data);
		}

		public void SpawnObjects(Actor forActor) {

			if(this.SpawnsWaves) {
				if(!Waves.IsComplete) {
					var difficulty = forActor.Attributes[ActorAttributes.WaveDifficulty];
					var waveData = new RoomWaveGenerator().Generate(this, forActor);
					Waves.Start(waveData);

					this.Doors.ForEach(p => p.Close());

				}
			}


			foreach (var spawn in data.Spawns) {
				var actor = Game.Instance.ActorManager.Spawn(spawn, this);
				Spawns.Add(actor);
			}
			

			if(data.SetPiece != null) {
				SetPiecePrefab = (GameObject)GameObject.Instantiate(Resources.Load(data.SetPiece.PrefabPath));
				SetPiecePrefab.transform.position = roomCenter;
			}

		}

		public void initFromData (RoomData data)
		{
			this.Width = data.Width;
			this.Height = data.Height;
			this.Type = data.Type;
		}


		public void Draw(Game game) {
			GameObject = Drawer.Draw (this, game);
		}

		private bool Locked {
			get {
				return Doors.Count > 0 && Doors[0].isClosed;
			}
		}


		public void UnlockDoors() {
			Doors.ForEach(p => p.Open()); 
			if(UnlockEvent != null) {
				UnlockEvent(this);
			}
		}

		public void Update(float dt) {
			if(Locked) {
				this.Waves.Update(dt);
				if(this.Waves.IsComplete) 
					UnlockDoors();

			}

		}


		public bool SpawnsWaves {
			get {
				return (Type & RoomType.NoWaves) == 0;
			}
		}

	}
}

