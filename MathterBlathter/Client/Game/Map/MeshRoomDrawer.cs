using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Map.Ascii;

namespace Client.Game.Map
{
	public class MeshRoomDrawer : Client.Game.Map.Room.IRoomDrawer
	{
		AsciiMapExtractor extractor;

		public MeshRoomDrawer ()
		{
			
		}

		private static Vector3 FLOOR_OFFSET = new Vector3 (0, -1, -2);


		public void Draw (Room room)
		{
			//DrawMedian(new Vector3(room.X, 2 * -.5f + room.Y, 0), new Vector3(room.Width, 2, 1f), Color.black);

			extractor = new AsciiMapExtractor (room.data.AsciiMap);
			//get contour
			var color = RandomColor();
			CreateLight (room);

			DrawFloors (room, color);


		}


		void DrawFloors (Room room, Color color)
		{
			foreach (var contour in extractor.getContourSegments(AsciiMap.FLOOR)) {

				var go = new GameObject ();
				go.name = "mesh floor";
				var mr = go.AddComponent<MeshRenderer> ();
				var mf = go.AddComponent<MeshFilter> ();
				var collider = go.AddComponent<MeshCollider> ();
				mf.mesh = extractor.contourToMesh (contour);
				collider.sharedMesh = mf.mesh;
				mr.material.color = color;
				go.gameObject.transform.position += offsetForRoom (room);

			}
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

		Vector3 offsetForRoom(Room room) {
			var mapWidth = room.data.AsciiMap.Width;
			return new Vector3 (room.X + mapWidth * -.5f, room.Y) + FLOOR_OFFSET;
		}


		void DrawMedian (Vector3 position, Vector3 scale, Color color)
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

	}
}

