using System;
using UnityEngine;
using TiledSharp;
using Client.Game.Map;

namespace Client.Game.Map.TMX
{
	public class GridPoint {
		public int X, Y;
		public GridPoint(int x, int y) { X = x; Y = y;}
		public GridPoint(float x, float y) { X = (int)x; Y = (int)y;}
		public GridPoint(Vector3 v3) { X = (int)v3.x; Y = (int)v3.y; }


		public static float PIXEL_UP_SCALE = 6f;

		public Vector3 GridToWorldBL(TmxMap map, Rect centeredRect) {
			var ppu = .01f;
			var spaceResolution = map.TileWidth * ppu;


			//assumes TL registration, which is not always going to be the case
			var worldCoordX = X * spaceResolution * PIXEL_UP_SCALE;
			var worldCoordY = Y * spaceResolution * PIXEL_UP_SCALE;
			var widthOffset = centeredRect.width * PIXEL_UP_SCALE * ppu * .5f;
			var heightOffset = centeredRect.height * PIXEL_UP_SCALE * ppu * .5f;
			return new Vector3(
				worldCoordX + widthOffset,
				worldCoordY + heightOffset

			);
		}


		public static GridPoint FromTMXObject(TmxObjectGroup.TmxObject obj, TmxMap map) {
			var x = (int)(obj.X / map.TileWidth);
			var y = map.Height - (int)(obj.Y/map.TileHeight);
			return new GridPoint(x, y);

		}

		public Vector3 GridToWorldBL(TmxMap map) {

			var spaceResolution = map.TileWidth / 100f;

			return new Vector3(
				X * spaceResolution * PIXEL_UP_SCALE,
				Y * spaceResolution * PIXEL_UP_SCALE, 
				0f
			);

		}

		public Vector3 GridToWorldC (TiledSharp.TmxMap map)
		{
			var spaceResolution = map.TileWidth / 100f;

			float widthOffset = spaceResolution * .5f * PIXEL_UP_SCALE;
			float heightOffset = spaceResolution * .5f * PIXEL_UP_SCALE;

			return new Vector3(
				X * spaceResolution * PIXEL_UP_SCALE + widthOffset,
				Y * spaceResolution * PIXEL_UP_SCALE + heightOffset, 
				0f
			);
		}

		public static GridPoint WorldToGrid(Vector3 v3, Room room) {
			var spaceResolution = room.data.TmxMap.TileWidth / 100f;

			return new GridPoint(
				Mathf.FloorToInt((v3.x - room.X) / spaceResolution / PIXEL_UP_SCALE),
				Mathf.FloorToInt((v3.y- room.Y) / spaceResolution / PIXEL_UP_SCALE)
			);
		}

	}
}

