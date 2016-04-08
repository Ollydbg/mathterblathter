using System;
using System.Collections.Generic;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Core;
using Client.Game.Core.Actors;

namespace Client.Game.Map
{
	public class Room
	{


		public int X;
		public int Y;
		public int Width;
		public int Height;

		public List<DoorActor> Doors = new List<DoorActor>();
		public interface IRoomDrawer {
			void Draw (Room room);
		}

		private static IRoomDrawer DebugDrawer = new DebugRoomDrawer();
		private static IRoomDrawer PolyDrawer = new PolyRoomDrawer();

		public float Left { 
			get {
				return (float)(X - .5*Width);
			}
		}

		public float Right {
			get {
				return (float)(X + .5 * Width);
			}
		}

		public float Top {
			get {
				return (float)(Y + .5 * Height);
			}
		}

		public float Bottom {
			get {
				return (float)(Y - .5 * Height);
			}
		}


		public Room (RoomData data)
		{
			initFromData (data);
		}


		public void initFromData (RoomData data)
		{
			this.Width = data.Width;
			this.Height = data.Height;


		}

		public void EnterGame(Game.Core.Game game) { 
			
		}

		public void Draw() {
			PolyDrawer.Draw (this);
		}

	}
}

