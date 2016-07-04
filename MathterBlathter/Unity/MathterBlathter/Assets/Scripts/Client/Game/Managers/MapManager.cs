using System;
using Client.Game.Data;
using Client.Game.Map;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;
using System.Linq;
using System.Collections;

namespace Client.Game.Managers
{
	using Game = Game.Core.Game;
	using RoomTypeMap = Dictionary<RoomType, List<Room>>;
	public class MapManager : IGameManager
	{
		
		public List<Room> Rooms;
		public Room CurrentRoom;

		public delegate void RoomEntered(Actor actor, Room oldRoom, Room newRoom);
		public event RoomEntered OnRoomEntered;
		public event Room.OnUnlock OnCurrentRoomUnlocked;

		private RoomTypeMap typeIndices = new RoomTypeMap();

		public MapManager ()
		{
			
		}

			
		public List<Room> RoomsOfType(RoomType type) {
			//if this fails, we need to have built an index
			return typeIndices[type];
		}

		public void SetRooms (List<Room> rooms)
		{
			Rooms = rooms;
			AddIndices(RoomType.Store, rooms, typeIndices);
			AddIndices(RoomType.Boss, rooms, typeIndices);
		}

		private void AddIndices(RoomType type, List<Room> rooms, RoomTypeMap mapping) {
			List<Room> buffer;
			if(!mapping.TryGetValue(type, out buffer)) {
				buffer = new List<Room>();
			}
			foreach( var room in rooms ) {
				if((room.data.Type & type) == type) {
					buffer.Add(room);
				}
			}
			mapping[type] = buffer;
		}	



		public void SetPlayerCharacter (PlayerCharacter player)
		{
			EnterRoom(player, Rooms[0]);
			//this is some bullshit, but the door triggers invoke when created on the same frame as the player
			player.GameObject.GetComponent<ActorRef>().StartCoroutine(LateInit());
		}

		private bool didLateInit = false;
		private IEnumerator LateInit() {
			yield return new WaitForSeconds(.5f);
			foreach ( var door in Rooms.SelectMany(p => p.Doors) ) {
				var box = door.GameObject.AddComponent<BoxCollider2D>();
				box.isTrigger = true;
				//door.Close();
			}

			didLateInit = true;
		}





		public void Shutdown ()
		{
			foreach( var room in Rooms) {
				GameObject.Destroy(room.GameObject);
			}
			typeIndices.Clear();
			Rooms.Clear();
		}

		public void Start (Game game)
		{
			Rooms.ForEach (p => p.Draw(game));
		}


		public void EnterRoom (Actor actor, Room room, DoorActor throughDoor = null)
		{
			if(CurrentRoom == room) {
				return;
			}

			if(CurrentRoom != null) {
				CurrentRoom.PlayerLeft(actor);
				CurrentRoom.UnlockEvent -= OnCurrentUnlocked;
			}

			var leavingRoom = CurrentRoom;

			CurrentRoom = room;
			CurrentRoom.PlayerEntered(actor, throughDoor);

			Debug.Log("Entering Room: " + room.data.Id);

			if(throughDoor == null) {
				actor.transform.position = room.roomCenter;
			}


			if(OnRoomEntered != null) 
				OnRoomEntered(actor, leavingRoom, room);
			
			CurrentRoom.UnlockEvent += OnCurrentUnlocked;

		}

		void OnCurrentUnlocked (Room room)
		{
			OnCurrentRoomUnlocked(room);
		}

		public void Update (float dt)
		{
			if(CurrentRoom != null && didLateInit) CurrentRoom.Update(dt);	
		}

	}
}

