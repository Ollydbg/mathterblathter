﻿using System;
using Client.Game.Attributes;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{
		private static Dictionary<int, CharacterData> _all;
		static void StaticInit() {
			_all = typeof(CharacterDataTable).GetProperties()
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

		public static CharacterData GROUNDED_RANGED_ENEMY {
			get {
				var ret = new CharacterData ();
				ret.Id = 2;
				ret.SpawnType = AsciiConstants.GROUNDED_SPAWN;
				ret.AIData = AIDataTable.PATROL_THEN_PURSUE_AI;
				
				ret.ResourcePath = "Actors/Enemies/GroundTroop/EnemyTestSprite_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 100
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .08f
				));

				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 6
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));
				
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.WALL_TURRET_WEAPON.Id,
					0
				));

				return ret;
			}
		}

		public static CharacterData FLOATING_TURRET {
			get {
				var ret = new CharacterData ();
				ret.Id = 3;

				ret.SpawnType = AsciiConstants.AIR_SPAWN;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = AIDataTable.SEEK_TO_FIRE_AI;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 100
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .08f
				));
			
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 10
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.RANGED_ENEMY_WEAPON.Id,
					0
				));


				return ret;
			}
		}




		public static CharacterData DOOR {
			get {
				var ret = new CharacterData();
				ret.Id = 5;
				ret.ResourcePath = "Door_prefab";
				ret.ActorType = ActorType.Door;

				return ret;
			}
		}

		
		public static CharacterData SHOPKEEPER {
			get {
				var ret = new CharacterData ();
				ret.Id = 7;

				ret.ResourcePath = "Actors/NPCS/ShopKeeper_prefab";
				ret.ActorType = ActorType.Friendly;
				ret.Name = "Grapthar";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 1000
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .08f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, AbilityDataTable.SHOPKEEPER_INVENTORY_CREATOR.Id, 0
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 300
				));

				return ret;
			}
		}

		
		public static CharacterData FLOATING_ROCKET_TURRET_ENEMY {
			get {
				var ret = new CharacterData ();
				ret.Id = 13;
				ret.SpawnType = AsciiConstants.AIR_SPAWN;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = AIDataTable.SEEK_TO_FIRE_AI;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 50
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 40.0f
				));
				
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIAttackDelay.Id, 2.0f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .05f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 2f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 12
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.ROCKET_LAUNCHER.Id,
					0
				));


				return ret;
			}
		}



		public static CharacterData RAIL_SNIPER_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 16;

				ret.SpawnType = AsciiConstants.GROUNDED_SPAWN;
				ret.ResourcePath = "Actors/Enemies/Sniper_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = AIDataTable.SNIPER_AI;
				ret.Name = "Sniper";
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.HOT_RAILS.Id,
					0
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AIM_RAY_BUFF.Id,
					1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Speed.Id,
					.03f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DamageScalar.Id, .25f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.AIDetectionRadius.Id,
					30f
				));
				return ret;
			}
		}

		
		public static CharacterData FLY_BOT_SPAWNER_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 18;
				ret.AIData = AIDataTable.FIRING_FIXTURE_AI;
				ret.SpawnType = AsciiConstants.GROUNDED_SPAWN;
				ret.ResourcePath = "Actors/Enemies/FlyBotSpawner_prefab";
				ret.ActorType = ActorType.Enemy;

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					200
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Health.Id,
					200
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id,
					0f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BloodBounty.Id,
					20
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 40.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.FLY_BOT_CANNON.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));

				return ret;
			}
		}


		public static CharacterData GROUND_STATIC_TURRET_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 19;

				ret.SpawnType = AsciiConstants.GROUNDED_SPAWN;
				ret.ResourcePath = "Actors/Enemies/FlyBotSpawner_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = AIDataTable.PATROL_THEN_PURSUE_AI;
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					200
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Health.Id,
					200
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id,
					0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BloodBounty.Id,
					12
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.STATIC_REPEATER.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.STATIONARY_BUFF.Id,
					2
				));

				return ret;
			}
		}

		public static CharacterData FLY_BOT {
			get {
				var ret = new CharacterData();
				ret.Id = 20;

				ret.SpawnType = AsciiConstants.AIR_SPAWN;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = AIDataTable.SEEK_TO_FIRE_AI;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 10
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 80.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .1f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id, 0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.WALL_TURRET_WEAPON.Id,
					0
				));


				return ret;
			}
		}


		public static CharacterData ENERGY_SAPPER_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 21;

				ret.SpawnType = AsciiConstants.AIR_SPAWN;
				ret.ResourcePath = "Actors/Enemies/PurpleFloater_prefab";
				ret.ActorType = ActorType.Enemy;
				
				ret.AIData = AIDataTable.SEEK_TO_FIRE_AI;
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Health.Id,
					20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id,
					.1f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.BloodBounty.Id,
					2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponCooldownScalar.Id, 1f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 40.0f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.ENERGY_SAPPER_WEAPON.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));


				return ret;
			}
		}

		
		
		public static CharacterData SHOP_CLOSED_SIGN {
			get {
				var ret = new CharacterData();
				ret.Id = 24;
				ret.ActorType = ActorType.Friendly;
				ret.ResourcePath = "Actors/NPCS/SignPost_prefab";
				return ret;
			}
		}
		
		public static CharacterData QUAD_SHOT_TURRET_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 25;

				ret.SpawnType = AsciiConstants.AIR_SPAWN;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;

				ret.AIData = AIDataTable.ROVING_FIRING_FIXTURE_AI;
				
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 150
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .1f
				));
			
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 8
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.STATIONARY_BUFF.Id,
					1
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.QUAD_SHOT_ENEMY_WEAPON.Id,
					0
				));

				return ret;	
			}
		}


		public static CharacterData GROUNDED_VIPER_ENEMY {
			get {
				var ret = new CharacterData ();
				ret.Id = 26;
				ret.SpawnType = AsciiConstants.GROUNDED_SPAWN;
				ret.AIData = AIDataTable.PATROL_THEN_PURSUE_AI;

				ret.ResourcePath = "Actors/Enemies/EnemyTest_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 200
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 30.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .12f
				));

				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 14
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 1.8f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.AI_BUFF.Id,
					0
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.VIPER_REPEATER_WEAPON.Id,
					0
				));

				return ret;
			}
		}

	}
}

