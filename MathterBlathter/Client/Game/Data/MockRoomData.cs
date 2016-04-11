using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public class MockRoomData
	{


		static MockRoomData() {
			_all = new List<RoomData>();
			_all.Add(ROOM_1);
			_all.Add(ROOM_2);
			_all.Add(ROOM_3);
			_all.Add(ROOM_4);
			_all.Add(ROOM_5);
		}


		public static RoomData ROOM_1 {
			get {
				var ret = new RoomData ();


				ret.AsciiMap += "pppppppppppppppppppppppppppppppppp";
				ret.AsciiMap += "                                  ";
				ret.AsciiMap += "                                  ";
				ret.AsciiMap += "ppp                            ppp";
				ret.AsciiMap += "                                  ";
				ret.AsciiMap += "                                  ";
				ret.AsciiMap += "                            ffffff";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				AddDoors (ret);
				return ret;
			}
		}

		public static RoomData ROOM_2 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "wppppppppppppppp ppppppppw";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "wpp                    ppw";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w           ffffff        ";
				ret.AsciiMap += "         fffffffff        ";
				ret.AsciiMap += "ffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				AddDoors (ret);
				return ret;
			}
		}


		public static RoomData ROOM_3 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "wppppppppppppppp ppppppppw";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "wpp                    ppw";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "w                        w";
				ret.AsciiMap += "ffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				AddDoors (ret);
				return ret;
			}
		}

		public static RoomData ROOM_4 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "wppppppppppppppp             ppppppppw";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "wpp                                ppw";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                     ";
				ret.AsciiMap += "                                      ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				AddDoors (ret);
				return ret;
			}
		}


		public static RoomData ROOM_5 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "wppppppppppppppp             ppppppppw";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "wpp                                ppw";
				ret.AsciiMap += "w                                    w";
				ret.AsciiMap += "w                                     ";
				ret.AsciiMap += "                                      ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffffffffff";
				ret.Width = ret.AsciiMap.Width;
				ret.Height = ret.AsciiMap.Height;
				ret.Spawns.Add (new RoomData.Spawn (ActorDataMocker.ENEMY_TEST));
				AddDoors (ret);
				return ret;
			}
		}

		public static void AddDoors(RoomData data) {
			while (data.Doors.Count == 0) {
				if (Maybe ())
					AddTopAndBottomDoors (data);
				if (Maybe ())
					AddLeftAndRightDoors (data);
			}

		}

		private static Boolean Maybe() {
			return UnityEngine.Random.Range (0, 2) == 1;
		}

		public static void AddTopAndBottomDoors(RoomData room) {
			var top = new RoomData.Link ();
			top.X = 0;
			top.Y = (int)(room.Height * .5);
			top.Width = 1;
			top.Height = 4;
			top.Side = DoorRoomSide.Top;

			var bottom = new RoomData.Link ();
			bottom.X = 0;
			bottom.Y = (int)(room.Height*-.5);
			bottom.Width = 1;
			bottom.Height = 4;
			bottom.Side = DoorRoomSide.Bottom;

			room.Doors.Add (top);
			room.Doors.Add (bottom);
		}

		public static void AddLeftAndRightDoors(RoomData room) {
			var left = new RoomData.Link ();
			left.X = (int)(room.Width * -.5);
			left.Y = 0;
			left.Width = 1;
			left.Height = 4;
			left.Side = DoorRoomSide.Left;

			var right = new RoomData.Link ();
			right.X = (int)(room.Width * .5);
			right.Y = 0;
			right.Width = 1;
			right.Height = 4;
			right.Side = DoorRoomSide.Right;

			room.Doors.Add (left);
			room.Doors.Add (right);

		}

		private static List<RoomData> _all;
		public static List<RoomData> GetAll() {
			return _all;
		}

	}
}

