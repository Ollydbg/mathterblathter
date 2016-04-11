using System;
using Client.Game.Data;
using Client.Game.Map;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Managers
{
	using Game = Game.Core.Game;

	public class RoomManager : IGameManager
	{
		

		public List<Room> Rooms;


		public RoomManager ()
		{
			
		}


		public void Init ()
		{
			//make rooms
			var mocked = MockRoomData.GetAll();

			var generator = new MapGenerator ();
			Rooms = generator.GenerateFromDataSet (mocked, 5);
			Rooms.ForEach (p => p.Draw());

			//init spawns just for Head
			var head = Rooms[0];
			CreateRoomObjects (head);
		}


		public void CreateRoomObjects(Room room) {
			foreach (var spawn in room.data.Spawns) {
				
				var enemyTest = Game.Instance.Spawn <Character> (spawn.Character);

				enemyTest.Brain = new Client.Game.AI.Brain (enemyTest);

				var seekToAction = new Client.Game.AI.Actions.SeekToPlayer ();
				var fireAtAction = new Client.Game.AI.Actions.FireAtPlayer ();
				seekToAction.Next = fireAtAction;
				fireAtAction.Next = seekToAction;
				enemyTest.Brain.CurrentAction = seekToAction;

			}
		}

		public void EnterRoom (Actor actor, Room room, DoorActor throughDoor = null)
		{
			//put on floor for now
			if (throughDoor == null) {
				actor.transform.position = room.roomCenter;
			}
			
		}

		public void Update (float dt)
		{
			
		}

	}
}

