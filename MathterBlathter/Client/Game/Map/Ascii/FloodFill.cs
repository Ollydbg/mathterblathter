using System;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Map.Ascii
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
		

		public Vector3[] GetRegion(char match, int x, int y) {
			var matches = new VecMap();
			var visited = new VecMap();
			GetRegion (match, x, y, matches, visited);
			var matchBuffer = new Vector3[matches.Keys.Count];
			matches.Keys.CopyTo(matchBuffer, 0);
			return matchBuffer;
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

