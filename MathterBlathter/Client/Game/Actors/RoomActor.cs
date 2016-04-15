using System;
using System.Collections.Generic;
using Client.Game.Map;
using Client.Game.Data;
using System.Linq;

namespace Client.Game.Actors
{
	public class RoomActor : Actor
	{
		
		public RoomActor ()
		{
		}

		#region implemented abstract members of Actor

		public override ActorType ActorType {
			get {
				return ActorType.Room;
			}
		}

		#endregion

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

