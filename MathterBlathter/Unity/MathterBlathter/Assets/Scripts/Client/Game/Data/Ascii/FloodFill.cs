using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Data;

namespace Client.Game.Data.Ascii
{
	using VecMap = Dictionary<Vector3, bool>;

	public class FloodFill
	{

		private AsciiMap map;
		private int width;
		private int height;



		public FloodFill(AsciiMap map)
		{
		  this.map = map;
		  this.height = map.Height;
		  this.width = map.Width;
		}
		
		public void Fill(char fillChar, int x, int y) {
			
			var atPos = map[x, y];
			Fill(fillChar, GetRegion(atPos, x, y));
		}
		
		public void Fill(char fillChar, Chunk worldSpaceChunk) {
			foreach( var worldSpace in worldSpaceChunk) {
				var gridSpace = InvertAsciiSpace(worldSpace);
				map[(int)gridSpace.x, (int)gridSpace.y] = fillChar;	
			}
		}

		public Vector3 InvertAsciiSpace(Vector3 vec) {
			return new Vector3(vec.x, map.Height-1 -vec.y, vec.z);
		}

		public Chunk GetRegion(char match, int x, int y) {
			var matches = new VecMap();
			var visited = new VecMap();
			GetRegion (match, x, y, matches, visited);
			return new Chunk(matches.Keys);
		}

		private void GetRegion(char match, int x, int y, VecMap matches, VecMap visited)
	  	{

			Vector3 testVector = new Vector3(x, y);
			if(visited.ContainsKey(testVector)) {
				return;
			}

			visited.Add(testVector, true);
			
		    if (x > (width - 1) || y > (height - 1) || x < 0 || y < 0)
		    {
		      return;
		    }


		    if (map[x, y] == match)
		    {
				matches.Add (testVector, true);

				//walk up
				GetRegion(match, x, y+1, matches, visited);
				//walk right
				GetRegion(match, x + 1, y, matches, visited);
				//walk left
				GetRegion (match, x, y - 1, matches, visited);
				//walk right
				GetRegion (match, x - 1, y, matches, visited);

		    }


	  	}


	}
}

