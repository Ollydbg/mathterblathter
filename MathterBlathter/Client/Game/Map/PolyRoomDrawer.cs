using System;
using UnityEngine;

namespace Client.Game.Map
{
	public class PolyRoomDrawer : Room.IRoomDrawer
	{
		private const int FLOOR_HEIGHT = 2;

		public PolyRoomDrawer ()
		{
		}

		public void Draw(Room room) {

			var container = new GameObject ();
			container.name = "room";

			var floor = GameObject.CreatePrimitive (PrimitiveType.Cube);
			floor.transform.localScale = new Vector3 (room.Width, FLOOR_HEIGHT , 1);

			floor.transform.position = new Vector3 (0, FLOOR_HEIGHT * -.5f, 0);
			
		}
	}
}

