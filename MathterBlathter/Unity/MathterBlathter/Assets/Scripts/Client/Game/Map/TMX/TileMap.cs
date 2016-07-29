using System;
using TiledSharp;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Map.TMX
{
	public class TileMap {

		public TileMap() {

		}

		public void AddData(TmxLayer layer, int width) {
			if((layer.Tiles.Count % width) > 0) {
				throw new Exception("Got layer not divisible by its width!");
			}

			for( int i = 0; i< layer.Tiles.Count/width; i++ ) {
				rows.Add(new TmxLayerTile[width]);
			}


			for( int i = 0; i< layer.Tiles.Count; i++ ) {
				var x = i%width;
				var y = Mathf.FloorToInt(i/width);

				this[x, y] = layer.Tiles[i];
			}

		}
		
		public TileMap(TmxLayer layer, int width) {
			AddData(layer, width);
		}

		public List<TmxLayerTile[]> rows = new List<TmxLayerTile[]>();

		public TmxLayerTile this[int x, int y] {
			get {
				return rows [y] [x];
			}
			set {
				rows[y][x] = value;
			}
		}

	}
}

