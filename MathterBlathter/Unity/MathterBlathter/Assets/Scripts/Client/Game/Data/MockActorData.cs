﻿using System;
using Client.Game.Attributes;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public static partial class MockActorData
	{
		private static Dictionary<int, CharacterData> _all;
		static void StaticInit() {
			_all = typeof(MockActorData).GetProperties()
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

		public static CharacterData PLAYER_TEST {
			get {
				var ret = new CharacterData ();
				ret.Id = 1;
				ret.ResourcePath = "Actors/Arthur/Prefabs/arthur_prefab";
				ret.ActorType = ActorType.Player;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 20f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.PassesThroughPlatforms.Id, 1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Anxiety.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData( 
					ActorAttributes.MaxAnxiety.Id, 200
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AnxietyRegen.Id, 2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MinJumpPower.Id, .3f
				)); 

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxWeapons.Id, 2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.SustainedJumpPower.Id, 10f
				));
					
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MaxJumpPower.Id, .45f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.BaseDamage.Id, 15
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Inaccuracy.Id, 2f
				));


				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Weapons.Id,
					MockActorData.RUSTY_REPEATER.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.PLAYER_DEATH_BUFF.Id,
					(int)AbilitySlots.Death
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.INVULNERABLE_AFTER_HIT_BUFF.Id,
					0
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.ANXIETY_REGEN_BUFF.Id,
					1
				));

				return ret;
			}
		}



		public static CharacterData GROUNDED_RANGED_ENEMY {
			get {
				var ret = new CharacterData ();
				ret.Id = 2;
				ret.ResourcePath = "Actors/Enemies/EnemyTest_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = new AIData ();
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
					ActorAttributes.BloodBounty.Id, 10
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AttackSpeedScalar.Id, 3f
				));
				
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AI_BUFF.Id,
					0
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.WALL_TURRET_WEAPON.Id,
					0
				));

				return ret;
			}
		}

		public static CharacterData FLOATING_TURRET {
			get {
				var ret = new CharacterData ();
				ret.Id = 3;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = new AIData ();
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
					ActorAttributes.AttackSpeedScalar.Id, 3f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 10
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.RANGED_ENEMY_WEAPON.Id,
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

		public static CharacterData PINK_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 6;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/enemyTest_prefab";

				return ret;
			}
		}

		public static CharacterData SHOPKEEPER {
			get {
				var ret = new CharacterData ();
				ret.Id = 7;
				ret.ResourcePath = "Actors/NPCS/ShopKeeper_prefab";
				ret.ActorType = ActorType.Friendly;
				ret.AIData = new AIData ();
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
					ActorAttributes.Abilities.Id, MockAbilityData.SHOPKEEPER_INVENTORY_CREATOR.Id, 0
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



		public static CharacterData RAIL_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 10;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/HotRail_prefab";
				return ret;
			}
		}

		public static CharacterData ROCKET_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 11;
				ret.ActorType = ActorType.Projectile;
				ret.ResourcePath = "Projectiles/SmallRocket_prefab";
				return ret;
			}
		}

		public static CharacterData ROCKET_TURRET {
			get {
				var ret = new CharacterData ();
				ret.Id = 13;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = new AIData ();
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
					ActorAttributes.Speed.Id, .05f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AttackSpeedScalar.Id, 2f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 10
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.ROCKET_LAUNCHER.Id,
					0
				));


				return ret;
			}
		}



		public static CharacterData RAIL_SNIPER_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 16;
				ret.ResourcePath = "Actors/Enemies/Sniper_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.Name = "Sniper";
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.HOT_RAILS.Id,
					0
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.SNIPER_AI_BUFF.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AIM_RAY_BUFF.Id,
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

		public static CharacterData AIM_RAY {
			get {
				var ret = new CharacterData();
				ret.Id = 17;
				ret.ResourcePath = "Projectiles/VFX/aimLine_prefab";
				ret.ActorType = ActorType.Projectile;
				return ret;
			}
		}

		public static CharacterData FLY_BOT_SPAWNER {
			get {
				var ret = new CharacterData();
				ret.Id = 18;
				ret.ResourcePath = "Actors/Enemies/FlyBotSpawner_prefab";
				ret.ActorType = ActorType.Enemy;

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					1000
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Health.Id,
					100
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
					MockActorData.FLY_BOT_CANNON.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AI_BUFF.Id,
					0
				));

				return ret;
			}
		}


		public static CharacterData GROUND_STATIC_TURRET {
			get {
				var ret = new CharacterData();
				ret.Id = 19;
				ret.ResourcePath = "Actors/Enemies/FlyBotSpawner_prefab";
				ret.ActorType = ActorType.Enemy;

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					100
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Health.Id,
					1000
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
					ActorAttributes.AttackSpeedScalar.Id, 3f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.STATIC_REPEATER.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.SENTRY_AI_BUFF.Id,
					0
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.AIM_RAY_BUFF.Id,
					1
				));

				return ret;
			}
		}

		public static CharacterData FLY_BOT {
			get {
				var ret = new CharacterData();
				ret.Id = 20;

				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = new AIData ();

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
					ActorAttributes.AttackSpeedScalar.Id, 3f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id, 0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AI_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.WALL_TURRET_WEAPON.Id,
					0
				));


				return ret;
			}
		}


		public static CharacterData ENERGY_SAPPER_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 21;

				ret.ResourcePath = "Actors/Enemies/PurpleFloater_prefab";
				ret.ActorType = ActorType.Enemy;

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
					15
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.AttackSpeedScalar.Id, 1f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 40.0f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.ENERGY_SAPPER_WEAPON.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AI_BUFF.Id,
					0
				));


				return ret;
			}
		}

		public static CharacterData BEAM_PROJECTILE {
			get {
				var ret = new CharacterData();
				ret.Id = 22;
				ret.ResourcePath = "Projectiles/BeamProjectile_prefab";
				ret.ActorType = ActorType.Projectile;
				return ret;
			}
		}

	}
}

