using System;
using UnityEngine;
using TiledSharp;
using Client.Game.Enums;
using System.Linq;
using System.Collections.Generic;
using Client.Game.Map.TMX;
using Client.Game.Data;
using Client.Game.Utils;
using Client.Game.Geometry;

namespace Client.Game.Map
{
	using Game = Game.Core.Game;

	public class TMXRoomDrawer : Client.Game.Map.Room.IRoomDrawer
	{

		private static UnityEngine.Object PointLightTemplate;
		private static UnityEngine.Object SpotLightTemplate;
		private static UnityEngine.Object DownSpotlightTemplate;

		private static Material EnvironmentMat;

		public TMXRoomDrawer ()
		{
		}

		private static PhysicsMaterial2D _ice;
		public static PhysicsMaterial2D Ice {
			get {
				if(_ice == null) {
					_ice = Resources.Load("PhysicsMaterials/ice") as PhysicsMaterial2D;
				}

				return _ice;
			}
		}

		private Room room;

		public GameObject Draw (Room room, Game inGame)
		{
			this.room = room;

			if(PointLightTemplate == null) {
				PointLightTemplate = Resources.Load("Lights/PointLight");
				SpotLightTemplate = Resources.Load("Lights/SpotTemplate");
				DownSpotlightTemplate = Resources.Load("Lights/DownSpotLight");
				EnvironmentMat = Resources.Load("EnvironmentMat") as Material;

			}


			var tmx = TMXCache.Get(room.data);

			var sheetName = "TileMaps/Concept25X";
			Sprite[] sprites = Resources.LoadAll<Sprite>(sheetName);

			var go = new GameObject();
			go.transform.position = GridToWorldSpace(room);
			go.name = "TMXRoom_" + room.data.Id + "_" + room.Id;
			

			var hardGeo = tmx.Layers.FirstOrDefault(l => l.Name == Constants.HardGeometryLayer);
			DrawGeo(hardGeo, go, tmx, sprites, room, true);

			var groundTop = tmx.Layers.FirstOrDefault(l => l.Name == Constants.GroundTopLayer);
			DrawGeo(groundTop, go, tmx, sprites, room, false);

			var softGeo = tmx.Layers.FirstOrDefault(l => l.Name == Constants.SoftGeometryLayer);
			DrawSoftGeo(softGeo, go, tmx, sprites, room);

			var scenery = tmx.Layers.FirstOrDefault(p => p.Name == Constants.SceneryLayer);
			DrawScenery(scenery, go, tmx, sprites, room, 100f);

			var decorBack = tmx.Layers.FirstOrDefault(p => p.Name == Constants.DecorBackLayer);
			DrawScenery(decorBack, go, tmx, sprites, room, 3f);

			var decorFront = tmx.Layers.FirstOrDefault(p => p.Name == Constants.DecorFrontLayer);
			DrawScenery(decorFront, go, tmx, sprites, room, -1f);


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

					var lightPos = GridPoint.FromTMXObject(obj, tmx).GridToWorldBL(tmx);

					if(obj.Type == Constants.SPOT_LIGHT) {
						
						var lightObj = GameObject.Instantiate(SpotLightTemplate) as GameObject;

						room.Lights.Add(lightObj.GetComponent<Light>());
						lightObj.SetActive(false);

						lightObj.transform.parent = go.transform;
						lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, lightObj.transform.position.z);

						lightObj.name = "spot light";

					} else if (obj.Type == Constants.POINT_LIGHT) {
						var lightObj = GameObject.Instantiate(PointLightTemplate) as GameObject;

						room.Lights.Add(lightObj.GetComponent<Light>());
						lightObj.SetActive(false);

						lightObj.transform.parent = go.transform;
						lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, lightObj.transform.position.z);

						lightObj.name = "point light";
					} 

