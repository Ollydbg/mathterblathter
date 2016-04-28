﻿using System;
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

		private static Dictionary<int, CharacterData> All {
			get {
				if (_all == null) {
					StaticInit();
				}
				return _all;
			}
		}

		public static List<CharacterData> GetAll() {
			return All.Values.ToList();
		}

		public static CharacterData FromId(int id) {
			return All[id];
		}

		public static CharacterData MELEE_WEAPON_1 {
			get {
				var ret = new CharacterData();
				ret.Id = 1000;
				ret.ResourcePath = "Weapons/MeleeTest";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "2x4";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.PLAYER_MELEE.Id
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1f
				));
				return ret;
			}
		}

		public static CharacterData RANGED_WEAPON_1 {
			get {
				var ret = new CharacterData();
				ret.Id = 1001;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Ceramic Blaster";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.ENEMY_PROJECTILE_TEST.Id
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, .5f
				));
				return ret;
			}
		}


		public static CharacterData CERAMIC_SHOTGUN {
			get {
				var ret = new CharacterData();
				ret.Id = 1002;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Ceramic Shotgun";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.SHOTGUN_BLAST.Id
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 20
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1f
				));
				return ret;
			}
		}

		public static CharacterData RUSTY_REPEATER {
			get {
				var ret = new CharacterData();
				ret.Id = 1003;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rusty Blaster";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.DOUBLE_SHOT.Id
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 100
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1f
				));

				return ret;
			}
		}

		public static CharacterData HOT_RAILS {
			get {
				var ret = new CharacterData();
				ret.Id = 1004;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Hot Rails";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.RAIL_GUN.Id
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 300
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1.8f
				));

				return ret;
			}
		}

		public static CharacterData ROCKET_LAUNCHER {
			get {
				var ret = new CharacterData();
				ret.Id = 1005;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rocket Launcher";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.ROCKET_LAUNCHER.Id
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 300
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 2f
				));


				return ret;
			}
		}

	}
}

