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

		public Dictionary<AbilitySlots, Type> Abilities = new Dictionary<AbilitySlots, Type>();
		//serialized attributes

	}
	

	public enum ActorType {
		Friendly,
		Player,
		Enemy,
		Door,
		Projectile,
		Pickup,
		Weapon,
		Fixture
	}

}

