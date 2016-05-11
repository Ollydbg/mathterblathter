using System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game.Data.Ascii
{
	public class AsciiLookup : Dictionary<char, AsciiPlacement>
	{
		public AsciiLookup ()
		{
		}
	}

	public class AsciiPlacement {
		public CharacterData Data;
		public Vector3 Facing;

		public AsciiPlacement(CharacterData data, Vector3 facing) {
			this.Data = data;
			this.Facing = facing;
		}

		public static implicit operator AsciiPlacement(CharacterData data) {
			return new AsciiPlacement(data, Vector3.zero);
		}
	}

}

