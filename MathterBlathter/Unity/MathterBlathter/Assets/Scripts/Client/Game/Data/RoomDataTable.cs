﻿using System;
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
				ret.TMXResource = "TMXData/Zone1/DebugRoom.tmx";
				ret.SortOrder = int.MaxValue;
				ret.Type =  RoomType.Debug | RoomType.NoWaves;
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
				ret.TMXResource = "TMXData/Zone1/102.tmx";

			
				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_3 {
			get {
				var ret = new RoomData ();
				ret.Id = 103;
				ret.TMXResource = "TMXData/Zone1/103.tmx";

				finalize(ret);

				return ret;
			}
		}


		public static RoomData WEAPON_SHOP {
			get {
				var ret = new RoomData ();
				ret.Id = 106;
				ret.TMXResource = "TMXData/Zone1/WeaponShop.tmx";
				ret.Type = RoomType.Store | RoomType.NoWaves;
				ret.OverrideMusic = MusicDataTable.SHOP_MUSIC;
				ret.LayerData = ParallaxDataTable.OUTDOORS;

				finalize(ret);

				return ret;
			}
		}

        public static RoomData BUFF_SHOP {
            get {
                var ret = new RoomData();
                ret.Id = 107;
                ret.TMXResource = "TMXData/Zone1/BuffShop.tmx";
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
				ret.Type = RoomType.Boss;
				ret.TMXResource = "TMXData/Zone1Boss/121.tmx";

				ret.LayerData = ParallaxDataTable.ABSTRACT;

				finalize(ret);

				return ret;
			}
		}


		static void finalize(RoomData room) {

			var tmx = TMXCache.Get(room);
			room.Width = tmx.Width - 1;
			room.Height = tmx.Height - 1;
			var expandedSize = new GridPoint(room.Width, room.Height).GridToWorldBL(tmx);
			room.WorldWidth = expandedSize.x;
			room.WorldHeight = expandedSize.y;

			room.HardGeoTileMap.AddData(tmx.Layers.First(l => l.Name == Constants.HardGeometryLayer), tmx.Width);

			addDoorsFromTMX (room, tmx);
			addSpawnsFromTMX (room);
			Debug.Log("finalizing room: " + room);

		}


		static void addSpawnsFromTMX (RoomData room)
		{
			var spawns = room.TmxMap.ObjectGroups.Where(p => p.Name == Constants.SpawnsLayer).FirstOrDefault();
			if(spawns != null) {
				foreach( var obj in spawns.Objects) {
					if( obj.Type != null ) {

						var charData = TMXObjectTypes.GetCharacterData(obj.Type, room);

						var spawn = new RoomData.Spawn(charData);

						var facing = obj.TryGetProperty(Constants.Facing);
						spawn.Facing = TMXUtils.FacingDirection(facing);
						var gridPos = GridPoint.FromTMXObject(obj, room.TmxMap);
						spawn.GridPosition = gridPos;

						room.Spawns.Add(spawn);
					} else {
						var id = int.Parse(obj.TryGetProperty(Constants.DataId));
						var spawn = new RoomData.Spawn(CharacterDataTable.FromId(id));
						spawn.GridPosition = GridPoint.FromTMXObject(obj, room.TmxMap);
						spawn.Facing = TMXUtils.FacingDirection(obj.TryGetProperty(Constants.Facing));
						room.Spawns.Add(spawn);
					}

				}
			}
		}

		static void addDoorsFromTMX (RoomData room, TiledSharp.TmxMap tmx)
		{
			var extractor = new TMXChunkExtractor(tmx);
			var matches = extractor.GetChunksOnLayer(Constants.DoorsLayer);

			foreach( var chunk in matches ) {
				var middleNode = chunk.FirstNode;
				var doorPos = new GridPoint(middleNode).GridToWorldBL(tmx);

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

