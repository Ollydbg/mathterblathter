using System;
using TiledSharp;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Data.Ascii;
using System.Linq;

namespace Client.Game.Map.TMX
{
	using VecMap = Dictionary<TmxLayerTile, bool>;

	public class FloodFill
	{

		private TmxMap map;
		private int width;
		private int height;
		private TileMap indexedTiles;


		public FloodFill(TmxMap map)
		{
			this.map = map;
			this.height = map.Height;
			this.width = map.Width;
		}

		public void Fill(int gid, int x, int y) {
			throw new NotImplementedException();
			/*
			var atPos = map[x, y];
			Fill(fillChar, GetRegion(atPos, x, y));*/
		}

		public void Fill(char fillChar, Chunk worldSpaceChunk) {
			throw new NotImplementedException();
			/*
			foreach( var worldSpace in worldSpaceChunk) {
				var gridSpace = InvertAsciiSpace(worldSpace);
				map[(int)gridSpace.x, (int)gridSpace.y] = fillChar;	
			}*/
		}

		public Vector3 InvertAsciiSpace(Vector3 vec) {
			return new Vector3(vec.x, map.Height-1 -vec.y, vec.z);
		}

		public TileChunk GetRegion(int gid, string layer, int x, int y) {
			var matches = new VecMap();
			var visited = new VecMap();
			indexedTiles = new TileMap(map.Layers.FirstOrDefault(p => p.Name == layer), map.Width);

			GetRegion (gid, x, y, matches, visited);
			return new TileChunk(matches.Keys);
		}

		private void GetRegion(int gid, int x, int y, VecMap matches, VecMap visited)
		{
			
			if (x > (width - 1) || y > (height - 1) || x < 0 || y < 0)
			{
				return;
			}

			var testValue = indexedTiles[x, y];

			if(visited.ContainsKey(testValue)) {
				return;
			}

			visited.Add(testValue, true);


			if (indexedTiles[x, y].Gid == gid)
			{
				matches.Add (testValue, true);

				//walk up
				GetRegion(gid, x, y+1, matches, visited);
				//walk right
				GetRegion(gid, x + 1, y, matches, visited);
				//walk left
				GetRegion (gid, x, y - 1, matches, visited);
				//walk right
				GetRegion (gid, x - 1, y, matches, visited);

			}

		}

	

	}
}

