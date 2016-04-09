using System;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.Data
{
	public class CharacterData : GameData
	{
	
		public string Name;
		public string ResourceName;
		public ActorType ActorType;

		//serialized attributes

	}

	public enum ActorType {
		Player,
		Enemy,
		Boss,
	}

}

