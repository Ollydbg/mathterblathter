﻿using System;
using Client.Game.Attributes;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Enums;
using Client.Game.AI.Actions;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{
		private static Dictionary<int, CharacterData> _all;
		static void StaticInit() {
			var tmpList = typeof(CharacterDataTable).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as CharacterData);

			_all = new Dictionary<int, CharacterData>();
			foreach( var d in tmpList) {
				if(!_all.ContainsKey(d.Id)) {
					_all[d.Id] = d;
				} else {
					Debug.LogError(string.Format("{0} and {1} have the same id: {2}!!", d.Name, _all[d.Id].Name, d.Id));
				}
			}
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
				ret.SpawnType = SpawnType.Grounded;
				ret.AIData = AIDataTable.PATROL_THEN_PURSUE_AI;
				
				ret.ResourcePath = "Actors/Enemies/GroundTroop/EnemyTestSprite_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 60
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 90f
				));

				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 6
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);

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

				ret.SpawnType = SpawnType.Air;
				ret.ResourcePath = "Actors/Enemies/Drone1/Drone1_prefab";
				ret.ActorType = ActorType.Enemy;
                ret.AIData = AIDataTable.AIR_PATH_TO_FIRE_AI;
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
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id, 200f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 10
				));;

				ret.AddAbility(AbilityDataTable.AI_BUFF);

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



		
		public static CharacterData FLOATING_SCATTER_GUN_ENEMY {
			get {
				var ret = new CharacterData ();
				ret.Id = 13;
				ret.SpawnType = SpawnType.Air;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = AIDataTable.IDLE_THEN_SEEK_AI;
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

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id, 2f
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

				ret.AddAbility(AbilityDataTable.AI_BUFF);

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.SCATTER_GUN_WEAPON.Id,
					0
				));


				return ret;
			}
		}



		public static CharacterData BULLET_SNIPER_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 16;

				ret.SpawnType = SpawnType.Grounded;
				ret.ResourcePath = "Actors/Enemies/Sniper_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = AIDataTable.WANDERING_SNIPER_AI;
				ret.Name = "Sniper";
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.BULLET_SNIPER_WEAPON.Id,
					0
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);
				ret.AddAbility(AbilityDataTable.AIM_RAY_BUFF);

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Speed.Id,
					200f//40f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DamageScalar.Id, .25f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AILockOnTime.Id, .5f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AISleepTime.Id, .5f
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.AIDetectionRadius.Id,
					30f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AIIdleRange.Id, 15f
				));


				return ret;
			}
		}


		public static CharacterData ANXIETY_BALL_ENEMY {
			get {
				var ret = new CharacterData();
				ret.Id = 21;

				ret.SpawnType = SpawnType.Air;
				ret.ResourcePath = "Actors/Enemies/PurpleFloater_prefab";
				ret.ActorType = ActorType.Enemy;
				
				ret.AIData = AIDataTable.IDLE_THEN_SEEK_AI;
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					20
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Health.Id,
					20
				));


				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id, 100f
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
					ActorAttributes.Anxiety.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxAnxiety.Id, 30
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 40.0f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.RANGED_ENEMY_WEAPON.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AnxietyDamageScalar.Id, 
					1f
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);



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

				ret.SpawnType = SpawnType.Air;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;

				ret.AIData = AIDataTable.ROVING_FIRING_FIXTURE_AI;
				
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 120
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 80f
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

				ret.AddAbility(AbilityDataTable.AI_BUFF);
				ret.AddAbility(AbilityDataTable.STATIONARY_BUFF);


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
				ret.SpawnType = SpawnType.Grounded;
				ret.AIData = AIDataTable.PATROL_THEN_PURSUE_AI;

				ret.ResourcePath = "Actors/Enemies/ViperEnemy_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 20
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 10f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 100f
				));

				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 45
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, .5f
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.RANGED_ENEMY_WEAPON.Id,
					0
				));

				return ret;
			}
		}

		public static CharacterData TARGETING_DUMMY {
			get {
				var ret = new CharacterData ();
				ret.Id = 27;
				ret.SpawnType = SpawnType.Grounded;
				ret.AIData = AIDataTable.PATROL_THEN_PURSUE_AI;

				ret.ResourcePath = "Actors/Enemies/GroundTroop/EnemyTestSprite_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, int.MaxValue
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 8f
				));

				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 6
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, 3f
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.WALL_TURRET_WEAPON.Id,
					0
				));

				ret.AddAbility(AbilityDataTable.ANXIETY_REGEN_BUFF);

				return ret;
			}
		}
        
		public static CharacterData SHOTGUN_GHOST {
			get {
				var ret = new CharacterData();
				ret.Id = 29;

				ret.SpawnType = SpawnType.Air;
				ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
				ret.ActorType = ActorType.Enemy;

				ret.AIData = AIDataTable.FIRE_THEN_TELEPORT;

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id, CharacterDataTable.SCATTER_GUN_WEAPON.Id, 0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 175
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id, 0f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);

				return ret;
			}
		}

		public static CharacterData BOSS_1 {
			get {
				var ret = new CharacterData();
				ret.Id = 30;

				ret.SpawnType = SpawnType.Air;
				ret.ResourcePath = "Actors/Enemies/Boss1/Boss1_prefab";

				ret.AIData = AIDataTable.SEEK_TO_FIRE_IF_LOS_AI;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 600
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id, 23f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 100.0f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.WeaponCooldownScalar.Id, .5f
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id, CharacterDataTable.SCATTER_GUN_WEAPON.Id, 0
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);

				return ret;
			}
		}

		public static CharacterData FLYING_WALL_PHASER {
			get {
				var ret = new CharacterData();
				ret.Id = 31;
				ret.SpawnType = SpawnType.Air;
				ret.ActorType = ActorType.Enemy;
				ret.ResourcePath = "Actors/Enemies/GhostTurret_prefab";
				ret.AIData = AIDataTable.AIM_STEER_THROUGH_GEO;

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id, CharacterDataTable.RANGED_ENEMY_WEAPON.Id, 0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AIMaxTurnSpeed.Id, 20f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 175
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Speed.Id, 130f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);
				return ret;
			}
		}

        public static CharacterData TRUNDLER_MINE {
            get {

                var ret = new CharacterData();
                ret.Id = 32;
                ret.SpawnType = SpawnType.Air;
                ret.ActorType = ActorType.Enemy;
                ret.ResourcePath = "Actors/Enemies/FloatingTurret_prefab";
                ret.AIData = new AIData();
                ret.AIData.ActionData = new ActionData(
                    typeof(WaitForPlayerWalkUnder)
                );

                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.Weapons.Id,
                    CharacterDataTable.EXPLODER_WEAPON.Id, 0
                ));

                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.AIMaxTurnSpeed.Id, 20f
                ));

                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.Health.Id, 40
                ));

                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.Speed.Id, 130f
                ));
                ret.attributeData.Add(new GameData.AttributeData(
                    ActorAttributes.TakesDamage.Id, 1
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.GravityScalar.Id, 0.0f
                ));

                
                ret.AddAbility(AbilityDataTable.AI_BUFF);

                return ret;
            }

        }

	}
}

