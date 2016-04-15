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
			_all.Add(TALL_ROOM);
			_all.Add(ROOM_RAMP_TEST);
			_all.Add(ROOM_1);
			_all.Add(ROOM_2);

		}

		public static RoomData ROOM_RAMP_TEST {
			get {
				var ret = new RoomData ();
				ret.Id = 1;

				ret.AsciiMap += "ccccccccccc d ccccccccccccccc";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "                            w";
				ret.AsciiMap += "d                           w";
				ret.AsciiMap += "                            w";
				ret.AsciiMap += "wppppp                      w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w     1                     w";
				ret.AsciiMap += "w                            ";
				ret.AsciiMap += "w                           d";
				ret.AsciiMap += "w                            ";
				ret.AsciiMap += "w                       ppppw";
				ret.AsciiMap += "w                       f   w";
				ret.AsciiMap += "w                   ppppp   w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "w                           w";
				ret.AsciiMap += "           pppppppppp        ";
				ret.AsciiMap += "d         fffffffffff       d";
				ret.AsciiMap += "         pppppppppppp        ";
				ret.AsciiMap += "fffffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (MockActorData.ENEMY_TEST));
				addDoorsFromAscii (ret);
				//AddDoors (ret);
				return ret;
			}
		}



		public static RoomData TALL_ROOM {
			get {
				var ret = new RoomData ();
				ret.Id = 1;

				ret.AsciiMap += "ccccccccccccccc d ccccccccccccccccccc";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w             fff                   w";
				ret.AsciiMap += "w             pppppppp              w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                              1    w";
				ret.AsciiMap += "w                        pppppppppp w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w            ppppppppppp            w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wpppppppppp                         w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w         pppppppppppppppppp        w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "                                     ";
				ret.AsciiMap += "d                                   d";
				ret.AsciiMap += "                                     ";
				ret.AsciiMap += "wpppppppp                   ppppppppw";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w     1                             w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wp                                  w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wppp                                w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "w                                   w";
				ret.AsciiMap += "wppppppppppppppppppppppp            w";
				ret.AsciiMap += "                                    w";
				ret.AsciiMap += "d                                   w";
				ret.AsciiMap += "                                    w";
				ret.AsciiMap += "fffffffffffffffffffffffffffff d fffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (MockActorData.ENEMY_TEST));
				addDoorsFromAscii (ret);
				//AddDoors (ret);
				return ret;
			}
		}


		public static RoomData ROOM_VERT_TEST {
			get {
				var ret = new RoomData ();
				ret.Id = 1;

				ret.AsciiMap += "ccccccccccccccccc d cccccccccccccccccc";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                   1                 ";
				ret.AsciiMap += "w                                    d";
				ret.AsciiMap += "w                                     ";
				ret.AsciiMap += "w                              ppppppw";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                     pppp            ";
				ret.AsciiMap += "w                                    d";
				ret.AsciiMap += "w                                     ";
				ret.AsciiMap += "w      ppppppp                   ffffw";
				ret.AsciiMap += "w     ffffffffff                 ffffw";
				ret.AsciiMap += "w    pppppppppppppppp            ffffw";
				ret.AsciiMap += "ffffffffffffffffffffffffff d fffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (MockActorData.ENEMY_TEST));
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
				ret.AsciiMap += "w    1                                        w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                              ";
				ret.AsciiMap += "w                                             d";
				ret.AsciiMap += "w                                              ";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "                        ppppp                  ";
				ret.AsciiMap += "d                       fffff                 d";
				ret.AsciiMap += "               pppppppppppppp                  ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff d ffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (MockActorData.ENEMY_TEST));
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
				ret.AsciiMap += "w                                   1         w";
				ret.AsciiMap += "w                                             w";
				ret.AsciiMap += "                                              w";
				ret.AsciiMap += "d                                             w";
				ret.AsciiMap += "                                              w";
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
				ret.Spawns.Add (new RoomData.Spawn (MockActorData.ENEMY_TEST));
				addDoorsFromAscii (ret);
				return ret;
			}
		}



		static void addDoorsFromAscii (RoomData room)
		{
			//this really needs a floodfill instead
			var extractor = new AsciiMeshExtractor (room.AsciiMap);
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

