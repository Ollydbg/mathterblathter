using System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game.Map.Ascii
{
	public class Chunk : List<Vector3>
	{
		public Chunk ()
		{
		}

		public Chunk (IEnumerable<Vector3> enumerable)
		{
			this.AddRange(enumerable);
		}
	}
}

