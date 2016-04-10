using System;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.Data
{
	public class CharacterData : GameData
	{
	
		public string Name;
		public string ResourcePath;
		public ActorType ActorType;
		public AIData AIData;
		public List<AttributeData> attributeData = new List<AttributeData>();

		//serialized attributes


	}

	public enum ActorType {
		Player,
		Enemy,
		Boss,
	}

}

