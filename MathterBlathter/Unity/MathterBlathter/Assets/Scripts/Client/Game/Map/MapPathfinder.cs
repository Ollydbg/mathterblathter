using System;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Data.Ascii;
using Client.Game.Pathfinding;
using Client.Game.Actors;
using System.Linq;

namespace Client.Game.Map
{

	public class MapPathfinder
	{
		public float Resolution = .5f;
		bool[][] WorldMatrix;
		Rect WorldRect;
		StaticGrid Grid;
		NodePool NodePool;
		int successes = 0;

		public MapPathfinder (List<Room> rooms)
		{
			try {
				BuildGrid(rooms);

			} catch {}
			Debug.Log(successes + "/" + rooms.Count);
		}


		void BuildGrid (List<Room> rooms)
		{
			
			float left = float.MaxValue; float right = float.MinValue; float top = float.MinValue; float bottom = float.MaxValue;
			foreach( var room in rooms) {
				left = Math.Min(left, room.X);
				right = Math.Max(right, (room.X + room.Width));
				top = Math.Max(top, (room.Y + room.Height));
				bottom = Math.Min(bottom, room.Y);

			}

			WorldRect = new Rect(left, bottom, right-left, top-bottom);
			WorldMatrix = new bool[Mathf.CeilToInt(WorldRect.width * Resolution)][];
			for (int i = 0; i< WorldMatrix.Length; i++ ) 
				WorldMatrix[i] = new bool[Mathf.CeilToInt(WorldRect.height * Resolution)];

			foreach( var room in rooms ) {
				PrintRoomToMatrix(room, WorldMatrix, WorldRect);
			}


		}

		private static GridPos GridPosition(Room room, Rect worldOffset, float resolution) {
			return new GridPos(
				(int)(resolution * (room.roomCenter.x - worldOffset.x)),
				(int)(resolution * (room.roomCenter.y - worldOffset.y))
			);
		}

		private static Vector3 GridToWorld(GridPos pos, Rect worldOffset, float resolution) {
			return new Vector3(
				pos.x / resolution + worldOffset.x,
				pos.y / resolution + worldOffset.y,
				0f
			);
		}


		public Vector3[] FindPath(Room worldFrom, Room worldTo) {

			Grid = new StaticGrid(WorldMatrix.Length, WorldMatrix[0].Length, WorldMatrix);

			GridPos fromInt = GridPosition(worldFrom, WorldRect, Resolution);
			GridPos toInt = GridPosition(worldTo, WorldRect, Resolution);

			var queryParams = new JumpPointParam(Grid, fromInt, toInt, false, false);
			long time = DateTime.UtcNow.Millisecond;
			var gridPoints = JumpPointFinder.FindPath(queryParams);
			long elapsed = DateTime.UtcNow.Millisecond - time;

			Debug.Log("Path calculation took " + (elapsed) + "ms");

			var points = gridPoints.Select(p => GridToWorld(p, WorldRect, Resolution)).ToArray();

			DebugDraw(points);

			return points;

		}


		void DebugDraw (Vector3[] points)
		{
			foreach( var pt in points ) {
				Debug.DrawRay(pt, Vector3.back * 20f, Color.cyan, 100f);
			}
		}

		public DoorActor FirstDoorToRoom(Room worldFrom, Room worldTo) {
			var pts = FindPath(worldFrom, worldTo);
			//find last points that's still in room
			var rect = worldFrom.RoomRect;
			Vector3 closestPtOnPath = pts[0];
			foreach( var pt in pts ) {
				if(rect.Contains(pt)) {
					closestPtOnPath = pt;
				} else {
					break;
				}
			}

			DoorActor closestDoor = null;
			var closestDistance = float.MaxValue;
			foreach( var door in worldFrom.Doors) {
				var testDistance = (door.transform.position - closestPtOnPath).sqrMagnitude; 
				if(testDistance < closestDistance) {
					closestDistance = testDistance;
					closestDoor = door;
				}
			}

			return closestDoor;
		}


		private void PrintRoomToMatrix(Room room, bool[][] matrix, Rect offset) {
			
			for( int x = 0; x<room.data.Width; x++ ) {

				for( int y = 0; y<room.data.Height; y++ ) {
					var roomChar = room.data.AsciiMap[x, y];

					var adjustedY = room.data.Height - y - 1;


					if(roomChar != AsciiConstants.CEILING && roomChar != AsciiConstants.WALL && roomChar != AsciiConstants.FLOOR && roomChar != AsciiConstants.PLATFORM) {
						var matrixX = Mathf.FloorToInt(Resolution*(x + room.X - offset.x));
						var matrixY = Mathf.FloorToInt(Resolution*(adjustedY + room.Y - offset.y));

						matrix[matrixX][matrixY] = true;

					}
				}
			}

			successes++;
		}
	}
}

