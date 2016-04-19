using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static class MockWeaponData
	{
		private static Dictionary<int, CharacterData> _all;
		static void StaticInit() {
			_all = typeof(MockWeaponData).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as CharacterData)
				.ToDictionary(p => p.Id, p=>p);

		}

		public static CharacterData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
		}

		public static CharacterData MELEE_WEAPON_1 {
			get {
				var ret = new CharacterData();
				ret.ResourcePath = "Weapons/MeleeTest";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "2x4";
				ret.Id = 1000;
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.PLAYER_MELEE.Id
				));
				return ret;
			}
		}

		public static CharacterData RANGED_WEAPON_1 {
			get {
				var ret = new CharacterData();
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Ceramic Blaster";
				ret.Id = 1001;
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.ENEMY_PROJECTILE_TEST.Id
				));

				return ret;
			}
		}


		public static CharacterData CERAMIC_SHOTGUN {
			get {
				var ret = new CharacterData();
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Ceramic Shotgun";
				ret.Id = 1002;
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.SHOTGUN_BLAST.Id
				));

				return ret;
			}
		}
	}
}

