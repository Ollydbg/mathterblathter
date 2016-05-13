﻿using System;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public class PickupData : CharacterData {
		public float Rarity = 0;
		public Type PickupType;
		public enum Type {
			Unassigned,
			Weapon,
			Buff,
			Item
		}
	}

	public static partial class MockActorData
	{
		private static int OFFSET = 256;

		public static PickupData RANDOM_WEAPON_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 1;
				ret.PickupType = PickupData.Type.Weapon;
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add( new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id,
					MockAbilityData.LEVEL_APPROPRIATE_WEAPON.Id,
					0
				));
				ret.Name = "RandomWeapon";

				return ret;
			}
		}

		public static PickupData MAX_HEALTH_BOOST {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 2;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupData.Type.Item;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.STAT_UP.Id,
					0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Health.Id,
					1
				));
				ret.Name = "Blood Thinner";
				return ret;
			}
		}

		public static PickupData MOVE_BOOST_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 3;

				ret.PickupType = PickupData.Type.Buff;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.MOVE_BOOST_TEMP.Id,
					0
				));
				ret.Name = "Blood Pump";
				return ret;
			}
		}

		public static PickupData HEALTH_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 4;

				ret.PickupType = PickupData.Type.Item;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.HEAL.Id,
					0
				));
				ret.Name = "Blood Pack";
				return ret;
			}
		}

		public static PickupData SHORTENED_TENDONS_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 5;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.ActorType = ActorType.Pickup;

				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.JUMP_BUFF_PERM.Id,
					0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FALL_DAMAGE_PERM.Id,
					1
				));

				//better jumps, but takes a little damage on falling from heights
				ret.Name = "Shortened Achilles Tendon";

				return ret;
			}
		}

		public static PickupData RABBITS_FOOT {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 6;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.ActorType = ActorType.Pickup;

				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.RABBITS_FOOT_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropQuality.Id,
					.5f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id,
					0f
				));

				ret.Name = "Rabbit's Foot";

				return ret;
			}
		}


		public static PickupData CURSED_RABBITS_FOOT {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 7;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.RABBITS_FOOT_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropQuality.Id,
					.75f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id,
					-.1f
				));

				ret.Name = "Cursed Rabbit's Foot";

				return ret;
			}
		}

		public static PickupData RANDOM_BUFF {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 8;
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.LEVEL_APPROPRIATE_BUFF.Id,
					0
				));

				return ret;
			}
		}

	}
}
