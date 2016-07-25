using System;
using UnityEngine;
using TiledSharp;
using Client.Game.Enums;
using System.Linq;
using System.Collections.Generic;
using Client.Game.Map.TMX;
using Client.Game.Data;
using Client.Game.Utils;

namespace Client.Game.Map
{
	using Game = Game.Core.Game;

	public class TMXRoomDrawer : Client.Game.Map.Room.IRoomDrawer
	{
		private static float PIXEL_UP_SCALE = 5f;


		private static UnityEngine.Object PointLightTemplate;
		private static UnityEngine.Object DirectionalLightTemplate;
		


		public TMXRoomDrawer ()
		{
		}

		public GameObject Draw (Room room, Game inGame)
		{

			if(PointLightTemplate == null) {
				PointLightTemplate = Resources.Load("Lights/PointLight");
				DirectionalLightTemplate = Resources.Load("Lights/DirectionalLight");
			}


			var tmx = TMXCache.Get(room.data);

			var sheetName = "TileMaps/Concept50X";
			Sprite[] sprites = Resources.LoadAll<Sprite>(sheetName);

			var go = new GameObject();
			go.transform.position = GridToWorldSpace(room);
			go.name = "TMXRoom_" + room.data.Id + "_" + room.Id;
			

			var hardGeo = tmx.Layers.FirstOrDefault(l => l.Name == Constants.HardGeometryLayer);
			DrawHardGeo(hardGeo, go, tmx, sprites, room);

			var background = tmx.Layers.FirstOrDefault(p => p.Name == Constants.SceneryLayer);
			DrawScenery(background, go, tmx, sprites, room);

			var lights = tmx.ObjectGroups.FirstOrDefault(p => p.Name == Constants.LightsLayer);
			DrawLights(lights, go, tmx, sprites, room);

			var doors = tmx.Layers.FirstOrDefault(p => p.Name == Constants.DoorsLayer);
			DrawDoors(doors, go, tmx, sprites, room);

			DrawBackground(room, room.Zone.DrawColor, go, inGame);

			return go;
		
		}

		void DrawLights (TmxObjectGroup lights, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{
			if(lights != null) {
				room.Lights = new List<Light>();

				foreach( var obj in lights.Objects) {
					var lightPos = new IPoint((int)(obj.X/tmx.TileWidth), tmx.Height - (int)(obj.Y/tmx.TileHeight)).GridToWorld(tmx);
					if(obj.Type == Constants.SPOT_LIGHT) {
						
						var lightObj = GameObject.Instantiate(DirectionalLightTemplate) as GameObject;

						room.Lights.Add(lightObj.GetComponent<Light>());
						lightObj.SetActive(false);

						lightObj.transform.parent = go.transform;
						lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, lightObj.transform.position.z);

						lightObj.name = "directional light";

					} else if (obj.Type == Constants.POINT_LIGHT) {
						var lightObj = GameObject.Instantiate(PointLightTemplate) as GameObject;

						room.Lights.Add(lightObj.GetComponent<Light>());
						lightObj.SetActive(false);

						lightObj.transform.parent = go.transform;
						lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, lightObj.transform.position.z);

						lightObj.name = "point light";
					}
				}	

			}
		}

