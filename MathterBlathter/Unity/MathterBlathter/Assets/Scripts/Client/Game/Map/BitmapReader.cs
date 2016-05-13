using System;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Map
{
	public class BitmapReader
	{

		public MapData Data;

		public static Color Start = Color.blue;
		public static Color Blocked = Color.white;
		public static Color Available = Color.black;


		private Texture2D Bitmap;
		private int startX, startY;

		public BitmapReader (MapData data)
		{
			this.Data = data;
		
			Load(data.ResourcePath);
		}

		public void Load(String path) {
			this.Bitmap = (Texture2D)Resources.Load(path);

			//search bottom left most blue pixel
			for( var x = 0; x < Bitmap.width; x++ ) {
				for( var y = 0; y< Bitmap.height; y++ ) {
					if(Bitmap.GetPixel(x, y) == Start) {
						startX = x;
						startY = y;
						return;
					}
				}
			}

		}

		public Vector2 GetStart() {
			return new Vector2(
				(int)(startX * Data.ReadScale), 
				(int)(startY * Data.ReadScale));

		}

		public bool IsBlocked(int x, int y) {

			int adjustedX = (int)(x*Data.ReadScale);
			int adjustedY = (int)(y*Data.ReadScale);

			bool blocked = Bitmap.GetPixel(adjustedX, adjustedY) == Blocked;
			return blocked;
		
		}
	}
}

