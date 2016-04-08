using System;
using System.Collections.Generic;
using Client.Game.Map;
using Client.Game.Data;
using Client.Game.Core.Actors;

namespace Client.Game.Data
{
	public class RoomData : GameData
	{

		public int Width;
		public int Height;
		public List<Door> Doors = new List<Door>();

		public class Link
		{
			public int X;
			public int Y;
			public int Width;
			public int Height;
			public DoorActor.RoomSide Side;

			public Link(Link other) {
				this.X = other.X;
				this.Y = other.Y;
				this.Width = other.Width;
				this.Height = other.Height;
				this.Side = other.Side;
			}

			public Link Clone() {
				return new Link (this);
			}
		}

		public RoomData ()
		{
		}

	}
}

