using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using Client.Game.Core;

namespace Client.Game.Map
{
	public class MapGenerator
	{
		public MapGenerator ()
		{
			Grid = new RoomGrid();
		}

		RoomGrid Grid;
		Room Head;

		private List<Door> UnlinkedDoors = new List<Door> ();

		//returns head
		public Room GenerateFromDataSet(List<RoomData> data) {
			foreach (var roomData in data) {

				int targetX;
				int targetY;
				Dictionary<Door, Door> doorLinks;
				if (SearchForBlock (roomData, out targetX, out targetY, out doorLinks)) {
					var room = new Room (roomData);
					room.X = targetX;
					room.Y = targetY;

					room.EnterGame (Core.Game.Instance);

					Grid.Block(targetX, targetY, room.Width, room.Height);

					//remove consumed doors
					foreach( var kvp in doorLinks) {
						kvp.Key.Linked = room;
						kvp.Value.Linked = kvp.Key.Parent;

						UnlinkedDoors.Remove(kvp.Key);
					}

					//add new unlinked doors
					UnlinkedDoors.AddRange (room.Doors.Where(p=>p.Linked == null));

					if(Head == null) Head = room;

				}

			}


			SealDoors();

			return Head;
		}

		//this this is how we can bias which direction the map grows in
		int roomSearch = 0;
		//Door.RoomSide[] SearchDirections = new Door.RoomSide[]{Door.RoomSide.Top, Door.RoomSide.Top, Door.RoomSide.Top, Door.RoomSide.Right, Door.RoomSide.Left, Door.RoomSide.Bottom};
		Door.RoomSide[] SearchDirections = new Door.RoomSide[]{Door.RoomSide.Left, Door.RoomSide.Top, Door.RoomSide.Right, Door.RoomSide.Bottom};

		bool SearchForBlock (RoomData data, out int targetX, out int targetY, out Dictionary<Door, Door> doorLinks)
		{

			if (UnlinkedDoors.Count == 0) {
				targetX = 0;
				targetY = 0;
				doorLinks = new Dictionary<Door, Door>();
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
			doorLinks = new Dictionary<Door, Door>();
			return false;

		}

		bool SearchForMatchesForSide (RoomData data, Door.RoomSide side, out int targetX, out int targetY, out Dictionary<Door, Door> doorLinks)
		{
			targetX = 0;
			targetY = 0;
			doorLinks = new Dictionary<Door,Door >();
			var doors = SideDoors (data, side);
			if (doors.Count() > 0) {
				foreach (Door door in doors) {
					var potentialMates = SideDoors (UnlinkedDoors, Opposite (side));

					foreach (var mate in potentialMates) {

						targetX = (int)mate.WorldX - door.X;
						targetY = (int)mate.WorldY - door.Y;

						if (!Grid.IsBlocked (targetX, targetY, data.Width, data.Height)) {
							doorLinks.Add(mate, door);
							return true;
						}

					}
				}

			}
			return false;
		}

		private List<Door> DoorsInRect() {
			return null;
		}

		private Door.RoomSide Opposite(Door.RoomSide side) {
			switch (side) {
			case Door.RoomSide.Bottom:
				return Door.RoomSide.Top;
			case Door.RoomSide.Left:
				return Door.RoomSide.Right;
			case Door.RoomSide.Right:
				return Door.RoomSide.Left;
			case Door.RoomSide.Top:
				return Door.RoomSide.Bottom;
			}
			return default(Door.RoomSide);
		}

		private IEnumerable<Door> SideDoors(List<Door> doors, Door.RoomSide side) {
			return doors.Where (p => p.Side == side).ToList();
		}

		private IEnumerable<Door> SideDoors(RoomData data, Door.RoomSide side) {
			return SideDoors (data.Doors, side);
		}

		private void SealDoors() {
			foreach(var unlinked in UnlinkedDoors) {
				unlinked.Parent.Doors.Remove(unlinked);
				UnityEngine.Object.Destroy(unlinked.gameObject);
			}
		}


	}
}
