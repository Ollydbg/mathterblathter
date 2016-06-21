using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{
        public static CharacterData AOE_FREEZE_ITEM {
            get {
				var ret = new CharacterData();
                ret.Id = 3000;
				ret.Availability = Availability.None;
				ret.ActorType = ActorType.ActiveItem;
				ret.PickupType = PickupType.ActiveItem;
				ret.Name = "Freeze";
				
                return ret;
            }
        }

        public static CharacterData WEAPON_POISONER_ITEM {
            get {
				var ret = new CharacterData();
				ret.Id = 3001;
				ret.ActorType = ActorType.ActiveItem;
				ret.PickupType = PickupType.ActiveItem;

                ret.Availability = Availability.None;
                return ret;
            }
        }

        public static CharacterData TRAP_MALFUNCTIONER_ITEM {
            get {
				var ret = new CharacterData();
				ret.Id = 3002;
				ret.ActorType = ActorType.ActiveItem;
				ret.PickupType = PickupType.ActiveItem;

                ret.Availability = Availability.None;
                return ret;
            }
        }
        public static CharacterData WEAPON_THROWER_ITEM {
            get {
				var ret = new CharacterData();
                ret.Id = 3003;

				ret.ActorType = ActorType.ActiveItem;
				ret.PickupType = PickupType.ActiveItem;

                ret.Availability = Availability.None;
                return ret;
            }
        }


        public static CharacterData ANXIETY_DAMAGE_AOE_ITEM {
            get {
				var ret = new CharacterData();
                ret.Id = 3004;
				ret.ActorType = ActorType.ActiveItem;
				ret.PickupType = PickupType.ActiveItem;
				ret.Availability = Availability.InShop;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.ANXIETY_DAMAGE_ITEM.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Cooldown.Id,
					60f
				));
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.Name = "OverSharer";
                return ret;
            }
        }

		public static CharacterData RAGE_MACHINE_ITEM {
			get {
				var ret = new CharacterData();
				ret.Id = 3005;
				ret.ActorType = ActorType.ActiveItem;
				ret.PickupType = PickupType.ActiveItem;
				ret.Availability = Availability.InShop;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.NO_ANXIETY_FIRE_SPEED_BUFF.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Cooldown.Id,
					60f
				));

				ret.overrideAttributes.Add(new CharacterData.AttributeData(
					AbilityAttributes.Duration.Id, 5f
				));

				ret.overrideAttributes.Add(new CharacterData.AttributeData(
					ActorAttributes.WeaponCooldownScalar.Id, .5f
				));

				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.Name = "Rage Machine";

				return ret;
			}
		}

    }
}