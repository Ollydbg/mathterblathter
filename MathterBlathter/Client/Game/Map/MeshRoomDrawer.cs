using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Map.Ascii;
using Client.Game.Enums;

namespace Client.Game.Map
{
	public class MeshRoomDrawer : Client.Game.Map.Room.IRoomDrawer
	{
		AsciiMeshExtractor extractor;

		public MeshRoomDrawer ()
		{
			
		}

		private static Vector3 FLOOR_OFFSET = new Vector3 (0, -1, -2);
		private const int DOOR_HEIGHT = 3;


		public void Draw (Room room)
		{
			//DrawMedian(new Vector3(room.X, 2 * -.5f + room.Y, 0), new Vector3(room.Width, 2, 1f), Color.black);

			extractor = new AsciiMeshExtractor (room.data.AsciiMap);
			//get contour
			var color = RandomColor();
			CreateLight (room);

			DrawCeiling (room, color);
			DrawFloors (room, color);
			DrawWalls (room, color);
			DrawDoors (room);

		}

		void DrawCeiling (Room room, Color color)
		{
			foreach (var contour in extractor.readRows(AsciiMap.CEILING)) {
				var go = new GameObject ();
				go.name = "mesh ceiling";
				var mr = go.AddComponent<MeshRenderer> ();
				var mf = go.AddComponent<MeshFilter> ();
				var collider = go.AddComponent<MeshCollider> ();
				mf.mesh = extractor.contourToMesh (contour, false);
				collider.sharedMesh = mf.mesh;
				mr.material.color = color;
				go.gameObject.transform.position = GridToWorldSpace (room);
			}
		}

		public void DrawDoors(Room room) {
			foreach (var door in room.Doors) {
				door.transform.localScale = new Vector3 (door.Width, door.Height, 1);

				//the offsets are an artifact of the fact that the doors are just box primitives
				//instead of meshes like the walls
			
				if(door.Side == DoorRoomSide.Top || door.Side == DoorRoomSide.Bottom) {
					door.transform.position = new Vector3 (
						door.X + .5f*door.Width -1,
						door.Y - .5f*door.Height + 1) + GridToWorldSpace(room);

				} else {
					door.transform.position = new Vector3 (
						door.X + .5f*door.Width,
						door.Y - .5f*door.Height +2) + GridToWorldSpace(room);
				}


				door.GameObject.GetComponent<MeshRenderer> ().material.color = Color.cyan;
			}
		}

		void DrawWalls (Room room, Color color)
		{
			foreach (var contour in extractor.readColumns(AsciiMap.WALL)) {
				var go = new GameObject ();
				go.name = "mesh wall";
				var mr = go.AddComponent<MeshRenderer> ();
				var mf = go.AddComponent<MeshFilter> ();
				var collider = go.AddComponent<MeshCollider> ();
				mf.mesh = extractor.contourToMesh (contour, false);
				collider.sharedMesh = mf.mesh;
				mr.material.color = color;
				go.gameObject.transform.position += GridToWorldSpace (room);
			}
		}

		void DrawFloors (Room room, Color color)
		{
			foreach (var contour in extractor.readRows(AsciiMap.FLOOR)) {

				var go = new GameObject ();
				go.name = "mesh floor";
				var mr = go.AddComponent<MeshRenderer> ();
				var mf = go.AddComponent<MeshFilter> ();
				var collider = go.AddComponent<MeshCollider> ();
				mf.mesh = extractor.contourToMesh (contour, true);
				collider.sharedMesh = mf.mesh;
				mr.material.color = color;
				go.gameObject.transform.position += GridToWorldSpace (room);

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

		Vector3 GridToWorldSpace(Room room) {
			var mapWidth = room.data.AsciiMap.Width;
			return new Vector3 (room.X, room.Y);
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

