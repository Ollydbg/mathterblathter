using System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game.Map
{

	//maybe this should be a k-d tree, but for prototyping purposes, this can just be dumb
	public class RoomGrid
	{
		BitmapReader BitmapReader;

		public RoomGrid (BitmapReader bmp)
		{
			BitmapReader = bmp;
		}

		List<Rect> rects = new List<Rect>();

		public bool IsBlocked (int targetX, int targetY, int width, int height)
		{
			if(BitmapReader.IsBlocked(targetX, targetY))
				return true;
			
			var testRect = new Rect (targetX, targetY, width, height);

			foreach (var rect in rects) {
				if (rect.Overlaps (testRect))
					return true;
			}
			return false;
		}
		
		public Vector2 GetStart() { return BitmapReader.GetStart(); }

		public void Block (int targetX, int targetY, int width, int height)
		{
			rects.Add (new Rect (targetX, targetY, width, height));
		}
	}
}

