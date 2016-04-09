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

		//serialized attributes

	}

	public enum ActorType {
		Player,
		Enemy,
		Boss,
	}

}

