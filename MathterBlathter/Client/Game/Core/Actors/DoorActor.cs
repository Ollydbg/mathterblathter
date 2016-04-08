using System;
using Client.Game.Map;
using Client.Game.Data;
using Client.Game.Core.Enums;

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

		public Room Parent;
		public DoorRoomSide Side;

		public Guid SelfGuid;
		public Guid LinkedGuid;

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

		/*
		public DoorActor(DoorActor other) {
			
			this.X = other.X;
			this.Y = other.Y;
			this.Width = other.Width;
			this.Height = other.Height;
			this.Side = other.Side;
		}*/

		public void InitWithData(RoomData.Link link) {
			this.Width = link.Width;
			this.Height = link.Height;
			this.X = link.X;
			this.Y = link.Y;
			this.SelfGuid = link.Id;
		}


	}
}

