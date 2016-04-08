using System;

namespace Client.Game.Core.Actors
{
	public class DoorActor : Actor
	{
		public DoorActor ()
		{
		}

		public int X;
		public int Y;
		public int Width;
		public int Height;

		public RoomActor Parent;
		public RoomActor Linked;
		public RoomSide Side;

		public float WorldX {
			get {
				return Parent.X + this.X;
			}
		}

		public float WorldY {
			get {
				return Parent.Y + this.Y;
			}
		}


		public DoorActor(DoorActor other) {
			this.X = other.X;
			this.Y = other.Y;
			this.Width = other.Width;
			this.Height = other.Height;
			this.Side = other.Side;
		}

		public DoorActor Clone() {
			return new DoorActor (this);
		}

		public enum RoomSide {
			Top,
			Bottom,
			Left,
			Right
		}
	}
}

