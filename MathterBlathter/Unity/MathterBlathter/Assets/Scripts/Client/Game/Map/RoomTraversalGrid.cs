using System;
using Client.Game.Pathfinding;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Map
{
	//A frontend for pathfinding
	public class RoomTraversalGrid 
	{
		StaticGrid Grid;
		Room Room;
		public RoomTraversalGrid (Room room)
		{
			this.Room = room;
			//air grid
			var width = room.data.Width;
			var height = room.data.Height;
			var matrix = new bool[width][];
			for( int x = 0; x<width; x++ ) {
				matrix[x] = new bool[height];
				for( int y = 0; y<height; y++ ) {
					if(room.data.AsciiMap[x, y] == AsciiConstants.AIR_SPAWN) {
						matrix[x][y] = true;
					}
				}
			}

			Grid = new StaticGrid(width, height, matrix);

		}

		public Vector3[] SearchPath(Vector2 worldFrom, Vector2 roomTo) {
			var fromInt = WorldToAscii(worldFrom, Room);
			var toInt = WorldToAscii(roomTo, Room);
			var jp = new JumpPointParam(Grid, fromInt, toInt, false, false);
			var points = JumpPointFinder.FindPath(jp);

			var buff = new Vector3[points.Count];
			for(int i = 0; i<points.Count; i++ ) {
				buff[i] = AsciiToWorld(points[i], Room);
			}

			return buff;
			

		}

		private static Vector3 AsciiToWorld(GridPos pos, Room room) {
			return new Vector3(
				pos.x + room.X,
				room.Height - 1 - pos.y + room.Y
			);
		}
		

		private static GridPos WorldToAscii(Vector3 worldPos, Room room) {
			return new GridPos(
				(int)(worldPos.x - room.X),
				-((int)worldPos.y - room.Y - room.Height + 1)
			);
		}
		
	}
}

