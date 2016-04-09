using System;
using Client.Game.Data;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public class RoomDataMocker
	{
		public RoomDataMocker ()
		{
		}

		public List<RoomData> Mock(int number) {

			int[] widths = new int[]{  32, 64, 96, 128 };
			int[] heights = new int[]{ 32, 64, 96, 128 };

			var buffer = new List<RoomData> ();

			for (int i = 0; i < number; i++) {


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
			var top = new RoomData.Link ();
			top.X = 0;
			top.Y = (int)(room.Height * .5);
			top.Width = 1;
			top.Height = 4;
			top.Side = DoorRoomSide.Top;

			var bottom = new RoomData.Link ();
			bottom.X = 0;
			bottom.Y = (int)(room.Height*-.5);
			bottom.Width = 1;
			bottom.Height = 4;
			bottom.Side = DoorRoomSide.Bottom;

			room.Doors.Add (top);
			room.Doors.Add (bottom);
		}

		public void AddLeftAndRightDoors(RoomData room) {
			var left = new RoomData.Link ();
			left.X = (int)(room.Width * -.5);
			left.Y = 0;
			left.Width = 1;
			left.Height = 4;
			left.Side = DoorRoomSide.Left;

			var right = new RoomData.Link ();
			right.X = (int)(room.Width * .5);
			right.Y = 0;
			right.Width = 1;
			right.Height = 4;
			right.Side = DoorRoomSide.Right;

			room.Doors.Add (left);
			room.Doors.Add (right);

		}
	}

}

