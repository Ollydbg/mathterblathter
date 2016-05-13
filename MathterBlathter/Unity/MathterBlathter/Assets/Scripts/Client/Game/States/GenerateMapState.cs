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
		List<Room> Rooms;

		public GenerateMapState ()
		{
			generator = new MapGenerator();
		}


		int numRoomsToGenerate() {
			var solod = MockRoomData.GetAll().Count(p => p.Solo);
			return solod > 0 ? solod : MockMapData.Map1.NumberOfRooms;
		}

		List<RoomData> availableRooms() {
			var solod = MockRoomData.GetAll().Where( p=> p.Solo).ToList();
			if(solod.Count > 0) {
				return solod;
			} else {
				return MockRoomData.GetAll().Where( p=>!p.Mute).ToList();
			}
		}

		public override void Enter ()
		{
			
		}

		public override void Exit ()
		{
			Game.Instance.RoomManager.SetRooms(Rooms);
		}

		//TODO: Refactor MapGenerator to yield rooms so this doesn't need to be so dumb
		float warmup = .1f;
		public override void Update (float dt)
		{
			warmup -= dt;
			if(warmup <= 0f) {
				Rooms = generator.GenerateFromDataSet(availableRooms(), numRoomsToGenerate());
				Change<RunState>();

			}

		}

	}

}

