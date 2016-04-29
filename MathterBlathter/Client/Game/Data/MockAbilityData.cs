using System;
using Client.Game.Attributes;
using Client.Game.Animation;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public static class MockAbilityData
	{


		private static Dictionary<int, AbilityData> _all;
		static void StaticInit() {
			_all = typeof(MockAbilityData).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as AbilityData)
				.ToDictionary(p => p.Id, p=>p);

		}

		public static AbilityData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
		}

		public static AbilityData ENEMY_PROJECTILE_TEST {
			get {
				var ret = new AbilityData ();
				ret.Id = 100;
				ret.name = "Enemy Projectile test";
				ret.spawnableDataId = MockActorData.PROJECTILE.Id;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, .5f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 18f
				));
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 10
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ProjectileAttack);
				ret.AbilityType = AbilityType.Instanced;
				return ret;
			}
		}

		public static AbilityData PLAYER_MELEE {
			get {
				var ret = new AbilityData ();
				ret.Id = 0;
				ret.name = "Player Melee Attack";
				ret.animation = CharacterAnimState.ATTACK1;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, 1.0f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 40
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.MeleeRange.Id, 2f
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.MeleeAttack);
				ret.AbilityType = AbilityType.Instanced;
				return ret;
			}
		}

		public static AbilityData PLAYER_RANGED {
			get {
				var ret = new AbilityData ();
				ret.Id = 1;
				ret.name = "Player Ranged Attack";
				ret.animation = CharacterAnimState.ATTACK2;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, .2f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 10
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ProjectileAttack);
				ret.AbilityType = AbilityType.Instanced;
				return ret;
			}
		}

		public static AbilityData PLAYER_DEATH_BUFF {
			get {
				var ret = new AbilityData ();
				ret.Id = 2;
				ret.name = "Player Death Ability";
				ret.animation = CharacterAnimState.DEATH;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.PlayerDeathBuff);
				ret.AbilityType = AbilityType.Buff;
				return ret;
			}
		}

		public static AbilityData SHOTGUN_BLAST {
			get {
				var ret = new AbilityData();
				ret.Id = 3;
				ret.name = "Shotgun blast";
				ret.animation = CharacterAnimState.ATTACK2;

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 5
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileCount.Id, 3
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 18f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 45f
				));


				ret.spawnableDataId = MockActorData.PROJECTILE.Id;


				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ShotgunBlast);
				ret.AbilityType = AbilityType.Instanced;


				return ret;
			}
		}



		public static AbilityData DAMAGE_ON_TOUCH_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 5;
				ret.name = "Damage On Touch Buff";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.DamageOnTouchBuff);
				ret.AbilityType = AbilityType.Buff;
			
				return ret;
			}
		}

		public static AbilityData AI_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 6;
				ret.name = "AIBUff";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AIBuff);
				ret.AbilityType = AbilityType.Buff;
				return ret;
			}
		}

		public static AbilityData FIRING_FIXTURE_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 7;
				ret.name = "FIXTURE BUFF";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.FiringFixtureBuff);
				ret.AbilityType = AbilityType.Buff;
				return ret;
			}
		}

		public static AbilityData RAIL_GUN {
			get {
				var ret = new AbilityData();
				ret.Id = 8;
				ret.name = "Rail Gun";

				
				ret.spawnableDataId = MockActorData.RAIL_PROJECTILE.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RailGunAttack);
				ret.AbilityType = AbilityType.Instanced;

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 200f
				));
				return ret;
			}
		}

		public static AbilityData LEVEL_APPROPRIATE_WEAPON {
			get {
				var ret = new AbilityData();
				ret.Id = 9;
				ret.name = "LevelAppropriateWeaponBuff";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.LevelAppropriateWeaponDrop);
				ret.AbilityType = AbilityType.Buff;

				return ret;

			}
		}


		public static AbilityData DOUBLE_SHOT {
			get {
				var ret = new AbilityData ();
				ret.Id = 10;
				ret.name = "Double shot";
				ret.spawnableDataId = MockActorData.PROJECTILE.Id;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, .5f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 40f
				));
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 10
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatAmount.Id, 2
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatDelay.Id, .1f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RepeatedProjectileAttack);
				ret.AbilityType = AbilityType.Instanced;
				return ret;
			}
		}

		public static AbilityData ROCKET_LAUNCHER {
			get {
				var ret = new AbilityData();
				ret.Id = 11;
				ret.name = "Rocket Launcher";
				ret.spawnableDataId = MockActorData.ROCKET_PROJECTILE.Id;

				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.Damage.Id, 100
				));

				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.SplashRadius.Id, 5f
				));
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 10f	
				));
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, 30f
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RocketProjectileAttack);


				return ret;
			}
		}
	}
}

