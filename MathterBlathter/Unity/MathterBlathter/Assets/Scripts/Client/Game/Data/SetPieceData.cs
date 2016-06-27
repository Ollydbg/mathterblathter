using System;

namespace Client.Game.Data
{
	public class SetPieceData : GameData
	{
		public SetPieceData ()
		{
		}

		public string PrefabPath;
	}

	
	public static partial class SetPieceDataTable {
		public static SetPieceData INTRO {
			get {
				var ret = new SetPieceData();
				ret.Id = 70000;
				ret.PrefabPath = "SetPieces/BrokenSkyline_prefab";

				return ret;
			}
		}
	}
}

