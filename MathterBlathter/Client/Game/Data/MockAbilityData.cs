﻿using System;
using Client.Game.Attributes;
using Client.Game.Animation;
using System.Collections.Generic;
using System.Linq;

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
				ret.spawnableResourcePath = "Projectiles/enemyTest_prefab";
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, 1.0f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 10
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ProjectileAttack);

				return ret;
			}
		}

		public static AbilityData PLAYER_MELEE {
			get {
				var ret = new AbilityData ();
				ret.Id = 0;
				ret.name = "Player Melee Attack";
				ret.animation = States.ATTACK1;
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

				return ret;
			}
		}

		public static AbilityData PLAYER_RANGED {
			get {
				var ret = new AbilityData ();
				ret.Id = 1;
				ret.name = "Player Ranged Attack";
				ret.animation = States.ATTACK2;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, .2f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 10
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.MeleeRange.Id, 50
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ProjectileAttack);

				return ret;
			}
		}

		public static AbilityData PLAYER_DEATH_BUFF {
			get {
				var ret = new AbilityData ();
				ret.Id = 2;
				ret.name = "Player Death Ability";
				ret.animation = States.DEATH;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.PlayerDeathBuff);

				return ret;
			}
		}

	}
}
