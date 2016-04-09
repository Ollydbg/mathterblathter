using System;
using UnityEngine;
using Client.Game.Actors;

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

			Color color = RandomColor ();

			DrawWalls (room, color);
			DrawDoors (room);
			CreateLight (room);
		}

		public void DrawDoors(Room room) {
			foreach (var door in room.Doors) {
				door.transform.localScale = new Vector3 (1, DOOR_HEIGHT, 1);
				door.transform.position = new Vector3 (door.X + room.X, door.Y + room.Y, -1);

				door.GameObject.GetComponent<MeshRenderer> ().material.color = Color.cyan;
			}
		}

		void DrawWalls (Room room, Color color)
		{
			//median
			//DrawWall(new Vector3(room.X, FLOOR_HEIGHT * -.5f + room.Y, 0), new Vector3(room.Width, FLOOR_HEIGHT, 1f));


			//floor
			DrawWall(new Vector3(room.X, FLOOR_HEIGHT * -.5f + room.Y - .5f*room.Height, 0), new Vector3(room.Width, FLOOR_HEIGHT, 1f), color);

			//left wall
			DrawWall (new Vector3(room.X - .5f*room.Width, room.Y, 0), new Vector3(1, room.Height, 1), color);

			//right wall
			DrawWall (new Vector3(room.X + .5f*room.Width, room.Y, 0), new Vector3(1, room.Height, 1), color);

			//ceiling
			DrawWall(new Vector3(room.X, FLOOR_HEIGHT * -.5f + room.Y + .5f*room.Height, 0), new Vector3(room.Width, FLOOR_HEIGHT, 1f), color);



		}

		void DrawWall (Vector3 position, Vector3 scale, Color color)
		{
			var floor = GameObject.CreatePrimitive (PrimitiveType.Cube);
			floor.transform.localScale = scale;
			var rb = floor.AddComponent<Rigidbody> ();
			rb.useGravity = false;
			rb.isKinematic = true;
			floor.transform.position = position;
			floor.name = "floor";
			floor.GetComponent<MeshRenderer> ().material.color = color;

		}

		void CreateLight (Room room)
		{
			var lightObj = new GameObject ();
			var light = lightObj.AddComponent<Light> ();
			light.range = room.Width;
			lightObj.transform.position = new Vector3 (room.X, room.Y, -10f);
			light.type = LightType.Point;
			light.intensity = 7;
			lightObj.name = "light";
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

