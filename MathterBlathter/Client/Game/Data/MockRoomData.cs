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
			_all.Add(ROOM_1);
			_all.Add(ROOM_2);
			//_all.Add(ROOM_3);
			//_all.Add(ROOM_4);
			//_all.Add(ROOM_5);
		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();


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
				ret.AsciiMap += "ppp                                         ppp";
				ret.AsciiMap += "d                                             d";
				ret.AsciiMap += "                        fffff                  ";
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

				ret.AsciiMap += "ccccccccccccccccccccccccccccccccccccccccccccccc";
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
				ret.AsciiMap += "ppp                                         ppp";
				ret.AsciiMap += "d                                             d";
				ret.AsciiMap += "                                               ";
				ret.AsciiMap += "                                               ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff d ffffffffff";
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
				link.Height = 4;
				link.Width = 1;
				link.X = (int)doorPos.x;
				link.Y = (int)doorPos.y;

				if (link.X == 0) {
					link.Side = DoorRoomSide.Left;
				} else if (link.Y == 1) {
					link.Side = DoorRoomSide.Bottom;
				} else if (link.X == room.Width-1) {
					link.Side = DoorRoomSide.Right;
				} else {

					link.Side = DoorRoomSide.Top;
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

