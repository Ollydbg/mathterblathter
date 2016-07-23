using System;
using TiledSharp;
using Client.Game.Data.Ascii;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Client.Game.Map.TMX
{
	public class TMXChunkExtractor
	{
		TmxMap Map;
		FloodFill floodFill;
		

		public TMXChunkExtractor (TmxMap map)
		{
			this.Map = map;
			floodFill = new FloodFill(Map);

		}

		public List<Chunk> GetChunksOnLayer(string layer) {
			var buffer = new List<Chunk>();
			List<TmxLayerTile> tiles = null;
			if( tryGetLayerTiles(layer, out tiles)) {

				var seen = new Dictionary<TmxLayerTile, bool>();
				foreach( var tile in tiles) {
					if(!seen.ContainsKey(tile)) {
						var segment = floodFill.GetRegion(tile.Gid, layer, tile.X, tile.Y);

						segment.ForEach(p => seen[p] = true);
						buffer.Add(new Chunk(segment.Select(p =>InvertSpace(p))));

					}
				}

			} 

			return buffer;

		}

		public bool tryGetLayerTiles(string layer, out List<TmxLayerTile> tiles) {
			int height = Map.Height;

			var tmxLayer = Map.Layers.FirstOrDefault(p => p.Name == layer);
			if(tmxLayer != null) {
				tiles = tmxLayer.Tiles.Where( p=>p.Gid != 0).ToList();
				return true;
			}
			tiles = null;
			return false;

		}

		public Vector3 InvertSpace(TmxLayerTile tile) {
			return new Vector3(tile.X, Map.Height-1 -tile.Y, 0f);
		}


		
	}
}

