using System;
using System.Collections.Generic;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public class AbilityData : GameData
	{
		public string name;
		public List<AttributeData> attributeData = new List<AttributeData>();
		public string animation;
		public Type executionScript;
		public int spawnableDataId;
		public AbilityType AbilityType;

		public AbilityData ()
		{
		}


	}
}

