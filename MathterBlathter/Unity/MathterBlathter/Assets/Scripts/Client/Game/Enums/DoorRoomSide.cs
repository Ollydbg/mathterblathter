using System;

namespace Client.Game.Enums
{
	public enum DoorRoomSide {
		Top,
		Bottom,
		Left,
		Right
	}

	public static class DoorRoom {
		public static DoorRoomSide Opposite(DoorRoomSide side) {
			switch (side) {
			case DoorRoomSide.Bottom:
				return DoorRoomSide.Top;
			case DoorRoomSide.Left:
				return DoorRoomSide.Right;
			case DoorRoomSide.Right:
				return DoorRoomSide.Left;
			case DoorRoomSide.Top:
				return DoorRoomSide.Bottom;
			}
			return default(DoorRoomSide); 
		}
	}

}

