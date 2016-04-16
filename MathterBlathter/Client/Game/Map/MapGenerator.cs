using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using Client.Game.Core;
using Client.Game.Actors;
using Client.Game.Enums;

namespace Client.Game.Map
{
	using DoorLinkMapping = Dictionary<RoomData.Link, DoorActor>;

	public class MapGenerator
	{
		public MapGenerator ()
		{
			Grid = new RoomGrid();
		}

		RoomGrid Grid;
		Room Head;

		private List<DoorActor> UnlinkedDoors = new List<DoorActor> ();

		//returns head
		public List<Room> GenerateFromDataSet(List<RoomData> data, int maxRooms) {

			var ret = new List<Room> ();
			for (var i = 0; i< maxRooms; i++) {

				var roomData = data [i % data.Count];

				int targetX;
				int targetY;
				//existing doors to links in the data we're trying to place
				DoorLinkMapping doorLinks;
				if (SearchForBlock (roomData, out targetX, out targetY, out doorLinks)) {
					var room = new Room (roomData);
					room.X = targetX;
					room.Y = targetY;
					
					ret.Add (room);
					Grid.Block(targetX, targetY, room.Width, room.Height);

					//spawn all doors for the room that got mates
					foreach( var kvp in doorLinks) {
						kvp.Value.LinkedGuid = kvp.Key.Id;
						spawnDoorToRoom (kvp.Key, room, kvp.Value.SelfGuid);
						UnlinkedDoors.Remove(kvp.Value);
					}

					//spawn doors for unmated links, but put them into the unlinked pile for consumption on the next placement
					var orphanedDoors = roomData.Doors.Except (doorLinks.Keys)
						.Select(p=>spawnDoorToRoom(p, room, Guid.Empty))
						.ToList();

					room.EnterGame (Core.Game.Instance);

					//add new unlinked doors
					UnlinkedDoors.AddRange (orphanedDoors);

					if(Head == null) Head = room;

				}

			}


			SealDoors();

			return ret;
		}

		DoorActor spawnDoorToRoom(RoomData.Link link, Room parent, Guid doorGuidLink) {
			var doorActor = Core.Game.Instance.ActorManager.Spawn<DoorActor>(resourceName:"Door_prefab");
			doorActor.GameObject.name = "DoorActor";
			doorActor.LinkedGuid = doorGuidLink;
			doorActor.InitWithData(link);
			//link coords are just in gridspace, need to convert to world space
			doorActor.Parent = parent;
			parent.Doors.Add(doorActor);
			return doorActor;
		}

		//this this is how we can bias which direction the map grows in
		int roomSearch = 0;
		DoorRoomSide[] SearchDirections = new DoorRoomSide[]{DoorRoomSide.Left, DoorRoomSide.Top, DoorRoomSide.Right, DoorRoomSide.Bottom};

		bool SearchForBlock (RoomData data, out int targetX, out int targetY, out DoorLinkMapping doorLinks)
		{

			if (UnlinkedDoors.Count == 0) {
				targetX = 0;
				targetY = 0;
				doorLinks = new DoorLinkMapping();
				return true;
			}


			roomSearch ++;

			for( int i = 0; i< SearchDirections.Length; i++ ) {

				int index = ((i + roomSearch) % (SearchDirections.Length));
				//UnityEngine.Debug.Log(SearchDirections[index]);
				if(SearchForMatchesForSide(data, SearchDirections[index], out targetX, out targetY, out doorLinks)) {
					return true;
				}
			}

			//default case: we failed to find a placement for the room
			targetX = 0;
			targetY = 0;
			doorLinks = new DoorLinkMapping ();
			return false;

		}

		bool SearchForMatchesForSide (RoomData data, DoorRoomSide side, out int targetX, out int targetY, out DoorLinkMapping doorLinks)
		{
			targetX = 0;
			targetY = 0;
			doorLinks = new DoorLinkMapping();


			var doors = SideDoors (data, side);
			if (doors.Count() > 0) {
				foreach (RoomData.Link door in doors) {
					var potentialMates = SideDoors (UnlinkedDoors, Opposite (side));

					foreach (var mate in potentialMates) {

						//Because we don't want to actually overlap the doors, we want them to be adjacent.
						//Testing Adjacency means we can just add offset for the door side and then test for equality


						targetX = (int)mate.MatingX - door.X;
						targetY = (int)mate.MatingY - door.Y;

						if (!Grid.IsBlocked (targetX, targetY, data.Width, data.Height)) {
							doorLinks.Add(door, mate);
							return true;
						}
					}
				}

			}
			return false;
		}

		private DoorRoomSide Opposite(DoorRoomSide side) {
			switch (side) {
			case DoorRoomSide.Bottom:
				return DoorRoomSide.Top;
			case DoorRoomSide.Left:
				return DoorRoomSide.Right;
			case DoorRoomSide.Right:
				return DoorRoomSide.Left;
			case DoorRoomSide.Top:
				return DoorRoomSide.Bottom;
			}
			return default(DoorRoomSide);
		}

		private IEnumerable<DoorActor> SideDoors(List<DoorActor> doors, DoorRoomSide side) {
			return doors.Where (p => p.Side == side);
		}

		private IEnumerable<RoomData.Link> SideDoors(RoomData data, DoorRoomSide side) {
			return data.Doors.Where (p => p.Side == side);
		}

		private void SealDoors() {
			foreach(var unlinked in UnlinkedDoors) {
				unlinked.Parent.Doors.Remove(unlinked);
				UnityEngine.Object.Destroy(unlinked.GameObject);
			}
		}


	}
}
