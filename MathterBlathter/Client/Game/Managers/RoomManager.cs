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

	public class RoomManager : IGameManager
	{
		
		public List<Room> Rooms;
		public Room CurrentRoom;

		public RoomManager ()
		{
			
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
				var box = door.GameObject.AddComponent<BoxCollider>();
				box.isTrigger = true;
				//door.Close();
			}

			didLateInit = true;
		}


		int numRoomsToGenerate() {
			var solod = MockRoomData.GetAll().Count(p => p.Solo);
			return solod > 0 ? solod : MockMapData.Map1.NumberOfRooms;
		}

		List<RoomData> availableRooms() {
			var solod = MockRoomData.GetAll().Where( p=> p.Solo).ToList();
			if(solod.Count > 0) {
				return solod;
			} else {
				return MockRoomData.GetAll().Where( p=>!p.Mute).ToList();
			}
		}

		public void Shutdown ()
		{
			foreach( var room in Rooms) {
				GameObject.Destroy(room.GameObject);
			}
			Rooms.Clear();
		}

		public void Start (Game game)
		{
			var generator = new MapGenerator ();
			Rooms = generator.GenerateFromDataSet (availableRooms(), numRoomsToGenerate());
			Rooms.ForEach (p => p.Draw());
		}


		public void EnterRoom (Actor actor, Room room, DoorActor throughDoor = null)
		{
			if(CurrentRoom == room) {
				return;
			}

			if(CurrentRoom != null) {
				CurrentRoom.PlayerLeft(actor);
			}

			CurrentRoom = room;
			CurrentRoom.PlayerEntered(actor, throughDoor);

			if(throughDoor == null) {
				actor.transform.position = room.roomCenter;
			}

		}

		public void Update (float dt)
		{
			if(CurrentRoom != null && didLateInit) CurrentRoom.Update(dt);	
		}

	}
}

