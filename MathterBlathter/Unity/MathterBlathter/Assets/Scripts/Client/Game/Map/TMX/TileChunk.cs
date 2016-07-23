using System;
using System.Collections.Generic;
using TiledSharp;
using UnityEngine;

namespace Client.Game.Map.TMX
{
	public class TileChunk : List<TmxLayerTile>
	{
		public TileChunk ()
		{
		}

		float minX = float.MaxValue;
		float maxX = float.MinValue;
		float minY = float.MaxValue;
		float maxY = float.MinValue;

		public Vector3 Center {
			get {
				return new Vector3(minX + .5f*Width, minY + .5f*Height, 0f);
			}
		}

		public float Width {
			get {
				return maxX - minX + 1;
			}
		}

		public float Height {
			get {
				return maxY - minY + 1;
			}
		}



		public TileChunk (IEnumerable<TmxLayerTile> enumerable)
		{
			this.AddRange(enumerable);

			foreach( var tile in this) { 
				if (tile.X < minX ) {
					minX = tile.X;
				}
				if (tile.X > maxX ) {
					maxX = tile.X;
				}
				if (tile.Y < minY ) {
					minY = tile.Y;
				}
				if (tile.Y > maxY ) {
					maxY = tile.Y;
				}
			}
		}

		public TmxLayerTile Origin {
			get {
				return this[0];
			}
		}
	}
}

