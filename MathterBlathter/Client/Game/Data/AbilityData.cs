using System;
using System.Collections.Generic;

namespace Client.Game.Data
{
	public class AbilityData : GameData
	{
		public string name;
		public List<AttributeData> attributeData = new List<AttributeData>();
		public string animation;
		public Type executionScript;
		public string spawnableResourcePath;

		public AbilityData ()
		{
		}


	}
}

