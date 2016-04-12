using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Map.Ascii;
using Client.Game.Map;
using UnityEngine;

namespace Client.Game.Data
{
	public class MockRoomData
	{


		static MockRoomData() {
			_all = new List<RoomData>();
			_all.Add(ROOM_VERT_TEST);
			_all.Add(ROOM_1);
			_all.Add(ROOM_HOR_TEST);
			_all.Add(ROOM_2);
			_all.Add(ROOM_3);

		}


		public static RoomData ROOM_HOR_TEST {
			get {
				var ret = new RoomData ();
				ret.Id = 1;

				ret.AsciiMap += "cccccccccccccccccccc";
				ret.AsciiMap += "w                   ";
				ret.AsciiMap += "w                  d";
				ret.AsciiMap += "w                   ";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "                   w";
				ret.AsciiMap += "d                  w";
				ret.AsciiMap += "                   w";
				ret.AsciiMap += "ffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				addDoorsFromAscii (ret);
				//AddDoors (ret);
				return ret;
			}
		}

		public static RoomData ROOM_VERT_TEST {
			get {
				var ret = new RoomData ();
				ret.Id = 1;

				ret.AsciiMap += "cccccccc d ccccccccc";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                   ";
				ret.AsciiMap += "w                  d";
				ret.AsciiMap += "w                   ";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w                  w";
				ret.AsciiMap += "w         ff       w";
				ret.AsciiMap += "w         ff       w";
				ret.AsciiMap += "w         ff       w";
				ret.AsciiMap += "w       ffff       w";
				ret.AsciiMap += "ffffffffffffff d fff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				addDoorsFromAscii (ret);
				//AddDoors (ret);
				return ret;
			}
		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();
				ret.Id = 1;

				ret.AsciiMap += "cccccccccccccccccccccc d cccccccccccccccccccccc";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "                        fffff                  ";
				ret.AsciiMap += "d                       fffff                 d";
				ret.AsciiMap += "                fffffffffffff                  ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff d ffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				addDoorsFromAscii (ret);
				//AddDoors (ret);
				return ret;
			}
		}

		public static RoomData ROOM_2 {
			get {
				var ret = new RoomData ();
				ret.Id = 2;
				ret.AsciiMap += "ccccccccccc d ccccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "wpp                                         ppw";
				ret.AsciiMap += "                                               ";
				ret.AsciiMap += "d                                             d";
				ret.AsciiMap += "                                               ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff d ffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				addDoorsFromAscii (ret);
				return ret;
			}
		}


		public static RoomData ROOM_3 {
			get {
				var ret = new RoomData ();
				ret.Id = 3;
				ret.AsciiMap += "ccccccccccc d ccccccccc";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "w                     w";
				ret.AsciiMap += "wppppppp              w";
				ret.AsciiMap += "                      w";
				ret.AsciiMap += "d                     w";
				ret.AsciiMap += "                      w";
				ret.AsciiMap += "fffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				addDoorsFromAscii (ret);
				return ret;
			}
		}


		static void addDoorsFromAscii (RoomData room)
		{
			//this really needs a floodfill instead
			var extractor = new AsciiMapExtractor (room.AsciiMap);
			var matches = extractor.getAllMatching (AsciiMap.DOOR);
			foreach (Vector3 doorPos in matches) {
				var link = new RoomData.Link ();
				link.Height = 1;
				link.Width = 1;
				link.X = (int)doorPos.x;
				link.Y = (int)doorPos.y;

				if (link.X == 0) {
					link.Side = DoorRoomSide.Left;
					link.Width = 1;
					link.Height = 3;
				} else if (link.Y == 0) {
					link.Side = DoorRoomSide.Bottom;
					link.Width = 3;
					link.Height = 1;
				} else if (link.X == room.Width-1) {
					link.Side = DoorRoomSide.Right;
					link.Width = 1;
					link.Height = 3;
				} else {

					link.Side = DoorRoomSide.Top;
					link.Width = 3;
					link.Height = 1;
				}

				room.Doors.Add (link);

			
			}
		}


		private static List<RoomData> _all;
		public static List<RoomData> GetAll() {
			return _all;
		}

	}
}

