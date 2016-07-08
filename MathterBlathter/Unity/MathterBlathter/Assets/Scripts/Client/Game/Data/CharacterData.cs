using System;
using System.Collections.Generic;
using Client.Game.Data;
using Client.Game.Enums;
using UnityEngine;
using System.Linq;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public class CharacterData : GameData
	{
	
		public string Name;
		public string ResourcePath;
		public ActorType ActorType;

		public AIData AIData;
		public List<AttributeData> attributeData = new List<AttributeData>();
		public List<AttributeData> overrideAttributes = new List<AttributeData>();
		
		public Dictionary<AbilitySlots, PickupType> Abilities = new Dictionary<AbilitySlots, PickupType>();
		public int MinElevation;
		public int MaxElevation;
		//serialized attributes
		public Availability Availability;

		public char SpawnType;
		public int Cost;

		//pickup stuff
		public float Rarity = 0;
		public string Description;
		public PickupType PickupType;



		public void AddAbility(AbilityData ability) {
			AddIndexed(ability, ActorAttributes.Abilities);
		}

		public void AddIndexed(GameData data, GameAttributeI attr) {
			var numEntries = this.attributeData.Where( p => p.Id == attr.Id).Count();
			this.attributeData.Add(new CharacterData.AttributeData(attr.Id, data.Id, numEntries));
		}
	}

	[FlagsAttribute]
	public enum Availability : short {
		None = 0,
		Droppable = 1,
		InShop = 2,
		CursedShop = 4,
		RoomClearReward = 8,
	}

	public enum PickupType {
		Unassigned,
		Weapon,
		Buff,
		Item,
		ActiveItem
	}

	public enum ActorType {
		Friendly,
		Player,
		Enemy,
		Door,
		Projectile,
		Pickup,
		Weapon,
		Fixture,
		ActiveItem,
	}

}

