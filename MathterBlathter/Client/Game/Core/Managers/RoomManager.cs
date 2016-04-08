using System;
using Client.Game.Data;
using Client.Game.Map;

namespace Client.Game.Core.Managers
{
	public class RoomManager : IGameManager
	{
		
		public RoomManager ()
		{
			
		}


		public void Init ()
		{
			//make rooms
			var mockedRooms = new DataMocker().Mock(1);
			var generator = new MapGenerator ();
			generator.GenerateFromDataSet (mockedRooms);
		}

		public void Update (float dt)
		{
			
		}

	}
}

