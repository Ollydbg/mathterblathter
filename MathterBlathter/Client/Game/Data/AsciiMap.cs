using System;
using System.Collections.Generic;

namespace Client.Game.Map
{
	public class AsciiMap
	{

		public const char WALL = 'w';
		public const char FLOOR = 'f';
		public const char PLATFORM = 'p';
		public const char SPIKES = 's';
		public const char RAMP = '/';
		public const char DOOR = 'd';

		public AsciiMap ()
		{


		}


		public List<string> columns = new List<string> ();
		public List<string> rows = new List<string>();


		public int Height {
			get {
				return rows.Count;
			}
		}

		public int Width {
			get {
				return rows[0].Length;
			}
		}

		public char this[int x, int y] {
			get {
				return rows [y] [x];
			}
		}


		public static AsciiMap operator +(AsciiMap map, string row) {
			if (map.rows.Count > 0) {
				if (row.Length != map.rows [0].Length) {
					throw new Exception (String.Format("row not the same length, expected {0}", map.rows[0].Length));
				}
			}
			map.rows.Add(row);
			return map;
		}
	}
}

