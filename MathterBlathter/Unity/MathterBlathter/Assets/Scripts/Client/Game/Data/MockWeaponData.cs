using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class MockActorData
	{
		
		/*public static CharacterData MELEE_WEAPON_1 {
			get {
				var ret = new CharacterData();
				ret.Id = 1000;
				ret.ResourcePath = "Weapons/MeleeTest";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "2x4";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.PLAYER_MELEE.Id, 0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1f
				));
				return ret;
			}
		}*/

		public static CharacterData WALL_TURRET_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1001;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Ceramic Blaster";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.ENEMY_PROJECTILE_TEST.Id, 0
				));

				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FIRE_ON_FALL.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1f
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
					ActorAttributes.Abilities.Id, MockAbilityData.SHOTGUN_BLAST.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FIRE_ON_FALL.Id, 1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 40
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
				ret.Name = "Rusty Repeater";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.DOUBLE_SHOT.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1.3f
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
					ActorAttributes.Abilities.Id, MockAbilityData.RAIL_GUN.Id,
					0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 70
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
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FIRE_ON_FALL.Id,
					1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.ROCKET_LAUNCHER.Id, 0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 40
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 2f
				));


				return ret;
			}
		}

		public static CharacterData WAVE_GUN {
			get {
				var ret = new CharacterData();
				ret.Id = 1006;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Wave Gun";

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.CONTINUOUS_BEAM.Id,
					0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 2
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, -float.MinValue
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 0f
				));

				return ret;
			}
		}

		public static CharacterData RUST_MACHINE {
			get {
				var ret = new CharacterData();
				ret.Id = 1007;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rust Machine";

				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FIRE_ON_FALL.Id,
					1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.RAIL_GUN.Id,
					0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 8
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, 2f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, .09f
				));

				return ret;
			}
		}

		public static CharacterData RUSTY_SHIELD {
			get {
				var ret = new CharacterData();

				ret.Id = 1008;
				ret.ResourcePath = "Weapons/Shield_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rusty Shield";

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, 
					MockAbilityData.SHIELD_BLOCK.Id,
					0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, 0
				));

				return ret;
			}
		}

		public static CharacterData SHIELD_BLOCK_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 1009;
				ret.ResourcePath = "Weapons/Shield_prefab";
				ret.ActorType = ActorType.Projectile;
				return ret;
			}
		}

		public static CharacterData STATIC_REPEATER {
			get {
				var ret = new CharacterData();
				ret.Id = 1010;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Static Repeater";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.STATIC_REPEATER_ABILITY.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeed.Id, 1.3f
				));

				return ret;
			}
		}
		public static CharacterData BLUE_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 1011;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/BlueProjectile_prefab";
				return ret;

			}
		}

		public static CharacterData FLY_BOT_CANNON {
			get {
				var ret = new CharacterData();
				ret.Id = 1012;
				ret.ResourcePath = "Weapons/Ranged_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "FLY_BOT_CANNON";

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, MockAbilityData.FLY_BOT_SPAWN.Id, 0
				));

				return ret;
			}
		}


	}
}

