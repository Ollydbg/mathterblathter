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
			
			DrawFloor (room);
			DrawWalls (room);
			DrawDoors (room);

		}

		public void DrawDoors(Room room) {
			foreach (var door in room.Doors) {
				door.transform.localScale = new Vector3 (1, DOOR_HEIGHT, 1);
				door.transform.position = new Vector3 (door.X + room.X, door.Y + room.Y, 0);

				Debug.Log ("placing door at position; " + door.transform.position);
				door.GameObject.GetComponent<MeshRenderer> ().material.color = Color.cyan;
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
			floor.transform.position = new Vector3 (room.X, FLOOR_HEIGHT * -.5f + room.Y, 0);
			floor.name = "floor";
			floor.GetComponent<MeshRenderer> ().material.color = RandomColor ();
			return floor;

		}

		private Color RandomColor() {
			return new Color (
				UnityEngine.Random.Range (0.0f, 1.0f),
				UnityEngine.Random.Range (0.0f, 1.0f),
				UnityEngine.Random.Range (0.0f, 1.0f)
			);
		}

	}
}

