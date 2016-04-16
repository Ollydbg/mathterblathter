using System;

namespace Client.Game.Data
{
	public class GameData
	{
		public int Id;

		public GameData ()
		{
		}

		public class AttributeData
		{
			public int Id;
			public float ValueF;
			public int ValueI;
			public int Index;
			public AttributeData(int id, float valueF, int index = -1){ this.Id = id; this.ValueF = valueF; this.Index = index;}
			public AttributeData(int id, int valueI, int index = -1){ this.Id = id; this.ValueI = valueI; this.Index = index;}

		}
	}
}

