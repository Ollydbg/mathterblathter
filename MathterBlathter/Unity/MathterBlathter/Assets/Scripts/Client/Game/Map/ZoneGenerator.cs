using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using Client.Game.Actors;
using Client.Game.Enums;
using UnityEngine;
using Client.Game.Map.GenConstraints;
using Client.Game.Utils;

namespace Client.Game.Map
{
	using DoorLinkMapping = Dictionary<RoomData.Link, DoorActor>;
	using MatingLookup = Dictionary<Vector3, DoorActor>;
	using Game = Game.Core.Game;
	using Client.Game.Data.Ascii;

	public class ZoneGenerator
	{
		MapData mapData;
		ZoneData ZoneData;
		public ConstraintList Constraints;

		MatingLookup MatingLookup = new MatingLookup();
		List<Room> GeneratedRooms = new List<Room>();

		public int FloorY = 0;

		Room Head;
		RoomPool Pool;
		
		public ZoneGenerator (ZoneData zoneData)
		{
			this.ZoneData = zoneData;

			Constraints = new ConstraintList();
		}


		private List<DoorActor> UnlinkedDoors = new List<DoorActor> ();

		public bool IsComplete {
			get {
				return Pool.RequirementsSatisfied || Pool.Exhausted;
			}
		}

		public void BuildFrom (DoorActor topMostUnlinkedDoor, ConstraintList constraints)
		{
			FloorY = topMostUnlinkedDoor.Parent.Y;

			this.Constraints = constraints;
			AddUnlinkedDoors(new DoorActor[]{topMostUnlinkedDoor});
		}

		//returns head
		public void InitPool(List<RoomData> data, int maxRooms) {
			Pool = new RoomPool(data, maxRooms, ZoneData.Requirements);	
		}


		public Room Emit() {

			RoomData roomData = Pool.Next();
			
			int targetX;
			int targetY;
			//existing doors to links in the data we're trying to place
			DoorLinkMapping doorLinks;


			if (SearchForBlock (roomData, out targetX, out targetY, out doorLinks)) {
				Pool.Consume(roomData);

				var room = new Room (roomData);
				room.X = targetX;
				room.Y = targetY;

				room.Zone = ZoneData;

				Constraints.Commit(roomData, targetX, targetY, room.Width, room.Height);

				ConsumeLinkedDoors(doorLinks, room);

				//spawn doors for unmated links, but put them into the unlinked pile for consumption on the next placement
				var orphanedDoors = roomData.Doors.Except (doorLinks.Keys)
					.Select(p=>spawnDoorToRoom(p, room))
					.ToList();

				//add new unlinked doors
				AddUnlinkedDoors(orphanedDoors);

				if(Head == null) Head = room;

				GeneratedRooms.Add(room);

				return room;
			}
			return null;

		}



		void ConsumeLinkedDoors(DoorLinkMapping linkedDoors, Room room) {
			foreach( var kvp in linkedDoors) {
				kvp.Value.Portals[kvp.Value.Side] = room;
				UnlinkedDoors.Remove(kvp.Value);

				room.Doors.Add(kvp.Value);

				var searchVector = new Vector3(kvp.Value.MatingX, kvp.Value.MatingY, 0f);

				MatingLookup.Remove(searchVector);

			}
		}

		void AddUnlinkedDoors (IEnumerable<DoorActor> orphanedDoors)
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


		DoorActor spawnDoorToRoom(RoomData.Link link, Room parent) {
			var doorActor = (DoorActor)Game.Instance.ActorManager.Spawn(CharacterDataTable.DOOR);
			doorActor.Portals[DoorRoom.Opposite(link.Side)] = parent;
			doorActor.Parent = parent;
			doorActor.GameObject.name = "DoorActor";
			doorActor.InitWithData(link);
			//link coords are just in gridspace, need to convert to world space

			parent.Doors.Add(doorActor);
			return doorActor;
		}

		int roomSearch = 0;
		DoorRoomSide[] SearchDirections = new DoorRoomSide[]{DoorRoomSide.Left, DoorRoomSide.Right, DoorRoomSide.Top, DoorRoomSide.Bottom};

		bool SearchForBlock (RoomData data, out int targetX, out int targetY, out DoorLinkMapping doorLinks)
		{

			if (UnlinkedDoors.Count == 0) {
				var start = Vector2.zero;//new BitmapReader(mapData).GetStart();
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
					var potentialMates = SideDoors (UnlinkedDoors, DoorRoom.Opposite (side));

					foreach (DoorActor mate in potentialMates) {

						//Because we don't want to actually overlap the doors, we want them to be adjacent.
						//Testing Adjacency means we can just add offset for the door side and then test for equality

						targetX = (int)mate.MatingX - door.X;
						targetY = (int)mate.MatingY - door.Y;

						if(targetY > FloorY) {
							if(Constraints.Check(data, targetX, targetY, data.Width, data.Height)) {
								doorLinks = GetMatingDoorsAtPosition(targetX, targetY, data);
								return true;
							}
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



		private IEnumerable<DoorActor> SideDoors(List<DoorActor> doors, DoorRoomSide side) {
			return doors.Where (p => p.Side == side);
		}

		private IEnumerable<RoomData.Link> SideDoors(RoomData data, DoorRoomSide side) {
			return data.Doors.Where (p => p.Side == side);
		}


		public void SealDoors(DoorActor except = null) {
			foreach(var unlinked in UnlinkedDoors.ToList()) {

				if(unlinked != except) {
					unlinked.Parent.Doors.Remove(unlinked);
					Game.Instance.ActorManager.RemoveActor(unlinked);

					var ff = new FloodFill(unlinked.Parent.data.AsciiMap);
					ff.Fill(AsciiConstants.SEALED_DOOR, unlinked.LinkData.ChunkData);	
					UnlinkedDoors.Remove(unlinked);
				}
			}
		}

		public DoorActor TopMostUnlinkedDoor {
			get {
				var top = UnlinkedDoors[0];
				foreach( var door in UnlinkedDoors) 
					if(door.WorldY > top.WorldY)
						top = door;
			
				return top;
			}
		}

		public DoorActor BottomMostUnlinkedDoor {
			get {
				var bottom = UnlinkedDoors[0];
				foreach( var door in UnlinkedDoors) 
					if(door.WorldY < bottom.WorldY)
						bottom = door;

				return bottom;
			}
		}

	}
}

