using System;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Map.TMX;

namespace Client.Game.Map
{
	//A frontend for pathfinding
	public class RoomTraversalGrid 
	{
		Room Room;
        private bool[][] matrix;
        
        private class PointI {
			public int x;
			public int y;
			public PointI(int inX, int inY) { x = inX; y = inY; }
		}
		List<PointI> ShrinkingBuffer = new List<PointI>();

		public RoomTraversalGrid (Room room)
		{
            this.Room = room;

		}

		public static bool[][] GetRoomMatrix(Room room) {
			var width = room.data.TmxMap.Width;
			var height = room.data.TmxMap.Height;
			var matrix = new bool[width][];
			for( int x = 0; x<width; x++ ) {
				matrix[x] = new bool[height];
				for( int y = 0; y<height; y++ ) {
					var tile = room.data.HardGeoTileMap[x, y]; 
					if(tile.Gid == 0) {
						
						//matrix[x][y] = true; 
						matrix[x][height - y - 1] = true;
					}
				}
			}

			return matrix;
		}

        public bool[][] GetMatrix() {
            if(matrix == null) {
                matrix = GetRoomMatrix(Room);

				//contracting is a problematic way of doing wall avoidance, because it makes floor positions, where the player lives, un-navigable
                //Contract(matrix);

            }
            
            return matrix;
        }
        
		void DebugMatrix (bool[][] matrix)
		{
			for( int x = 0; x < matrix.Length; x++ ) {
				for( int y = 0; y < matrix[x].Length; y++ ) {
					if(matrix[x][y]) {
						var pos = new GridPoint(x, y).GridToWorldBL(Room.data.TmxMap);
						Debug.DrawRay(pos, Vector3.forward * 2, Color.cyan, 2f);
					}
				}
			}
		}

		//contract the matrix so that enemies don't get so close to room geo
		public void Contract(bool[][] matrix) {
			
			//finds the edge nodes, and then set them to 0 in the matrix
			for( int x = 0; x< matrix.Length; x++) {
				for (int y = 0; y< matrix[x].Length; y++) {

					if(matrix[x][y]) {

						//left
						if(!IsSetChecked(matrix, x -1, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						/*if(!IsSetChecked(matrix, x -2, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}*/
						//down
						if(!IsSetChecked(matrix, x, y-1)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						/*
						if(!IsSetChecked(matrix, x, y-2)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}*/
						//right
						if(!IsSetChecked(matrix, x +1, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						/*
						if(!IsSetChecked(matrix, x +2, y)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}*/
						//up
						if(!IsSetChecked(matrix, x, y+1)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						/*
						if(!IsSetChecked(matrix, x, y+2)) {
							ShrinkingBuffer.Add(new PointI(x, y));
							continue;
						}
						*/
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

		private void DebugPoint(Vector3 worldPoint) {
			Debug.DrawRay(worldPoint, Vector3.back*10f, Color.green, 2f);
			/*GridPos fromInt = GridPoint.WorldToGrid(worldPoint, Room);
			var secondRay = new GridPoint(fromInt.x, fromInt.y).GridToWorldBL(Room.data.TmxMap);
			Debug.DrawRay(secondRay, Vector3.back*10f, Color.cyan, .1f);*/
		}

        

        public Vector3[] SearchPath(Vector2 worldFrom, Vector2 roomTo) {

			GridPoint fromInt = GridPoint.WorldToGrid(worldFrom, Room);
            GridPoint toInt = GridPoint.WorldToGrid(roomTo, Room);

            //DebugPoint(worldFrom);
            //DebugPoint(roomTo);
            var pts = new RoomPathFinder().FindPath(GetMatrix(), fromInt, toInt);
            var buff = new Vector3[pts.Count];
            
            for (int i = 0; i < pts.Count; i++) {
                buff[i] = pts[i].GridToWorldC(Room.data.TmxMap);
                //DebugPoint(buff[i]);
            }

            return buff;


        }






		
	}
}

