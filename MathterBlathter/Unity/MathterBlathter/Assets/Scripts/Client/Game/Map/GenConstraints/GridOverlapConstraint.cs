using System;
using Client.Game.Data;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Map.GenConstraints
{
	public class GridOverlapConstraint : IGenConstraint
	{
		public GridOverlapConstraint ()
		{
		}

		BitmapReader reader;
		List<Rect> rects = new List<Rect>();
		
		public void InitWithMap (MapData mapData)
		{
			reader = new BitmapReader(mapData);
		}


		public bool Check (RoomData data, int x, int y, int width, int height)
		{
			/*
			if(reader.IsBlocked(x, y))
				return false;
			*/

			var testRect = new Rect (x, y, width, height);

			foreach (var rect in rects) {
				if (rect.Overlaps (testRect))
					return false;
			}
			return true;
		}

		public void Commit (RoomData data, int x, int y, int width, int height)
		{
			rects.Add (new Rect (x, y, width, height));
		}

	}
}

