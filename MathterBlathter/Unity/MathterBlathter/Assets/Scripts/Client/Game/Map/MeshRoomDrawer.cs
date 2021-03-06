﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Data.Ascii;
using Client.Game.Enums;
using Client.Game.Geometry;
using Client.Game.Data;

namespace Client.Game.Map
{
	using Game = Client.Game.Core.Game;

	public class MeshRoomDrawer : Client.Game.Map.Room.IRoomDrawer
	{
		AsciiMeshExtractor extractor;

		
		
		public MeshRoomDrawer ()
		{
			
		}

		private const int DOOR_HEIGHT = 3;
		private static UnityEngine.Object PointLightTemplate;
		private static UnityEngine.Object DirectionalLightTemplate;
		public GameObject Draw (Room room, Game game)
		{
			if(PointLightTemplate == null) {
				PointLightTemplate = Resources.Load("Lights/PointLight");
				DirectionalLightTemplate = Resources.Load("Lights/DirectionalLight");
			}

			var gameObject = new GameObject();
			gameObject.transform.position = GridToWorldSpace(room);
			gameObject.name = "ROOM " + room.data.Id;

			extractor = new AsciiMeshExtractor (room.data.AsciiMap);
			//get contour
			var color = room.Zone.DrawColor;
			DrawLights (room, gameObject);
			DrawCeiling (room, color, gameObject);
			DrawFloors (room, color, gameObject);
			DrawWalls (room, color, gameObject);
			DrawSealedDoors(room, color, gameObject);
			DrawPlatforms(room, color, gameObject);
			DrawDoors (room, gameObject);
			DrawBackground(room, color, gameObject, game);

			return gameObject;

		}

        

		void DrawBackground (Room room, Color color, GameObject parentObject, Game game)
		{
			//var container = new GameObject();
			ParallaxData layerData = room.data.LayerData ?? game.Seed.RandomInList(ParallaxDataTable.GetAll().Where(p => p.InRandomPool).ToList());
			var texturePath = layerData.Layers[ParallaxData.Layer.RoomWall];
			if(texturePath == null)
				return;
			
			var plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			//plane.transform.parent = container.transform;

			plane.transform.Rotate(Vector3.right, 270);

			var material = (Material)GameObject.Instantiate(Resources.Load(ParallaxData.materialPath, typeof(Material)) as Material);
			material.mainTexture = Resources.Load(texturePath, typeof(Texture)) as Texture;

			plane.GetComponent<Renderer>().material = material;
			var tint = color * .3f;
			tint.a = 1f;
			material.SetColor("_Color", tint);

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
					door.GameObject.hideFlags = HideFlags.HideInHierarchy;
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


		void AddColliderForChunk(GameObject go, Chunk chunk, bool trigger) {
			var box = go.AddComponent<BoxCollider2D>();
			box.size = new Vector3(chunk.Width, chunk.Height, 1);
			var halfSize = box.size*.5f;
			if(chunk.Height > 1) halfSize.y = -.5f*chunk.Height+1;
			box.offset = halfSize;
			box.isTrigger = trigger;

			var rb = go.AddComponent<Rigidbody2D>();
			rb.isKinematic = true;
			rb.gravityScale = 0f;
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
				var lightObj = GameObject.Instantiate(PointLightTemplate) as GameObject;

				room.Lights.Add(lightObj.GetComponent<Light>());
				lightObj.SetActive(false);

				lightObj.transform.parent = gameObject.transform;
				lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, lightObj.transform.position.z);

				lightObj.name = "point light";
			}

			foreach( var lightPos in extractor.getAllMatching(AsciiConstants.DIRECTIONAL_LIGHT, true)) {
				var lightObj = GameObject.Instantiate(DirectionalLightTemplate) as GameObject;

				room.Lights.Add(lightObj.GetComponent<Light>());
				lightObj.SetActive(false);

				lightObj.transform.parent = gameObject.transform;
				lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, lightObj.transform.position.z);

				lightObj.name = "directional light";
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
			return new Vector3 (room.X, room.Y);
		}

	}
}

