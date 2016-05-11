using System;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Data.Ascii
{
	public class AsciiVector
	{
		public int x;
		public int y;

		public AsciiVector ()
		{
		}

		public AsciiVector (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static Vector3 WorldToAscii(AsciiVector vect, AsciiMap fromMap) {
			return new Vector3(vect.x, fromMap.Height - vect.y - 1);
		}
	}
}

