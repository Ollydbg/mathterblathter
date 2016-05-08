using System;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class MockActorData
	{
		private static int OFFSET = 256;

		public static CharacterData RANDOM_WEAPON_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 1;
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

		public static CharacterData MAX_HEALTH_BOOST {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 2;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.STAT_UP.Id,
					0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					10
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Health.Id,
					10
				));
				ret.Name = "Iron Lungs";
				return ret;
			}
		}

		public static CharacterData MOVE_BOOST_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 3;
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

		public static CharacterData HEALTH_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 4;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.HEAL.Id,
					0
				));
				ret.Name = "HealthPickup";
				return ret;
			}
		}

		public static CharacterData SHORTENED_TENDONS_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 5;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.ActorType = ActorType.Pickup;
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
				ret.Name = "Shorter Tendons";

				return ret;
			}
		}

		public static CharacterData RABBITS_FOOT {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 6;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.ActorType = ActorType.Pickup;

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


		public static CharacterData CURSED_RABBITS_FOOT {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 7;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.ActorType = ActorType.Pickup;

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

	}
}

