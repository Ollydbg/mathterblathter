using System;
using Client.Game.Attributes;
using Client.Game.Animation;

namespace Client.Game.Data
{
	public static class MockAbilityData
	{
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
					AbilityAttributes.Damage.Id, 15f
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
					AbilityAttributes.Damage.Id, 50f
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.MeleeAttack);

				return ret;
			}
		}

	}
}

