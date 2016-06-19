using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{
		

		public static CharacterData WALL_TURRET_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1001;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Wall Turret Weapon";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.ENEMY_PROJECTILE_TEST.Id, 0
				));

				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .5f
				));
				return ret;
			}
		}


		public static CharacterData CERAMIC_SHOTGUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1002;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Ceramic Sawed Off Shotgun";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.SHOTGUN_BLAST.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id, 1
				));



				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));


				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.LIMITED_USE_ITEM_DEBUFF.Id, 3
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Charges.Id,
					30
				));


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 40
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 8
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .5f
				));
					
				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileCount.Id, 5
				));

				ret.overrideAttributes.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 58f
				));
				ret.overrideAttributes.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, -90f
				));

				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 45f
				));


				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 250;

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
					ActorAttributes.Abilities.Id, AbilityDataTable.DOUBLE_SHOT.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id,
					1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponAnxietyCost.Id, 2));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .4f
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 0f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id, .05f
				));


				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatAmount.Id, 1
				));

				ret.Availability = Availability.Droppable;
				ret.Cost = 80;
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
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.RAIL_GUN.Id,
					0
				));
				
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 70
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 13
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1.8f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, 0f
				));
				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 200;

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
					ActorAttributes.Abilities.Id, AbilityDataTable.ROCKET_LAUNCHER.Id, 0
				));

				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 2f
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 150;

				return ret;
			}
		}

		public static CharacterData WAVE_GUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1006;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Wave Gun";

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.CONTINUOUS_BEAM.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_TWO_HANDED));
				

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 200
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, -float.MinValue
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 0f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 0f
				));
				
				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 200;
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
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.RAIL_GUN.Id,
					0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.3f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.WEAPON_CURSE.Id,
					3
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 30
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, 2f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .09f
				));

				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .01f
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 150;

				return ret;
			}
		}

		public static CharacterData RUSTY_SHIELD_WEAPON {
			get {
				var ret = new CharacterData();

				ret.Id = 1008;
				ret.ResourcePath = "Weapons/Shield_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rusty Shield";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.MELEE_ONE_HANDED));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.SHIELD_BLOCK.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.2f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id,
					10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 2f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, 0
				));

				ret.Cost = 120;
				ret.Availability = Availability.Droppable | Availability.InShop;

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
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.STATIC_REPEATER_ABILITY.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.2f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1.3f
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .5f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, .1f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 12
				));


				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 200;

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
					ActorAttributes.Abilities.Id, AbilityDataTable.FLY_BOT_SPAWN.Id, 0
				));
				ret.Cost = 300;
				return ret;
			}
		}

		public static CharacterData RANGED_ENEMY_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1013;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Ranged Enemy Weapon";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.RANGED_ENEMY_ATTACK.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.AnxietyCost.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .5f
				));
					
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));
				return ret;
			}
		}

		public static CharacterData ENERGY_SAPPER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1014;
				ret.ResourcePath = "Weapons/None";
				ret.ActorType = ActorType.Weapon;

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.ENERGY_SAP_ABILITY.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.AnxietyCost.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));

				return ret;
			}
		}


		public static CharacterData CURSED_RAIL_GUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1015;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				
				ret.Name = "Cursed Rails";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.SWAP_POSITIONS.Id, 0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 1
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.AnxietyCost.Id, 20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 110
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, 0f
				));


				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 300;

				return ret;
			}
		}

		public static CharacterData MATTE_BLACK_REVOLVER {
			get {
				var ret = new CharacterData();
				ret.Id = 1016;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Black Ulver";
				
				ret.Availability = Availability.InShop;

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.SHORT_PROJECTILE.Id, 0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.4f
				));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 1.2f
				));
				
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponAnxietyCost.Id, 2));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .8f
				));

				return ret;
			}
		}
		
		public static CharacterData QUAD_SHOT_ENEMY_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1017;
				
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Quad Shot Turret Weapon";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.QUAD_SHOT.Id, 0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .5f
				));
				ret.Availability = Availability.None;
				return ret;
			}
		}
		
		public static CharacterData GRENADE_LAUNCHER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1018;
				ret.ResourcePath = "Weapons/RANGED_1";
				
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Dredgling Grenade Launcher";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.4f
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.LAUNCH_GRENADE.Id, 0
				));
				
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id, 1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 50
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .8f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 10
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 1f
				));
				
				ret.Cost = 750;
				ret.Availability = Availability.Droppable | Availability.InShop;
				
				return ret;
			}
		}

		public static CharacterData LONG_BARREL_SHOTGUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1019;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Long Barrel Shotgun";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_TWO_HANDED));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.SHOTGUN_BLAST.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id, 1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 40
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .9f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 10
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .5f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.4f
				));

				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileCount.Id, 3
				));

				ret.overrideAttributes.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 65f
				));
				ret.overrideAttributes.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, -70f
				));

				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 20f
				));


				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 350;

				return ret;
			}
		}

		public static CharacterData VIPER_REPEATER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1020;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Viper Repeater";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.DOUBLE_SHOT.Id, 0
				));
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.FIRE_ON_FALL.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.2f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));

				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponAnxietyCost.Id, 8));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 15
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .4f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, .9f
				));


				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatAmount.Id, 2
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 160;
				return ret;
			}
		}

	}
}

