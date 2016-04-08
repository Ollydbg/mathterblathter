using System;
using UnityEngine;
using Client.Game.Core.Actors;

namespace Client.Game.Map
{
	public class PolyRoomDrawer : Room.IRoomDrawer
	{
		private const int FLOOR_HEIGHT = 2;
		private const int DOOR_HEIGHT = 3;
		public const string DOOR_LAYER = "Door";
		public const string DOOR_PREFAB_PATH = "door";

		public PolyRoomDrawer ()
		{
		}

		public void Draw(Room room) {

			var container = new GameObject ();
			container.name = "room";

			DrawFloor (room);
			DrawWalls (room);
			DrawDoors (room);

		}

		public void DrawDoors(Room room) {
			foreach (var door in room.Doors) {
				var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.localScale = new Vector3 (1, DOOR_HEIGHT, 1);
				cube.transform.position = new Vector3 (door.X, door.Y, 0);
				cube.GetComponent<MeshRenderer> ().material.color = Color.cyan;
				cube.name = "door";
				cube.layer = LayerMask.NameToLayer (DOOR_LAYER);
				var rb = cube.AddComponent<Rigidbody> ();
				rb.useGravity = false;

				cube.GetComponent<BoxCollider> ().isTrigger = true;
			}
		}

		void DrawWalls (Room room)
		{
			
		}


		public GameObject DrawFloor(Room room) {
			var floor = GameObject.CreatePrimitive (PrimitiveType.Cube);
			floor.transform.localScale = new Vector3 (room.Width, FLOOR_HEIGHT , 1);
			var rb = floor.AddComponent<Rigidbody> ();
			rb.useGravity = false;
			rb.isKinematic = true;
			floor.transform.position = new Vector3 (0, FLOOR_HEIGHT * -.5f, 0);
			floor.name = "floor";
			return floor;

		}

	}
}

