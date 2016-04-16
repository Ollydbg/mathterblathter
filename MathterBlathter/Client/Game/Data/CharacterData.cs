using System;
using System.Collections.Generic;
using Client.Game.Data;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public class CharacterData : GameData
	{
	
		public string Name;
		public string ResourcePath;
		public ActorType ActorType;
		public AIData AIData;
		public List<AttributeData> attributeData = new List<AttributeData>();

		public Dictionary<AbilityType, Type> Abilities = new Dictionary<AbilityType, Type>();
		//serialized attributes


	}

	public enum ActorType {
		Friendly,
		ShopKeeper,
		Player,
		Enemy,
		Door,
		Boss,
		Room,
		Projectile,
	}

}

