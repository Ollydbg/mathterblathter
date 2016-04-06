﻿using System;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;

namespace Client.Game.Map
{
	public class GeneratorTest : MonoBehaviour
	{
		public const int NUM_ROOMS = 500;

		public void Awake ()
		{

			var rooms = MockData ();
			var generator = new MapGenerator (1000, 1000);
			generator.GenerateFromDataSet (rooms);
		}

		public List<RoomData> MockData() {

			int[] widths = new int[]{ 32, 64, 128 };
			int[] heights = new int[]{ 32, 64, 128 };

			var buffer = new List<RoomData> ();

			for (int i = 0; i < NUM_ROOMS; i++) {
				int widthIndex = UnityEngine.Random.Range (0, widths.Length - 1);
				int heightIndex = UnityEngine.Random.Range (0, heights.Length - 1);

				var room = new RoomData ();
				room.Width = widths [widthIndex];
				room.Height = heights [heightIndex];


				while (room.Doors.Count == 0) {
					if (Maybe ())
						AddLeftAndRightDoors (room);

					if (Maybe ())
						AddTopAndBottomDoors (room);

				}

				buffer.Add (room);
			}

			return buffer;
		}

		private Boolean Maybe() {
			return UnityEngine.Random.Range (0, 2) == 1;
		}

		public void AddTopAndBottomDoors(RoomData room) {
			var top = new Door ();
			top.X = 0;
			top.Y = (int)(room.Height * .5);
			top.Width = 1;
			top.Height = 4;
			top.Side = Door.RoomSide.Top;

			var bottom = new Door ();
			bottom.X = 0;
			bottom.Y = (int)(room.Height*-.5);
			bottom.Width = 1;
			bottom.Height = 4;
			bottom.Side = Door.RoomSide.Bottom;

			room.Doors.Add (top);
			room.Doors.Add (bottom);
		}

		public void AddLeftAndRightDoors(RoomData room) {
			var left = new Door ();
			left.X = (int)(room.Width * -.5);
			left.Y = 0;
			left.Width = 1;
			left.Height = 4;
			left.Side = Door.RoomSide.Left;

			var right = new Door ();
			right.X = (int)(room.Width * .5);
			right.Y = 0;
			right.Width = 1;
			right.Height = 4;
			right.Side = Door.RoomSide.Right;

			room.Doors.Add (left);
			room.Doors.Add (right);

		}
	}
}