		void DrawDoors (TmxLayer doors, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{
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

		void DrawHardGeo (TmxLayer hardGeo, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{

			if(hardGeo != null) {
				foreach( var tile in hardGeo.Tiles) {
					if(tile.Gid != 0) {
						Sprite sprite;
						var tileGo = TileAtLocation(go, tile, tmx, sprites, room, out sprite);
						tileGo.name = "Room Tile";
						AddCollision(tileGo, sprite);

					}

				}
			}

		}

		void DrawScenery (TmxLayer background, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{

			if(background != null) {
				foreach( var tile in background.Tiles) {
					if(tile.Gid != 0) {
						Sprite sprite;
						var obj = TileAtLocation(go, tile, tmx, sprites, room, out sprite);
						obj.name = "Scene object";
						obj.transform.localPosition = obj.transform.localPosition + Vector3.forward*2f;
					}

				}
			}
		}

		void DrawBackground (Room room, Color drawColor, GameObject go, Game game)
		{
			//var container = new GameObject();
			ParallaxData layerData = room.data.LayerData ?? game.Seed.RandomInList(ParallaxDataTable.GetAll().Where(p => p.InRandomPool).ToList());
			var texturePath = layerData.Layers[ParallaxData.Layer.RoomWall];
			if(texturePath == null)
				return;

			var plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

			plane.transform.Rotate(Vector3.right, 270);

			var material = (Material)GameObject.Instantiate(Resources.Load(ParallaxData.materialPath, typeof(Material)) as Material);
			material.mainTexture = Resources.Load(texturePath, typeof(Texture)) as Texture;

			plane.GetComponent<Renderer>().material = material;
			var tint = drawColor * .3f;
			tint.a = 1f;
			material.SetColor("_Color", tint);

			GameObject.Destroy(plane.GetComponent<Collider>());

			plane.transform.localScale = new Vector3(room.data.ScreenWidth*.1f, 1f, room.data.ScreenHeight*.1f);
			plane.transform.position = new Vector3(room.X + room.data.ScreenWidth*.5f, room.Y + room.data.ScreenHeight*.5f, 5);
			plane.transform.parent = go.transform;
		}
		

		GameObject TileAtLocation (GameObject parent, TmxLayerTile tile, TmxMap map, Sprite[] spriteLookup, Room room, out Sprite sprite)
		{
			var coords = new IPoint(tile.X, map.Height - 1 - tile.Y);

			sprite = GetSprite(spriteLookup, tile, map);

			var tileGo = new GameObject();
			tileGo.transform.parent = parent.transform;
			tileGo.transform.localPosition = coords.GridToWorld(map, sprite.rect);

			var spriteComp = tileGo.AddComponent<SpriteRenderer>();

			tileGo.isStatic = true;
			tileGo.transform.localScale = Vector3.one * PIXEL_UP_SCALE;
			spriteComp.sprite = sprite;

			return tileGo;

		}

		void AddCollision (GameObject tileGo, Sprite sprite)
		{
			
			SpriteColliderFactory.AddBoxCollider2D(tileGo, sprite);
			var rb = tileGo.AddComponent<Rigidbody2D>();
			rb.isKinematic = true;
			tileGo.layer = LayerMask.NameToLayer(Layers.HardGeometry.ToString());

		}

		Vector3 GridToWorldSpace(Room room) {
			return new Vector3 (room.X, room.Y);
		}

		Sprite GetSprite(Sprite[] lookup, TmxLayerTile tile, TmxMap map) {
			var tmxImage = map.Tilesets[0].Tiles.Where(p => p.Id == (tile.Gid-1)).FirstOrDefault().Image;

			var pathBits = tmxImage.Source.Split('/');
			string name = pathBits[pathBits.Length-1];
			name = name.Replace(".png", "");
			return lookup.Where(p=>p.name == name).First();
		}

		public class IPoint {
			public int X, Y;
			public IPoint(int x, int y) { X = x; Y = y;}
			public IPoint(Vector3 v3) { X = (int)v3.x; Y = (int)v3.y; }

			public Vector3 GridToWorld(TmxMap map, Rect centeredRect) {
				var ppu = .01f;
				var spaceResolution = map.TileWidth * ppu;


				//assumes TL registration, which is not always going to be the case
				var worldCoordX = X * spaceResolution * PIXEL_UP_SCALE;
				var worldCoordY = Y * spaceResolution * PIXEL_UP_SCALE;
				var widthOffset = centeredRect.width * PIXEL_UP_SCALE * ppu * .5f;
				var heightOffset = centeredRect.height * PIXEL_UP_SCALE * ppu * .5f;
				return new Vector3(
					worldCoordX + widthOffset,
					worldCoordY - heightOffset

				);
			}

			public Vector3 GridToWorld(TmxMap map) {
				
				var spaceResolution = map.TileWidth / 100f;

				return new Vector3(
					X * spaceResolution * PIXEL_UP_SCALE,
					Y * spaceResolution * PIXEL_UP_SCALE, 
					0f
				);

			}

			public Vector3 GridToWorldTL(TmxMap map) {

				var spaceResolution = map.TileWidth / 100f;
				var widthOffset = map.TileWidth * PIXEL_UP_SCALE * .01f * .5f;
				var heightOffset = map.TileHeight * PIXEL_UP_SCALE * .01f * .5f;

				return new Vector3(
					X * spaceResolution * PIXEL_UP_SCALE + widthOffset,
					Y * spaceResolution * PIXEL_UP_SCALE,// heightOffset, 
					0f
				);

			}
		}
	}

}

