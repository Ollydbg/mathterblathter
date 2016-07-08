using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using Client.Game.Map;
using System.Threading;
using UnityEngine;

namespace Client.Game.States
{
	using Game = Client.Game.Core.Game;

	public class GenerateMapState : State
	{
		private MapGenerator generator;
		List<Room> Rooms = new List<Room>();

		public GenerateMapState ()
		{
			generator = new MapGenerator(MapDataTable.Map1);
		}


		public override void Enter ()
		{
			
		}

		public override void Exit ()
		{
			Game.Instance.RoomManager.SetRooms(Rooms);
		}

		private int generationsPerFrame = 15;

		public override void Update (float dt)
		{
			int i = generationsPerFrame;
			while(i-- > 0) {
				if(!generator.IsComplete) {
					var room = generator.Emit();
					if( room != null )
						Rooms.Add(room);
					
				} else {
					Change<RunState>();
					break;
				}
			}

				
		}

	}

}

