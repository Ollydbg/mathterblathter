using System;
using Client.Game.Data;

namespace Client.Game.Map.GenConstraints
{
	//makes sure there's a store every 100 ft
	public class StorePerTierConstraint : IGenConstraint
	{
		public StorePerTierConstraint ()
		{
		}

		#region GenConstraint implementation

		public void InitWithMap (MapData mapData)
		{
			
		}

		public bool Check (RoomData data, int x, int y, int width, int height)
		{
			return true;
		}

		public void Commit (RoomData data, int x, int y, int width, int height)
		{
			
		}

		#endregion
	}
}

