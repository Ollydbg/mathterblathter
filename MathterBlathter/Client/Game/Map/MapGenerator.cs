using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using Client.Game.Core;
using Client.Game.Actors;
using Client.Game.Enums;
using UnityEngine;
using System.Collections;
using Client.Game.Map.GenConstraints;

namespace Client.Game.Map
{
	using DoorLinkMapping = Dictionary<RoomData.Link, DoorActor>;
	using MatingLookup = Dictionary<Vector3, DoorActor>;
	using Game = Game.Core.Game;

	public class MapGenerator
	{
		MapData mapData;
		ConstraintList Constraints;
		MatingLookup MatingLookup = new MatingLookup();

		public MapGenerator ()
		{
			mapData = MockMapData.Map1;
			Constraints = new ConstraintList();
			Constraints.InitWithMap(mapData);
		}



		Room Head;
		RoomPool Pool;

		private List<DoorActor> UnlinkedDoors = new List<DoorActor> ();
		private List<Room> returnBuffer = new List<Room>();

		//returns head
		public List<Room> GenerateFromDataSet(List<RoomData> data, int maxRooms) {


			Pool = new RoomPool(data, maxRooms);

			while(!Pool.Exhausted) {
				RoomData roomData = Pool.Next();

				int targetX;
				int targetY;
				//existing doors to links in the data we're trying to place
				DoorLinkMapping doorLinks;
				if (SearchForBlock (roomData, out targetX, out targetY, out doorLinks)) {
					var room = new Room (roomData);
					room.X = targetX;
					room.Y = targetY;

					returnBuffer.Add (room);
					Constraints.Commit(roomData, targetX, targetY, room.Width, room.Height);

					ConsumeLinkedDoors(doorLinks, room);

					//spawn doors for unmated links, but put them into the unlinked pile for consumption on the next placement
					var orphanedDoors = roomData.Doors.Except (doorLinks.Keys)
						.Select(p=>spawnDoorToRoom(p, room, Guid.Empty))
						.ToList();

					room.EnterGame (Core.Game.Instance);

					//add new unlinked doors
					AddUnlinkedDoors(orphanedDoors);


					if(Head == null) Head = room;

				}

			}


			SealDoors();

			return returnBuffer;
		}

		void ConsumeLinkedDoors(DoorLinkMapping linkedDoors, Room room) {
			foreach( var kvp in linkedDoors) {
				kvp.Value.LinkedGuid = kvp.Key.Id;
				spawnDoorToRoom (kvp.Key, room, kvp.Value.SelfGuid);

				UnlinkedDoors.Remove(kvp.Value);
				var searchVector = new Vector3(kvp.Value.MatingX, kvp.Value.MatingY, 0f);

				MatingLookup.Remove(searchVector);

			}
		}

		void AddUnlinkedDoors (List<DoorActor> orphanedDoors)
		{
			foreach( var door in orphanedDoors) {
				Vector3 searchVector = new Vector3(door.MatingX, door.MatingY, 0f);
				if(MatingLookup.ContainsKey(searchVector)) {
				
				} else {
					MatingLookup.Add(searchVector, door);
					UnlinkedDoors.Add(door);
				}
			}

			
		}


		DoorActor spawnDoorToRoom(RoomData.Link link, Room parent, Guid doorGuidLink) {
			var doorActor = (DoorActor)Game.Instance.ActorManager.Spawn(MockActorData.DOOR);
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
		DoorRoomSide[] SearchDirections = new DoorRoomSide[]{DoorRoomSide.Left, DoorRoomSide.Right, DoorRoomSide.Top, DoorRoomSide.Bottom};

		bool SearchForBlock (RoomData data, out int targetX, out int targetY, out DoorLinkMapping doorLinks)
		{

			if (UnlinkedDoors.Count == 0) {
				var start = new BitmapReader(mapData).GetStart();
				targetX = (int)start.x;
				targetY = (int)start.y;
				doorLinks = new DoorLinkMapping();
				return true;
			}


			roomSearch ++;

			for( int i = 0; i< SearchDirections.Length; i++ ) {

				int index = ((i + roomSearch) % (SearchDirections.Length));
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

					foreach (DoorActor mate in potentialMates) {

						//Because we don't want to actually overlap the doors, we want them to be adjacent.
						//Testing Adjacency means we can just add offset for the door side and then test for equality

						targetX = (int)mate.MatingX - door.X;
						targetY = (int)mate.MatingY - door.Y;

						if(Constraints.Check(data, targetX, targetY, data.Width, data.Height)) {
							//doorLinks.Add(door, mate);
							doorLinks = GetMatingDoorsAtPosition(targetX, targetY, data);

							return true;
						}

					}
				}

			}

			return false;
		}

		private DoorLinkMapping GetMatingDoorsAtPosition(int x, int y, RoomData data) {
			DoorLinkMapping ret = new DoorLinkMapping();
			foreach( var link in data.Doors) {
				var searchVector = new Vector3(x + link.X, y + link.Y, 0f);
				DoorActor linkedActor;
				if(MatingLookup.TryGetValue(searchVector, out linkedActor)) {
					ret.Add(link, linkedActor);
				}
			}
				
			return ret;
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
				Game.Instance.ActorManager.RemoveActor(unlinked);
				//UnityEngine.Object.Destroy(unlinked.GameObject);
			}
		}



	}
}
