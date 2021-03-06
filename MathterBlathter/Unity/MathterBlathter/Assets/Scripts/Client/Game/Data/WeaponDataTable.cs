﻿using System;
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

				ret.AddAbility(AbilityDataTable.ENEMY_PROJECTILE_TEST);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AIActivationRange.Id, 15f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 35f
				));
				return ret;
			}
		}


		public static CharacterData CERAMIC_SHOTGUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1002;
				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;

				ret.Name = "Ceramic Sawed Off Shotgun";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));

				ret.AddAbility(AbilityDataTable.PROJECTILE_SPREAD);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.LIMITED_USE_ITEM_DEBUFF);

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
					ActorAttributes.KnockbackForce.Id, 35f
				));
					

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id, .5f
				));


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipAmount.Id, .05f
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


				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 250;

				return ret;
			}
		}

		public static CharacterData RUSTY_SINGLE_SHOT {
			get {
				var ret = new CharacterData();
				ret.Id = 1003;
				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rusty Repeater";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.DOUBLE_SHOT.Id, 0
				));

				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponAnxietyCost.Id, 2));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipDuration.Id, .04f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .4f
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 30f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id, .1f
				));

				ret.overrideAttributes.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatAmount.Id, 0
				));

				ret.Availability = Availability.None;
				return ret;
			}
		}

		public static CharacterData HOT_RAILS {
			get {
				var ret = new CharacterData();
				ret.Id = 1004;
				ret.ResourcePath = "Weapons/Rifle_prefab";

				ret.ActorType = ActorType.Weapon;
				ret.Name = "Hot Rails";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));

				ret.AddAbility(AbilityDataTable.RAIL_GUN);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id, .6f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipDuration.Id, .045f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 90
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
				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 200;

				return ret;
			}
		}

		public static CharacterData ROCKET_LAUNCHER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1005;
				ret.ResourcePath = "Weapons/Rifle_prefab";

				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rocket Launcher";

				ret.AddAbility(AbilityDataTable.ROCKET_LAUNCHER);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AIActivationRange.Id, 25f
				));

				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));
				
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .4f
				));

				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 150;

				return ret;
			}
		}

		public static CharacterData WAVE_GUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1006;
				ret.ResourcePath = "Weapons/Rifle_prefab";

				ret.ActorType = ActorType.Weapon;
				ret.Name = "Wave Gun";

				ret.AddAbility(AbilityDataTable.CONTINUOUS_BEAM);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

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
					ActorAttributes.KnockbackForce.Id, 15f
				));
				
				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 200;
				return ret;
			}
		}

		public static CharacterData NAIL_MACHINE {
			get {
				var ret = new CharacterData();
				ret.Id = 1007;
				ret.ResourcePath = "Weapons/Rifle_prefab";

				ret.ActorType = ActorType.Weapon;
				ret.Name = "Nail Machine";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_TWO_HANDED));

				ret.AddAbility(AbilityDataTable.RAIL_GUN);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.WEAPON_CURSE);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.3f
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
					ActorAttributes.KnockbackForce.Id, 5f
				));

				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 150;

				return ret;
			}
		}



		public static CharacterData RUSTY_SHIELD_WEAPON {
			get {
				var ret = new CharacterData();

				ret.Id = 1008;
				ret.ResourcePath = "Weapons/ShieldWeapon_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rusty Shield";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.MELEE_ONE_HANDED));

				ret.AddAbility(AbilityDataTable.SHIELD_BLOCK);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.2f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id,
					10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 75f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, 0
				));

				ret.Cost = 120;
				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;

				return ret;
			}
		}

		
		public static CharacterData STATIC_REPEATER {
			get {
				var ret = new CharacterData();
				ret.Id = 1010;
				ret.ResourcePath = "Weapons/Rifle_prefab";

				ret.ActorType = ActorType.Weapon;
				ret.Name = "Static Repeater";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));

				ret.AddAbility(AbilityDataTable.STATIC_REPEATER_ABILITY);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.2f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1.3f
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 35f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Inaccuracy.Id, .1f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 12
				));


				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 200;

				return ret;
			}
		}


		public static CharacterData RANGED_ENEMY_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1013;
				ret.ActorType = ActorType.Weapon;
				ret.ResourcePath = "Weapons/RANGED_1";
				ret.Name = "Ranged Enemy Weapon";


				ret.AddAbility(AbilityDataTable.RANGED_ENEMY_ATTACK);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);


				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.AnxietyCost.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 30f
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

				ret.AddAbility(AbilityDataTable.ENERGY_SAP_ABILITY);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AIActivationRange.Id, 7f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.AnxietyCost.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.ExplosionRadius.Id, 3f
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

				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;
				
				ret.Name = "Cursed Rails";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));

				ret.AddAbility(AbilityDataTable.SWAP_POSITIONS);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);

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

				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Black Ulver";
				
				ret.Availability = Availability.InShop | Availability.RoomClearReward;

				ret.AddAbility(AbilityDataTable.SHORT_PROJECTILE);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					1f
				));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.TOWER_ACTOR_ABSORBER.Id, 2
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 55f
				));
				
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponAnxietyCost.Id, 2));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 100
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
				ret.AddAbility(AbilityDataTable.QUAD_SHOT);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 40f
				));
				ret.Availability = Availability.None;
				return ret;
			}
		}
		
		public static CharacterData GRENADE_LAUNCHER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1018;

				ret.ResourcePath = "Weapons/Rifle_prefab";
				
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Dredgling Grenade Launcher";

				ret.AddAbility(AbilityDataTable.LAUNCH_GRENADE);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 70
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .8f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.ProjectileSpeed.Id, 50f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponAnxietyCost.Id, 10
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 55f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipAmount.Id, .07f
				));


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.5f
				));

				ret.Cost = 750;
				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				
				return ret;
			}
		}

		public static CharacterData LONG_BARREL_SHOTGUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1019;

				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Long Barrel Shotgun";
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_TWO_HANDED));

				ret.AddAbility(AbilityDataTable.PROJECTILE_SPREAD);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);


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
					ActorAttributes.KnockbackForce.Id, 55f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.4f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipAmount.Id,
					.06f
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


				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 350;

				return ret;
			}
		}

		public static CharacterData VIPER_REPEATER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1020;
				ret.ResourcePath = "Weapons/Rifle_prefab";
				

				ret.ActorType = ActorType.Weapon;
				ret.Name = "Viper Repeater";

				ret.AddAbility(AbilityDataTable.DOUBLE_SHOT);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.2f
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
					ActorAttributes.KnockbackForce.Id, 49f
				));


				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatAmount.Id, 2
				));

				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 160;
				return ret;
			}
		}

		public static CharacterData AUTO_HAMMER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1021;
				ret.ActorType = ActorType.Weapon;
				ret.ResourcePath = "Weapons/MeleeTest";
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .4f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id, .4f
				));

				ret.AddAbility(AbilityDataTable.MELEE_SWIPE);
				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);


				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.ReflectsProjectiles.Id, 1));

				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.MELEE_ONE_HANDED));

				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponAnxietyCost.Id, -8));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 60
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 45f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MeleeRange.Id, 3.5f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MeleeWidth.Id, 1f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipDuration.Id, .04f
				));

				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 80;
				ret.Description = "Destroys projectiles, hitting enemies decreases anxiety";
				ret.Name = "Auto Hammer";

				return ret;
			}
		}

		public static CharacterData GRENADE_GEYSER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1022;
				ret.ActorType = ActorType.Weapon;
				ret.ResourcePath = "Weapons/RANGED_1";

				ret.Name = "Grenade Geyser";

				ret.AddAbility(AbilityDataTable.GRENADE_REPEATER);

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 70
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 1f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.ProjectileSpeed.Id, 50f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 55f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipAmount.Id, .07f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					.01f
				));

				ret.Availability = Availability.None;

				return ret;
			}
		}

		public static CharacterData SCATTER_GUN_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1023;

				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_TWO_HANDED));

				ret.AddAbility(AbilityDataTable.PROJECTILE_SPREAD);


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 4f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 55f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					0f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipAmount.Id,
					.06f
				));

				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileCount.Id, 3
				));

				ret.overrideAttributes.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 10f
				));
				ret.overrideAttributes.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, 0f
				));	
				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 10f
				));

				ret.Availability = Availability.None;

				return ret;
			}
		}

		public static CharacterData RUSTY_REPEATER {
			get {
				var ret = new CharacterData();
				ret.Id = 1024;
				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.Name = "Rusty Repeater";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id, AbilityDataTable.DOUBLE_SHOT.Id, 0
				));

				ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);

				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_ONE_HANDED));

				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponAnxietyCost.Id, 2));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipDuration.Id, .04f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, .4f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 30f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id, .1f
				));

				ret.overrideAttributes.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatAmount.Id, 2
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				return ret;
			}
		}

		public static CharacterData BULLET_SNIPER_WEAPON {
			get {
				var ret = new CharacterData();
				ret.Id = 1025;

				ret.ResourcePath = "Weapons/Rifle_prefab";
				ret.ActorType = ActorType.Weapon;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_TWO_HANDED));

				ret.AddAbility(AbilityDataTable.PROJECTILE_SPREAD);


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BaseDamage.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Cooldown.Id, 4f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 55f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.CameraShakeForce.Id,
					0f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TimeSkipAmount.Id,
					.06f
				));

				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileCount.Id, 3
				));

				ret.overrideAttributes.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 30f
				));
				ret.overrideAttributes.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, 0f
				));	
				ret.overrideAttributes.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 5f
				));

				ret.Availability = Availability.None;

				return ret;
			}
		}


        public static CharacterData EXPLODER_WEAPON {
            get {
                var ret = new CharacterData();
                ret.Id = 1026;
                ret.ActorType = ActorType.Weapon;
                
                ret.AddAbility(AbilityDataTable.EXPLODE_AND_DIE);


                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.BaseDamage.Id, 2
                ));

                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.Cooldown.Id, 4f
                ));
                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.KnockbackForce.Id, 55f
                ));
                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.CameraShakeForce.Id,
                    3f
                ));

                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.TimeSkipAmount.Id,
                    .06f
                ));
                
                ret.Availability = Availability.None;

                return ret;
            }
        }


        public static CharacterData CURSED_NAIL_MACHINE {
            get {
                var ret = new CharacterData();
                ret.Id = 1027;
                ret.ResourcePath = "Weapons/Rifle_prefab";

                ret.ActorType = ActorType.Weapon;
                ret.Name = "Rust Machine";
                ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponFlags.Id, (int)WeaponFlagsUtil.RANGED_TWO_HANDED));

                ret.AddAbility(AbilityDataTable.SWAP_POSITIONS);
                ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
                ret.AddAbility(AbilityDataTable.FIRE_ON_FALL);
                ret.AddAbility(AbilityDataTable.WEAPON_CURSE);

                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.CameraShakeForce.Id,
                    .3f
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

                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.WeaponAnxietyCost.Id, 1
                ));

                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.KnockbackForce.Id, 5f
                ));

                ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
                ret.Cost = 140;

                return ret;
            }
        }


    }
}

