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

		private class PointI {
			public int x;
			public int y;
			public PointI(int inX, int inY) { x = inX; y = inY; }
		}
		List<PointI> ShrinkingBuffer = new List<PointI>();

		public RoomTraversalGrid (Room room)
		{
			this.Room = room;
			this.Grid = BuildGrid();

		}

		public StaticGrid BuildGrid() {
			//air grid
			var width = Room.data.Width;
			var height = Room.data.Height;
			var matrix = new bool[width][];
			for( int x = 0; x<width; x++ ) {
				matrix[x] = new bool[height];
				for( int y = 0; y<height; y++ ) {
					var roomChar = Room.data.AsciiMap[x, y]; 
					if(roomChar != AsciiConstants.PLATFORM) {
						matrix[x][y] = true;
					}
				}
			}

			Shrink(matrix);
			//DebugMatrix(matrix);

			return new StaticGrid(width, height, matrix);
		}

		void DebugMatrix (bool[][] matrix)
		{
			for( int x = 0; x < matrix.Length; x++ ) {
				for( int y = 0; y < matrix[x].Length; y++ ) {
					if(matrix[x][y]) {
						var pos = AsciiToWorld(new GridPos(x, y), Room);

						Debug.DrawRay(pos, Vector3.forward * 2, Color.cyan, 2f);
					}
				}
			}
		}


		public void Shrink(bool[][] matrix) {
			
			//finds the edge nodes, and then set them to 0 in the matrix
			for( int x = 0; x< matrix.Length; x++) {
				for (int y = 0; y< matrix[x].Length; y++) {

					if(matrix[x][y]) {

						//left
						if(!IsSetChecked(matrix, x -1, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						if(!IsSetChecked(matrix, x -2, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						//down
						if(!IsSetChecked(matrix, x, y-1)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						if(!IsSetChecked(matrix, x, y-2)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						//right
						if(!IsSetChecked(matrix, x +1, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						if(!IsSetChecked(matrix, x +2, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						//up
						if(!IsSetChecked(matrix, x, y+1)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						if(!IsSetChecked(matrix, x, y+2)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
					}
				}
			}

			foreach( var pt in ShrinkingBuffer ) {
				matrix[pt.x][pt.y] = false;
				/*
				Debug.DrawRay(AsciiToWorld(new GridPos(pt.x, pt.y), Room), Vector3.forward* 2f, Color.red, 2f);
				*/
			}

			ShrinkingBuffer.Clear();
		}

		private bool IsSetChecked(bool[][] matrix, int x, int y) {

			if(x < 0 || x >= matrix.Length )
				return false;

			if(y < 0 || y >= matrix[x].Length)
				return false;

			return matrix[x][y];

		}

		public Vector3[] SearchPath(Vector2 worldFrom, Vector2 roomTo) {

			Grid = BuildGrid();

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

