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
			generator = new MapGenerator();
		}


		int numRoomsToGenerate() {
			var solod = RoomDataTable.GetAll().Count(p => p.Solo);
			return solod > 0 ? solod : MapDataTable.Map1.NumberOfRooms;
		}

		List<RoomData> availableRooms() {
			var solod = RoomDataTable.GetAll().Where( p=> p.Solo).ToList();
			if(solod.Count > 0) {
				return solod;
			} else {
				return RoomDataTable.GetAll().Where( p=>!p.Mute).ToList();
			}
		}

		public override void Enter ()
		{
			generator.InitPool(availableRooms(), numRoomsToGenerate());
		}

		public override void Exit ()
		{
			Game.Instance.RoomManager.SetRooms(Rooms);
		}

		private int generationsPerFrame = 10;

		public override void Update (float dt)
		{
				int i = generationsPerFrame;
				while(i-- > 0) {
					if(!generator.IsComplete) {
						Rooms.AddRange(generator.Emit());
					} else {
						generator.SealDoors();
						Change<RunState>();
						break;
					}
				}

				
		}

	}

}

