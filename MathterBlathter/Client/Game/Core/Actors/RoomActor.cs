using System;
using System.Collections.Generic;
using Client.Game.Map;
using Client.Game.Data;
using System.Linq;

namespace Client.Game.Core.Actors
{
	public class RoomActor : Actor
	{
		
		public RoomActor ()
		{
		}

		public int X;
		public int Y;
		public int Width;
		public int Height;

		public List<DoorActor> Doors;
		public interface IRoomDrawer {
			void Draw (RoomActor room);
		}



	}
}

