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
				ret.AsciiMap += "                                ";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "                                ";
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
				ret.AsciiMap += "                                ";
				ret.AsciiMap += "d                              d";
				ret.AsciiMap += "                                ";
				ret.AsciiMap += "ffffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;

			}

		}

		public static RoomData ROOM_64x37 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
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
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d ffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_128x37 {
			get {
				var ret = new RoomData ();

				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccc d ccccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                                                                                 ";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "                                                                                                                                 ";
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
				ret.AsciiMap += "                                                                                                                                 ";
				ret.AsciiMap += "d                                                                                                                               d";
				ret.AsciiMap += "                                                                                                                                 ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d fffffffffffffffffffffffffffff d fffffffffffffffffffffffffffff d fffffffffffffffffffffffffffffff";

				finalize(ret);

				return ret;
			}
		}

		public static RoomData ROOM_64x69 {
			get {
				var ret = new RoomData();

				ret.AsciiMap += "ccccccccccccccccccccccccccccccc d cccccccccccccccccccccccccccccc";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
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
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
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
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "d                                                              d";
				ret.AsciiMap += "                                                                ";
				ret.AsciiMap += "fffffffffffffffffffffffffffffff d fffffffffffffffffffffffffffffw";

				finalize(ret);

				return ret;
			}
		}

		private static void finalize(RoomData data) {}
	}

}

