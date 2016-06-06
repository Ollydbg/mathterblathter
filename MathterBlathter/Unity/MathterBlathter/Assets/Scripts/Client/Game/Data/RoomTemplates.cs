using System;
using System.Runtime.InteropServices;
using Client.Game.Data;
using UnityEngine.Assertions;

namespace Client
{
	public class RoomTemplates
	{

		public static RoomData Room_32x37
		{
			get {
				var ret = new RoomData();

				ret.AsciiMap += "cccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "w                              w";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;

			}

		}

		public static RoomData ROOM_64x37 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_128x37 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccdddccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "w                                                                                                                               w";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_64x69 {
			get {
				var ret = new RoomData();

				ret.AsciiMap += "cccccccccccccccccccccccccccccccdddcccccccccccccccccccccccccccccc";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "w                                                              w";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "fffffffffffffffffffffffffffffffdddfffffffffffffffffffffffffffffw";

				finalize(ret);

				return ret;
			}
		}

		private static void finalize(RoomData data) {}
	}

}