					else if (obj.Type == Constants.DOWN_SPOT_LIGHT) {
						var lightObj = GameObject.Instantiate(DownSpotlightTemplate) as GameObject;

						room.Lights.Add(lightObj.GetComponent<Light>());
						lightObj.SetActive(false);

						lightObj.transform.parent = go.transform;
						lightObj.transform.localPosition = new Vector3 (lightPos.x, lightPos.y, lightObj.transform.position.z);

						lightObj.name = "down spot light";
					} 
				}	

			}
		}

		void DrawDoors (TmxLayer doors, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{
			var doorBuffer = room.Doors.Concat(room.SealedDoors);

			foreach (var door in doorBuffer) {
				if(!door.Set) {
					
					//door width/height are in tile units
					var gridScale = new GridPoint(door.Width, door.Height).GridToWorldBL(tmx) + Vector3.forward;
					door.transform.localScale = gridScale;
					//door.GameObject.hideFlags = HideFlags.HideInHierarchy;

					if(door.WallDoor) {
						float offset = door.Side == DoorRoomSide.Left? -1 : 0;
						door.transform.position = new Vector3 (
							door.X + .5f*door.Width + offset,
							door.Y - .25f) + GridToWorldSpace(room);

					} else {
						float offset = door.Side == DoorRoomSide.Bottom? -1 : 0;
						door.transform.position = new Vector3 (
							door.X + .5f*door.Width + .75f,
							door.Y + 1.5f) + GridToWorldSpace(room);
					}
					door.Set = true;
				}

			}
		}

		void DrawGeo (TmxLayer hardGeo, GameObject go, TmxMap tmx, Sprite[] sprites, Room room, bool addCollsion)
		{

			if(hardGeo != null) {
				foreach( var tile in hardGeo.Tiles) {
					if(tile.Gid != 0) {
						Sprite sprite;
						var tileGo = TileAtLocation(go, tile, tmx, sprites, room, .5f, true, out sprite);
						tileGo.name = "tileGid-" + tile.Gid;
						if(addCollsion)
							AddCollision(tileGo, sprite);

					}

				}
			}

		}

		void DrawSoftGeo (TmxLayer hardGeo, GameObject go, TmxMap tmx, Sprite[] sprites, Room room)
		{

			if(hardGeo != null) {
				foreach( var tile in hardGeo.Tiles) {
					if(tile.Gid != 0) {
						Sprite sprite;
						var tileGo = TileAtLocation(go, tile, tmx, sprites, room, .5f, true, out sprite);
						tileGo.name = "tileGid-" + tile.Gid;
						AddCollision(tileGo, sprite);

						tileGo.layer = LayerMask.NameToLayer(Layers.SoftGeometry.ToString());
						PassthroughPlatformFactory.Init(tileGo);
					}

				}
			}

		}

		void DrawScenery (TmxLayer background, GameObject go, TmxMap tmx, Sprite[] sprites, Room room, float depth)
		{

			if(background != null) {
				foreach( var tile in background.Tiles) {
					if(tile.Gid != 0) {
						Sprite sprite;
						var obj = TileAtLocation(go, tile, tmx, sprites, room, depth, false, out sprite);
						obj.name = "Scene object";
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

			plane.transform.localScale = new Vector3(room.data.WorldWidth*.1f, 1f, room.data.WorldHeight*.1f);
			plane.transform.position = new Vector3(room.X + room.data.WorldWidth*.5f, room.Y + room.data.WorldHeight*.5f, 30f);
			plane.transform.parent = go.transform;
		}
		

		GameObject TileAtLocation (GameObject parent, TmxLayerTile tile, TmxMap map, Sprite[] spriteLookup, Room room, float depth, bool lit, out Sprite sprite)
		{
			var coords = new GridPoint(tile.X, map.Height - 1 - tile.Y);

			sprite = GetSprite(spriteLookup, tile, map);

			var tileGo = new GameObject();

			tileGo.transform.parent = parent.transform;
			tileGo.transform.localPosition = coords.GridToWorldBL(map, sprite.rect) + Vector3.forward*depth;

			var spriteComp = tileGo.AddComponent<SpriteRenderer>();
			if(lit)
				spriteComp.material = EnvironmentMat;

			tileGo.isStatic = true;
			tileGo.transform.localScale = Vector3.one * GridPoint.PIXEL_UP_SCALE;
			spriteComp.sprite = sprite;

			return tileGo;

		}

		void AddCollision (GameObject tileGo, Sprite sprite)
		{
			
			SpriteColliderFactory.AddBoxCollider2D(tileGo, sprite, Ice);
			var rb = tileGo.AddComponent<Rigidbody2D>();
			rb.isKinematic = true;
			tileGo.layer = LayerMask.NameToLayer(Layers.HardGeometry.ToString());


		}

		Vector3 GridToWorldSpace(Room room) {
			return new Vector3 (room.X, room.Y);
		}

		Sprite GetSprite(Sprite[] lookup, TmxLayerTile tile, TmxMap map) {
			var sprite = map.Tilesets[0].Tiles.Where(p => p.Id == (tile.Gid-1)).FirstOrDefault();
			if(sprite == null) {
				Debug.LogError("Couldn't find sprite with gid=" + tile.Gid + " referenced by room data id =" + room.data.Id);
				sprite = map.Tilesets[0].Tiles[0];
			}

			var tmxImage = sprite.Image;

			var pathBits = tmxImage.Source.Split('/');
			string name = pathBits[pathBits.Length-1];
			name = name.Replace(".png", "");
			return lookup.Where(p=>p.name == name).First();
		}


	}

}

