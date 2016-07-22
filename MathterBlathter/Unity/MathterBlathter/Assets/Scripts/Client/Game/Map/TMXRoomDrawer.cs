using System;
using UnityEngine;
using TiledSharp;

namespace Client.Game.Map
{
	using Game = Game.Core.Game;

	public class TMXRoomDrawer : Client.Game.Map.Room.IRoomDrawer
	{
		private static float TileSize = .35f;

		public TMXRoomDrawer ()
		{
			
		}

		public GameObject Draw (Room room, Game inGame)
		{
			var tmx = new TmxMap("Assets/Resources/" + room.data.TMXResource);

			var sheetName = "TileMaps/" + tmx.Tilesets[0].Name;
			Sprite[] sprites = Resources.LoadAll<Sprite>(sheetName);

			var go = new GameObject();
			go.transform.position = GridToWorldSpace(room);
			go.name = "TMXRoom " + room.data.Id;


			foreach( var tile in tmx.Layers[0].Tiles) {
				Create(go, tile, tmx, sprites, room);
			}

			return go;
		}

		void Create (GameObject parent, TmxLayerTile tile, TmxMap map, Sprite[] spriteLookup, Room room)
		{
			if(tile.Gid != 0) {

				var coords = new IPoint(tile.X, map.Height - tile.Y);
				

				var tileGo = new GameObject();
				tileGo.transform.parent = parent.transform;
				tileGo.transform.localPosition = new Vector3(coords.X * TileSize, coords.Y * TileSize, 0f);

				var sprite = tileGo.AddComponent<SpriteRenderer>();
				sprite.sprite = spriteLookup[tile.Gid];
			}
		}

		Vector3 GridToWorldSpace(Room room) {
			return new Vector3 (room.X, room.Y);
		}

		class IPoint {
			public int X, Y;
			public IPoint(int x, int y) { X = x; Y = y;}
		}
	}

}

