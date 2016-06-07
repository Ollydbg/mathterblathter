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
				ret.spawnableDataId = MockActorData.PINK_PROJECTILE.Id;
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
					AbilityAttributes.Damage.Id, (int)10
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
				ret.animation = CharacterAnimState.DEATH;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.PlayerDeathBuff);
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
					AbilityAttributes.ProjectileCount.Id, 5
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 58f
				));
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, -90f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 45f
				));

				ret.spawnableDataId = MockActorData.PINK_PROJECTILE.Id;
				var timeline = new TimelineData();
				timeline.AsciiMap += "s";
				timeline.Duration = 1f;
				timeline.Lookup['s'] = new TimelineData.Point("SFX/shotgun", AttachPoint.Muzzle);

				ret.Timelines.Add(timeline);

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ShotgunBlast);
				
				return ret;
			}
		}



		public static AbilityData DAMAGE_ON_TOUCH_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 5;
				ret.name = "Damage On Touch Buff";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.DamageOnTouchBuff);
				
				return ret;
			}
		}

		public static AbilityData AI_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 6;
				ret.name = "AIBUff";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AIBuff);
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
				
				var fireTimeline = new TimelineData();

				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Duration = .5f;

				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/hotRails", AttachPoint.Muzzle);

				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeee";
				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/enemyTestHit_prefab", AttachPoint.WeaponSlot);

				ret.Timelines.Add(fireTimeline);
				ret.Timelines.Add(hitTimeline);

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
				
				return ret;

			}
		}


		public static AbilityData DOUBLE_SHOT {
			get {
				var ret = new AbilityData ();
				ret.Id = 10;
				ret.name = "Double shot";
				ret.spawnableDataId = MockActorData.PINK_PROJECTILE.Id;
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
				
				var fireTimeline = new TimelineData();
				fireTimeline.AsciiMap += "eeeeeee     ";
				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Duration = .5f;

				fireTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/SmallMuzzleFlash_prefab", AttachPoint.Muzzle);
				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/smith_wesson", AttachPoint.Muzzle);

				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeeeeee     ";
				hitTimeline.AsciiMap += "sssssss     ";
				hitTimeline.Duration = .5f;

				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/enemyTestHit_prefab", AttachPoint.WeaponSlot);


				ret.Timelines.Add(fireTimeline);
				ret.Timelines.Add(hitTimeline);
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
					ActorAttributes.WeaponAnxietyCost.Id, 14
				));

				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 10f	
				));
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, 30f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RocketProjectileAttack);

				return ret;
			}
		}

		public static AbilityData HEAL {
			get {
				var ret = new AbilityData();
				ret.Id = 12;
				ret.name = "Heal";
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.Damage.Id, -100
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.HealPlayer);
				return ret;
			}
		}

		public static AbilityData FIRE_ON_FALL {
			get {
				var ret = new AbilityData();
				ret.Id = 13;
				ret.name = "HairTrigger";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.FireOnFall);
				return ret;
			}
		}

		public static AbilityData STAT_UP {
			get {
				var ret = new AbilityData();
				ret.Id = 14;
				ret.name = "StatUp";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.StatUp);
				return ret;
			}
		}

		public static AbilityData AIM_RAY_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 16;
				ret.name = "aiming ray";
				ret.spawnableDataId = MockActorData.AIM_RAY.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AimRay);
				return ret;
			}
		}

		public static AbilityData CONTINUOUS_BEAM {
			get {
				var ret = new AbilityData();
				ret.Id = 17;
				ret.name = "wave gun";
				ret.spawnableDataId = MockActorData.BEAM_PROJECTILE.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ContinuousBeam);
				return ret;
			}
		}

		public static AbilityData INVULNERABLE_AFTER_HIT_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 18;
				ret.name = "Invulnerable after hit";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.InvulnerableAfterHitBuff);
				
				return ret;
			}
		}
		public static AbilityData INVULNERABILITY_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 19;
				ret.name = "Invulnerability";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.InvulnerabilityBuff);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.Duration.Id, 1f
				));
				return ret;
			}
		}

		public static AbilityData MOVE_BOOST_TEMP {
			get {
				var ret = new AbilityData();
				ret.Id = 20;
				ret.name = "Move Boost Temp";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.MoveBoostTempBuff);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.Duration.Id, 10f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.SpeedBoost.Id, 10f
				));

				return ret;
			}
		}

		public static AbilityData JUMP_BUFF_PERM {
			get {
				var ret = new AbilityData();
				ret.Id = 21;
				ret.name = "JumpBuff";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.JumpBuff);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.Duration.Id, float.MaxValue
				));

				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.MaxJumpPower.Id, .15f
				));



				return ret;
			}
		}

		public static AbilityData FALL_DAMAGE_PERM {
			get {
				var ret = new AbilityData();
				ret.Id = 22;
				ret.name = "FallDamage";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.JumpDamage);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.Duration.Id, float.MaxValue
				));

				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.FallDamageThreshold.Id, 30f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.Damage.Id, 1
				));

				return ret;
			}
		}

		public static AbilityData RABBITS_FOOT_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 23;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.DropQualityBuff);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.Duration.Id, float.MaxValue
				));

				return ret;
			}
		}

		public static AbilityData LEVEL_APPROPRIATE_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 24;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.LevelAppropriateBuffDrop);

				return ret;
			}
		}

		public static AbilityData SHIELD_BLOCK {
			get {
				var ret = new AbilityData();
				ret.Id = 25;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ShieldBlock);
				ret.spawnableDataId = MockActorData.SHIELD_BLOCK_PROJECTILE.Id;
				return ret;
			}
		}

		public static AbilityData STATIC_REPEATER_ABILITY {
			get {
				var ret = new AbilityData ();
				ret.Id = 26;
				ret.name = "Double shot";
				ret.spawnableDataId = MockActorData.BLUE_PROJECTILE.Id;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, 1f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 70f
				));
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 9
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatAmount.Id, 3
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.RepeatDelay.Id, .1f
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));


				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RepeatedProjectileAttack);
				
				var fireTimeline = new TimelineData();
				fireTimeline.AsciiMap += "eeeeeee     ";
				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Duration = .5f;

				fireTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/SmallMuzzleFlash_prefab", AttachPoint.Muzzle);
				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/laser_discharge", AttachPoint.Muzzle);

				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeeeeee     ";
				hitTimeline.AsciiMap += "sssssss     ";
				hitTimeline.Duration = .5f;

				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/enemyTestHit_prefab", AttachPoint.WeaponSlot);
				ret.Timelines.Add(hitTimeline);
				ret.Timelines.Add(fireTimeline);
				return ret;
			}
		}

		public static AbilityData FLY_BOT_SPAWN {
			get {
				var ret = new AbilityData();
				ret.Id = 27;
				ret.spawnableDataId = MockActorData.FLY_BOT.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.SpawnEnemy);
				return ret;
			}
		}

		
		public static AbilityData ANXIETY_REGEN_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 29;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AnxietyRegenBuff);
				ret.attributeData.Add(new GameData.AttributeData(AbilityAttributes.AnxietyRegenScalar.Id, 6f));
				var unlockTimeline = new TimelineData();
				unlockTimeline.AsciiMap += "sssss    ";
				unlockTimeline.Lookup['s'] = new TimelineData.Point("SFX/room_cleared", AttachPoint.WeaponSlot);

				ret.Timelines.Add(unlockTimeline);

				return ret;
			}
		}
			
		public static AbilityData RANGED_ENEMY_ATTACK {
			get {
				
				var ret = new AbilityData ();
				ret.Id = 30;
				ret.spawnableDataId = MockActorData.PINK_PROJECTILE.Id;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, .5f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 15f
				));
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 8
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RepeatedProjectileAttack);

				var fireTimeline = new TimelineData();
				fireTimeline.AsciiMap += "eeeeeee     ";
				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Duration = .5f;

				fireTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/SmallMuzzleFlash_prefab", AttachPoint.Muzzle);
				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/smith_wesson", AttachPoint.Muzzle);


				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeeeeee     ";
				hitTimeline.AsciiMap += "sssssss     ";
				hitTimeline.Duration = .5f;

				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/enemyTestHit_prefab", AttachPoint.WeaponSlot);
				ret.Timelines.Add(hitTimeline);
				ret.Timelines.Add(fireTimeline);

				return ret;
			}

		}

		public static AbilityData ENERGY_HEAL {
			get {
				var ret = new AbilityData();
				ret.Id = 31;
				ret.name = "EnergyHeal";
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.Anxiety.Id, 100
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AnxietyHealPlayer);
				return ret;
			}
		}

		public static AbilityData SHOPKEEPER_INVENTORY_CREATOR {
			get {
				var ret = new AbilityData();
				ret.Id = 32;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ShopkeeperBuff);
				ret.spawnableDataId = MockActorData.SHOP_CLOSED_SIGN.Id;
				return ret;
			}
		}

		public static AbilityData ENERGY_SAP_ABILITY {
			get {
				var ret = new AbilityData();
				ret.Id = 33;
				
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.Damage.Id, 4
				));

				var sapTimeline = new TimelineData();
				
				sapTimeline.AsciiMap += "eeeeee   ";
				sapTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/rocketExplosion_prefab", AttachPoint.WeaponSlot);
				ret.Timelines.Add(sapTimeline);
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.EnergySap);

				return ret;
			}
		}

		public static AbilityData LOWER_ANXIETY_DAMAGE_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 34;
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.AnxietyDamageScalar.Id, .5f
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AnxietyDamageReductionBuff);

				return ret;
			}
		}

		public static AbilityData SWAP_POSITIONS {
			get {
				var ret = new AbilityData();
				ret.Id = 35;

				ret.spawnableDataId = MockActorData.RAIL_PROJECTILE.Id;
				var fireTimeline = new TimelineData();

				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Duration = .5f;

				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/hotRails", AttachPoint.Muzzle);

				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeee";
				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/enemyTestHit_prefab", AttachPoint.WeaponSlot);

				ret.Timelines.Add(fireTimeline);
				ret.Timelines.Add(hitTimeline);

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 200f
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.SwapActorPositions);
				return ret;
			}
		}

		public static AbilityData SHORT_PROJECTILE {
			get {
				var ret = new AbilityData();
				ret.Id = 36;

				ret.spawnableDataId = MockActorData.FAT_BLACK_SLUG_PROJECTILE.Id;
				var fireTimeline = new TimelineData();

				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Duration = .5f;

				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/shotgun", AttachPoint.Muzzle);

				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeee";
				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/enemyTestHit_prefab", AttachPoint.WeaponSlot);

				ret.Timelines.Add(fireTimeline);
				ret.Timelines.Add(hitTimeline);


				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 30
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileCount.Id, 1
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 60f
				));
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, -120f
				));
				


				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ProjectileAttack);
				return ret;
			}
		}

		public static AbilityData LAUNCH_PAD_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 37;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.LaunchPadBuff);
				return ret;
			}
		}
		
		public static AbilityData STATIONARY_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 38;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.StationaryBuff);
				return ret;
			}
		}
		
		public static AbilityData CURSED_COURAGE_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 39;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.MaxHealth.Id, -50));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.DamageScalar.Id, 1.5f));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.AttackSpeedScalar.Id, .6f));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.CursedCourageBuff);
				return ret;
				
			}
		}
		
		public static AbilityData TRIGGER_FINGERS_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 40;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.AttackSpeedScalar.Id, .7f));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AttackSpeedBuff);
				return ret;
			}
			
		}
		
		public static AbilityData QUAD_SHOT {
			get {
				var ret = new AbilityData();
				ret.Id = 41;
				ret.name = "quad shot";

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 5
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileCount.Id, 4
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 50f
				));
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, -90f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 360f
				));

				ret.spawnableDataId = MockActorData.PINK_PROJECTILE.Id;
				var timeline = new TimelineData();
				timeline.AsciiMap += "s";
				timeline.Duration = 1f;
				timeline.Lookup['s'] = new TimelineData.Point("SFX/laser_discharge", AttachPoint.Muzzle);

				ret.Timelines.Add(timeline);

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ShotgunBlast);
				
				return ret;
			}
		}
		
		public static AbilityData LOW_HEALTH_DAMAGE_AMP_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 42;
				ret.name = "Low Health Damage Amplifier";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.DamageScalar.Id, 1f
				));
				
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.LowHealthDamageAmpBuff);
				return ret;
				
			}
		}
		
		public static AbilityData WEAPON_DE_CURSER {
			get {
				var ret = new AbilityData();
				ret.Id = 43;
				return ret;
			}
		}
		
		public static AbilityData WEAPON_CURSE {
			get {
				var ret = new AbilityData();
				ret.Id = 44;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.WeaponCurse);
				return ret;
			}
		}
		public static AbilityData TOWER_WEAPON_ABSORBER {
			get {
				var ret = new AbilityData();
				ret.Id = 45;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.TowerActorAbsorber);
				return ret;
			}
		}
		
		public static AbilityData LAUNCH_GRENADE {
			get {
				var ret = new AbilityData();
				ret.Id = 46;
				ret.spawnableDataId = MockActorData.GRENADE_PROJECTILE.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.LaunchGrenade);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));

				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 48f
				));

				var explosionEffect = new TimelineData();
				explosionEffect.AsciiMap += "eeeeeee";
				explosionEffect.Lookup['e'] = "Projectiles/VFX/rocketExplosion_prefab";
				explosionEffect.Duration = 1f;

				ret.Timelines.Add(explosionEffect);




				return ret;
			}
		}
		
	}
}

