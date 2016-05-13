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
			public AttributeData(int id, float valueF, int index){ this.Id = id; this.ValueF = valueF; this.Index = index;}
			public AttributeData(int id, float valueF){ this.Id = id; this.ValueF = valueF; this.Index = -1;}
			public AttributeData(int id, int valueI, int index){ this.Id = id; this.ValueI = valueI; this.Index = index;}
			public AttributeData(int id, int valueI){ this.Id = id; this.ValueI = valueI; this.Index = -1;}

		}

		
	}
}

