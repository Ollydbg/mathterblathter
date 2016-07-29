using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Data.Ascii;
using Client.Game.Map;
using UnityEngine;
using Client.Game.Map.TMX;

namespace Client.Game.Data
{
	public static partial class RoomDataTable
	{
		private static Dictionary<int, RoomData> _all;
		static void StaticInit() {
			_all = typeof(RoomDataTable).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as RoomData)
				.ToDictionary(p => p.Id, p=>p);

		}

		public static List<RoomData> GetAll() {
			if(_all == null) StaticInit();
			return _all.Values.ToList();
		}


		public static RoomData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
		}


		public static RoomData LURCH_START {
			get {
				var ret = new RoomData ();
				ret.Id = 100;
				ret.Type = RoomType.LurchStart | RoomType.NoWaves;
				ret.TMXResource = "TMXData/Zone1/Lurch.tmx";
				ret.SortOrder = 0;

				ret.LayerData = ParallaxDataTable.OUTDOORS;
				ret.MaxInstances = 1;
				ret.SetPiece = SetPieceDataTable.INTRO;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData DEBUG_ROOM {

			get {
				var ret = new RoomData();
				ret.Id = 2;
				ret.TMXResource = "TMXData/Zone1/Template.tmx";

				ret.Type = RoomType.Normal | RoomType.NoWaves;
				ret.LayerData = ParallaxDataTable.OUTDOORS;
				ret.OverrideMusic = MusicDataTable.SHOP_MUSIC;
				finalize(ret);

				return ret;
			}

		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 101;
				ret.TMXResource = "TMXData/Zone1/101.tmx";

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_2 {
			get {
				var ret = new RoomData ();
				ret.Id = 102;
				ret.TMXResource = "TMXData/Zone1/101.tmx";

			
				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_3 {
			get {
				var ret = new RoomData ();
				ret.Id = 103;
				ret.TMXResource = "TMXData/Zone1/101.tmx";


				ret.AsciiSpawnLookup['2'] = CharacterDataTable.RANDOM_WEAPON_PICKUP;

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_4 {
			get {
				var ret = new RoomData ();
				ret.Id = 104;
				ret.TMXResource = "TMXData/Zone1/101.tmx";


				ret.AsciiSpawnLookup['s'] = CharacterDataTable.SPIKES_FIXTURE;
				ret.AsciiSpawnLookup['T'] = new AsciiPlacement(CharacterDataTable.WALL_TURRET_FIXTURE, Vector3.down);

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_5 {
			get {
				var ret = new RoomData ();
				ret.Id = 105;

				ret.TMXResource = "TMXData/Zone1/101.tmx";


				finalize(ret);

				return ret;
			}
		}


		public static RoomData SHOP_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 106;
				ret.TMXResource = "TMXData/Zone1/Shop1.tmx";
				ret.Type = RoomType.Store | RoomType.NoWaves;
				ret.OverrideMusic = MusicDataTable.SHOP_MUSIC;
				ret.LayerData = ParallaxDataTable.OUTDOORS;

				finalize(ret);

				return ret;
			}
		}


		public static RoomData BOSS_FIGHT_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 121;
				ret.Type = RoomType.Boss | RoomType.NoWaves;
				ret.TMXResource = "TMXData/Zone1Boss/121.tmx";

				ret.LayerData = ParallaxDataTable.ABSTRACT;

				ret.AsciiSpawnLookup['B'] = CharacterDataTable.BOSS_1;
				ret.AsciiSpawnLookup['U'] = CharacterDataTable.LAUNCH_PAD_FIXTURE;

				finalize(ret);

				return ret;
			}
		}


		static void finalize(RoomData room) {
			var tmx = TMXCache.Get(room);
			room.Width = tmx.Width - 1;
			room.Height = tmx.Height - 1;
			var expandedSize = new GridPoint(room.Width, room.Height).GridToWorld(tmx);
			room.WorldWidth = expandedSize.x;
			room.WorldHeight = expandedSize.y;

			room.HardGeoTileMap.AddData(tmx.Layers.First(l => l.Name == Constants.HardGeometryLayer), tmx.Width);

			addDoorsFromTMX (room, tmx);
			addSpawnsFromTMX (room);
			Debug.Log("finalizing room: " + room);

		}


		static void addSpawnsFromTMX (RoomData room)
		{
			return;
			/*
			var extractor = new AsciiMeshExtractor(room.AsciiMap);
			foreach( var spawnType in room.AsciiSpawnLookup) {
				foreach( Vector3 match in extractor.getAllMatching(spawnType.Key, true)) {
					var spawn = new RoomData.Spawn(spawnType.Value.Data);
					spawn.X = match.x;
					spawn.Y = match.y;
					spawn.Facing = spawnType.Value.Facing;
					room.Spawns.Add(spawn);
				}
			}*/
		}

		static void addDoorsFromTMX (RoomData room, TiledSharp.TmxMap tmx)
		{
			var extractor = new TMXChunkExtractor(tmx);
			var matches = extractor.GetChunksOnLayer(Constants.DoorsLayer);

			foreach( var chunk in matches ) {
				var middleNode = chunk.FirstNode;
				var doorPos = new GridPoint(middleNode).GridToWorld(tmx);

				var link = new RoomData.Link ();
				
				link.X = (int)doorPos.x;
				link.Y = (int)doorPos.y;

				link.ChunkData = chunk;

				if (link.X == 0) {
					link.Side = DoorRoomSide.Left;
					link.Width = 2;
					link.Height = 3;
				} else if (link.Y == 0) {
					link.Side = DoorRoomSide.Bottom;
					link.Width = 3;
					link.Height = 2;
				} else if (middleNode.x == room.Width) {
					link.Side = DoorRoomSide.Right;
					link.Width = 2;
					link.Height = 3;
				} else {
					link.Side = DoorRoomSide.Top;
					link.Width = 3;
					link.Height = 2;
				}

				room.Doors.Add (link);
			}
			

		}


	}
}

