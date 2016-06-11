using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Data.Ascii;
using Client.Game.Enums;
using Client.Game.Geometry;
using Client.Game.Data;

namespace Client.Game.Map
{
	public class MeshRoomDrawer : Client.Game.Map.Room.IRoomDrawer
	{
		AsciiMeshExtractor extractor;

		
		
		public MeshRoomDrawer ()
		{
			
		}

		private const int DOOR_HEIGHT = 3;


		public GameObject Draw (Room room)
		{
			var gameObject = new GameObject();
			gameObject.transform.position = GridToWorldSpace(room);
			gameObject.name = "ROOM " + room.data.Id;

			extractor = new AsciiMeshExtractor (room.data.AsciiMap);
			//get contour
			var color = RandomColor();
			DrawLights (room, gameObject);
			DrawCeiling (room, color, gameObject);
			DrawFloors (room, color, gameObject);
			DrawWalls (room, color, gameObject);
			DrawSealedDoors(room, color, gameObject);
			DrawPlatforms(room, color, gameObject);
			DrawDoors (room, gameObject);
			DrawBackground(room, color, gameObject);

			return gameObject;

		}

        

        void DrawBackground (Room room, Color color, GameObject parentObject)
		{
			//var container = new GameObject();

			var plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			//plane.transform.parent = container.transform;

			plane.transform.Rotate(Vector3.right, 270);

			plane.GetComponent<Renderer>().material.color = color*.1f;
			GameObject.Destroy(plane.GetComponent<Collider>());

			plane.transform.localScale = new Vector3(room.Width*.1f, 1f, room.Height*.1f);
			plane.transform.position = new Vector3(room.X + room.Width*.5f, room.Y + room.Height*.5f, 5);
			plane.transform.parent = parentObject.transform;
		}


		void DrawPlatforms (Room room, Color color, GameObject gameObject)
		{
			
			foreach (var chunk in extractor.getChunksMatching(AsciiConstants.PLATFORM)) {
				var go = DrawRoomChunk(room, chunk, color, gameObject, "mesh platform");
				AddColliderForChunk(go, chunk, false);
			}


			foreach (var chunk in extractor.getChunksMatching(AsciiConstants.PASSTHROUGH_PLATFORM)) {
				var go = DrawRoomChunk(room, chunk, color*.5f, gameObject, "passthrough platform");
				//for now, lets just scale this down and move it up
				go.transform.localScale = new Vector3(1, .5f, 1f);
				go.transform.position = go.transform.position + new Vector3(0, .5f, 0);
				go.layer = LayerMask.NameToLayer(Layers.SoftGeometry.ToString());
				AddColliderForChunk(go, chunk, false);
				PassthroughPlatformFactory.Init(go);
			}
		}
		
		private void DrawSealedDoors(Room room, Color color, GameObject gameObject)
        {
            foreach (var chunk in extractor.getChunksMatching(AsciiConstants.SEALED_DOOR)) {
				var go = DrawRoomChunk(room, chunk, color, gameObject, "sealed door");
				AddColliderForChunk(go, chunk, false);
			}
        }

		void DrawCeiling (Room room, Color color, GameObject gameObject)
		{
			foreach (var chunk in extractor.getChunksMatching(AsciiConstants.CEILING)) {
				var go = DrawRoomChunk(room, chunk, color, gameObject, "mesh ceiling");
				AddColliderForChunk(go, chunk, false);
			}
		}

		public void DrawDoors(Room room, GameObject gameobject) {
			foreach (var door in room.Doors) {
				if(!door.Set) {
					door.transform.localScale = new Vector3 (door.Width, door.Height, 1);

					//the offsets are an artifact of the fact that the doors are just box primitives
					//instead of meshes like the walls
				
					if(door.WallDoor) {
						float offset = door.Side == DoorRoomSide.Left? -1 : 0;
						door.transform.position = new Vector3 (
							door.X + .5f*door.Width + offset,
							door.Y - .5f*door.Height +2) + GridToWorldSpace(room);
						
					} else {
						float offset = door.Side == DoorRoomSide.Bottom? -1 : 0;
						door.transform.position = new Vector3 (
							door.X + .5f*door.Width -1,
							door.Y - .5f*door.Height+2 + offset) + GridToWorldSpace(room);
					}
					door.Set = true;
				}

			}
		}

		GameObject DrawRoomChunk(Room room, Chunk chunk, Color color, GameObject parentObj, string name) {
			var go = new GameObject ();
			go.name = name;
			var mr = go.AddComponent<MeshRenderer> ();
			var mf = go.AddComponent<MeshFilter> ();
			//AddColliderForChunk(go, chunk, false);
			go.layer = LayerMask.NameToLayer(Layers.HardGeometry.ToString());
			mf.mesh = extractor.chunkToMesh (chunk);
			mr.material.color = color;
			
			go.gameObject.transform.parent = parentObj.transform;
			go.gameObject.transform.localPosition = chunk.Origin;
			go.isStatic = true;
		

			return go;
		}


		Collider AddColliderForChunk(GameObject go, Chunk chunk, bool trigger) {
			var box = go.AddComponent<BoxCollider>();
			box.size = new Vector3(chunk.Width, chunk.Height, 1);
			var halfSize = box.size*.5f;
			if(chunk.Height > 1) halfSize.y = -.5f*chunk.Height+1;
			box.center = halfSize;
			box.isTrigger = trigger;
			return box;
		}

		void DrawWalls (Room room, Color color, GameObject gameobject)
		{
			foreach (var chunk in extractor.getChunksMatching(AsciiConstants.WALL)) {
				var go = DrawRoomChunk(room, chunk, color, gameobject, "wall");
				AddColliderForChunk(go, chunk, false);
			}
		}




		void DrawFloors(Room room, Color color, GameObject gameobject) {
			foreach (var chunk in extractor.getChunksMatching(AsciiConstants.FLOOR)) {
				var go = DrawRoomChunk(room, chunk, color, gameobject,  "floor");
				AddColliderForChunk(go, chunk, false);
			}
		}


		void DrawLights (Room room, GameObject gameObject)
		{
			room.Lights = new List<Light>();

			foreach( var lightPos in extractor.getAllMatching(AsciiConstants.LIGHT, true)) {
				var lightObj = new GameObject ();
				var light = lightObj.AddComponent<Light> ();
				room.Lights.Add(light);
				lightObj.SetActive(false);
				/*light.type = LightType.Directional;
				light.intensity = .3f;
				light.bounceIntensity = 0f;
				light.transform.parent = gameObject.transform;
				light.transform.localRotation = Quaternion.Euler(22.75f, 0, 0);
				light.transform.localPosition = new Vector3(lightPos.x, lightPos.y, -53f);
				*/
				light.range = room.Width;
				lightObj.transform.parent = gameObject.transform;
				lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, -2f);
				light.type = LightType.Point;
				light.gameObject.transform.Rotate(new Vector3(293f, 0, 0));

				light.intensity = 1f;


				lightObj.name = "light";
			}
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

	}
}

