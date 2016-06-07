using System;
using System.Collections.Generic;
using Client.Game.Data;
using Client.Game.Enums;
using UnityEngine;

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
		public int MinElevation;
		public int MaxElevation;
		//serialized attributes
		public Availability Availability;
		
		public int Cost;

	}


	[FlagsAttribute]
	public enum Availability : short {
		None = 0,
		Droppable = 1,
		InShop = 2,
		CursedShop = 3
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

