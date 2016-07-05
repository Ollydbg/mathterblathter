using System;
using Client.Game.Pathfinding;
using Client.Game.Map;
using UnityEngine;

namespace Client.Game.Data.Ascii
{
	public static class AsciiUtils
	{
		public static Vector3 AsciiToWorld(GridPos pos, Room room) {
			return new Vector3(
				pos.x + room.X,
				room.Height - 1 - pos.y + room.Y
			);
		}


		public static GridPos WorldToAscii(Room room) {

			return new GridPos(
				(int)room.X,
				0
			);


		}

		public static GridPos WorldToAscii(Vector3 worldPos, Room room) {
			return new GridPos(
				(int)(worldPos.x - room.X),
				-((int)worldPos.y - room.Y - room.Height + 1)
			);
		}

	}
}

