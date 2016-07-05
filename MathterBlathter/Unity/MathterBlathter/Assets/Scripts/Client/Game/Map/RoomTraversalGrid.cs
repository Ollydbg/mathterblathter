using System;
using Client.Game.Pathfinding;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Data.Ascii;

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

		public static bool[][] GetRoomMatrix(Room room, bool preserveAsciiSpace) {
			var width = room.data.Width;
			var height = room.data.Height;
			var matrix = new bool[width][];
			for( int x = 0; x<width; x++ ) {
				matrix[x] = new bool[height];
				for( int y = 0; y<height; y++ ) {
					var roomChar = room.data.AsciiMap[x, y]; 
					if(roomChar != AsciiConstants.PLATFORM && roomChar != AsciiConstants.CEILING && roomChar != AsciiConstants.WALL) {

						if(preserveAsciiSpace) {
							matrix[x][y] = true;
						} else {
							matrix[x][height - y - 1] = true;
						}
					}
				}
			}

			return matrix;
		}

		public StaticGrid BuildGrid() {
			//air grid
			var matrix = GetRoomMatrix(Room, true);

			Shrink(matrix);
			//DebugMatrix(matrix);

			return new StaticGrid(Room.Width, Room.Height, matrix);
		}

		void DebugMatrix (bool[][] matrix)
		{
			for( int x = 0; x < matrix.Length; x++ ) {
				for( int y = 0; y < matrix[x].Length; y++ ) {
					if(matrix[x][y]) {
						var pos = AsciiUtils.AsciiToWorld(new GridPos(x, y), Room);

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

			var fromInt = AsciiUtils.WorldToAscii(worldFrom, Room);
			var toInt = AsciiUtils.WorldToAscii(roomTo, Room);
			var jp = new JumpPointParam(Grid, fromInt, toInt, false, false);
			var points = JumpPointFinder.FindPath(jp);

			var buff = new Vector3[points.Count];
			for(int i = 0; i<points.Count; i++ ) {
				buff[i] = AsciiUtils.AsciiToWorld(points[i], Room);
			}

			return buff;
			

		}




		
	}
}

