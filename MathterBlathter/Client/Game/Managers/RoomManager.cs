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

		private IEnumerator LateInit() {
			yield return new WaitForSeconds(.5f);
			foreach ( var door in Rooms.SelectMany(p => p.Doors) ) {
				var box = door.GameObject.AddComponent<BoxCollider>();
				box.isTrigger = true;
			}

		}

		public void Shutdown ()
		{
			
		}

		public void Start (Game game)
		{
			//make rooms
			var mocked = MockRoomData.GetAll();

			var generator = new MapGenerator ();
			Rooms = generator.GenerateFromDataSet (mocked, 2);
			Rooms.ForEach (p => p.Draw());

		}


		public void CreateRoomObjects(Room room) {

			foreach (var spawn in room.data.Spawns) {
				if(room.TryRecordSpawn(spawn)) {
					
					var spawned = Game.Instance.ActorManager.Spawn(MockActorData.FromId(spawn.ActorId));
					//var spawned = Game.Instance.ActorManager.Spawn <Character> (MockActorData.FromId(spawn.ActorId));
					spawned.transform.position = spawn.RoomPosition + room.Position;
					
					if(spawned.Data.ActorType == ActorType.Enemy) {
						var enemyChar = (Character)spawned;
						enemyChar.Brain = new Client.Game.AI.Brain (spawned);
						var seekToAction = new Client.Game.AI.Actions.SeekToPlayer ();
						var fireAtAction = new Client.Game.AI.Actions.FireAtPlayer ();
						seekToAction.Next = fireAtAction;
						fireAtAction.Next = seekToAction;
						enemyChar.Brain.CurrentAction = seekToAction;
					}
				}
			}
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

			CreateRoomObjects(room);

			if(throughDoor == null) {
				actor.transform.position = room.roomCenter;
			}

		}

		public void Update (float dt)
		{
		}

	}
}

