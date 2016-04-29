using System;
using Client.Game.Attributes;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public static class MockActorData
	{
		private static Dictionary<int, CharacterData> _all;
		static void StaticInit() {
			_all = typeof(MockActorData).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as CharacterData)
				.ToDictionary(p => p.Id, p=>p);
			
		}

		public static CharacterData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
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

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MinJumpPower.Id, .2f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.SustainedJumpPower.Id, .1f
				));
					
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MaxJumpPower.Id, .8f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.BaseDamage.Id, 15
				));


				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Weapons.Id,
					MockWeaponData.RUSTY_REPEATER.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.PLAYER_DEATH_BUFF.Id,
					(int)AbilitySlots.Death
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
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 100
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 10
				));;

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AttackSpeedScalar.Id, 2f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					MockAbilityData.AI_BUFF.Id,
					1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockWeaponData.RANGED_WEAPON_1.Id,
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
					ActorAttributes.Abilities.Id, 100
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
					1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockWeaponData.RANGED_WEAPON_1.Id,
					0
				));


				return ret;
			}
		}




		public static CharacterData RANDOM_WEAPON_PICKUP {
			get {
				var linked = MockWeaponData.HOT_RAILS;
				var ret = new CharacterData();
				ret.Id = 4;
				ret.ResourcePath = linked.ResourcePath;
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add( new CharacterData.AttributeData( 
					ActorAttributes.PickupItemId.Id,
					linked.Id
				));
				ret.attributeData.Add( new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id,
					MockAbilityData.LEVEL_APPROPRIATE_WEAPON.Id
				));

				ret.Name = "RandomWeapon";

				return ret;
			}
		}

		public static CharacterData FIXED_PICKUP {
			get {
				var linked = MockWeaponData.ROCKET_LAUNCHER;
				var ret = new CharacterData();
				ret.Id = 12;
				ret.ResourcePath = linked.ResourcePath;
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add( new CharacterData.AttributeData( 
					ActorAttributes.PickupItemId.Id,
					linked.Id
				));


				ret.Name = "FixedWeapon";

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

		public static CharacterData PROJECTILE {
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
					ActorAttributes.Abilities.Id, 100
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 300
				));;



				return ret;
			}
		}

		public static CharacterData SPIKES {
			get {
				var ret = new CharacterData ();
				ret.Id = 8;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.AIData = new AIData ();
				ret.Name = "Spikes";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, ActorAttributes.Health.MaxValue
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.BaseDamage.Id, 30
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 0f
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id, 
					MockAbilityData.DAMAGE_ON_TOUCH_BUFF.Id,
					0
				));


				return ret;
			}
		}

		public static CharacterData WALL_TURRET {
			get {
				var ret = new CharacterData();
				ret.Id = 9;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.AIData = new AIData();
				ret.Name = "Wall Turret";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, ActorAttributes.Health.MaxValue
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.BaseDamage.Id, 30
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id, 
					MockAbilityData.FIRING_FIXTURE_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockWeaponData.RANGED_WEAPON_1.Id,
					0
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
				ret.Id = 12;
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
					ActorAttributes.Abilities.Id, 100
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
					1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockWeaponData.ROCKET_LAUNCHER.Id,
					0
				));


				return ret;
			}
		}


	}
}

