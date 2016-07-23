using System;
using UnityEngine;
using TiledSharp;
using Client.Game.Enums;
using System.Linq;
using System.Collections.Generic;
using Client.Game.Map.TMX;

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
			go.name = "TMXRoom " + room.data.Id;


			var hardGeo = tmx.Layers.FirstOrDefault(l => l.Name == Constants.HardGeometryLayer);
			DrawHardGeo(hardGeo, go, tmx, sprites, room);

			var background = tmx.Layers.FirstOrDefault(p => p.Name == Constants.BackgroundLayer);
			DrawScenery(background, go, tmx, sprites, room);

			var lights = tmx.ObjectGroups.FirstOrDefault(p => p.Name == Constants.LightsLayer);
			DrawLights(lights, go, tmx, sprites, room);

			var doors = tmx.Layers.FirstOrDefault(p => p.Name == Constants.DoorsLayer);
			DrawDoors(doors, go, tmx, sprites, room);


			return go;
		
		}

		void DrawLights (TmxObjectGroup lights, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{
			if(lights != null) {
				room.Lights = new List<Light>();

				foreach( var obj in lights.Objects) {
					var lightPos = new IPoint((int)(obj.X/tmx.TileWidth), tmx.Height - (int)(obj.Y/tmx.TileHeight)).GridToWorld(room, tmx);
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
			
		}

		void DrawHardGeo (TmxLayer hardGeo, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{

			if(hardGeo != null) {
				foreach( var tile in hardGeo.Tiles) {
					if(tile.Gid != 0) {

						var tileGo = TileAtLocation(go, tile, tmx, sprites, room);
						AddCollision(tileGo);

					}

				}
			}

		}

		void DrawScenery (TmxLayer background, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{

			if(background != null) {
				foreach( var tile in background.Tiles) {
					if(tile.Gid != 0) {
						TileAtLocation(go, tile, tmx, sprites, room);
					}

				}
			}
		}

		

		GameObject TileAtLocation (GameObject parent, TmxLayerTile tile, TmxMap map, Sprite[] spriteLookup, Room room)
		{
			var coords = new IPoint(tile.X, map.Height - tile.Y);

			var sprite = GetSprite(spriteLookup, tile, map);


			var tileGo = new GameObject();
			tileGo.transform.parent = parent.transform;
			tileGo.transform.localPosition = coords.GridToWorld(room, map, sprite.rect);

			var spriteComp = tileGo.AddComponent<SpriteRenderer>();

			tileGo.isStatic = true;
			tileGo.transform.localScale = Vector3.one * PIXEL_UP_SCALE;
			spriteComp.sprite = sprite;

			return tileGo;

		}

		void AddCollision (GameObject tileGo)
		{

			tileGo.AddComponent<BoxCollider2D>();
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

		class IPoint {
			public int X, Y;
			public IPoint(int x, int y) { X = x; Y = y;}

			public Vector3 GridToWorld(Room room, TmxMap map, Rect centeredRect) {
				var spaceResolution = map.TileWidth / 100f;
				var halfWidth = centeredRect.width * .5f;
				var halfHeight = centeredRect.height * .5f;

				return new Vector3(
					(X + halfWidth * .01f) * spaceResolution * PIXEL_UP_SCALE,
					(Y - halfHeight * .01f) * spaceResolution * PIXEL_UP_SCALE, 
					0f
				);
			}

			public Vector3 GridToWorld(Room room, TmxMap map) {
				
				var spaceResolution = map.TileWidth / 100f;

				return new Vector3(
					X * spaceResolution * PIXEL_UP_SCALE,
					Y * spaceResolution * PIXEL_UP_SCALE, 
					0f
				);

			}
		}
	}

}

