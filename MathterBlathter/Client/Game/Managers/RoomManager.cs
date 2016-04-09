using System;
using Client.Game.Data;
using Client.Game.Map;
using System.Collections.Generic;
using Client.Game.Actors;

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
			var mockedRooms = new RoomDataMocker().Mock(4);
			var generator = new MapGenerator ();
			Rooms = generator.GenerateFromDataSet (mockedRooms);
			Rooms.ForEach (p => p.Draw());

			//init spawns just for Head
			var head = Rooms[0];
			CreateRoomObjects (head);
		}

		public void CreateRoomObjects(Room room) {
			foreach (var spawn in room.data.Spawns) {
				Game.Instance.Spawn <Character> (spawn.Character.ResourcePath);
			}
		}

		public void EnterRoom (Actor actor, Room room, DoorActor throughDoor = null)
		{
			//put on floor for now
			if (throughDoor == null) {
				actor.transform.position = room.floorCenter;
			}
			
		}

		public void Update (float dt)
		{
			
		}

	}
}

