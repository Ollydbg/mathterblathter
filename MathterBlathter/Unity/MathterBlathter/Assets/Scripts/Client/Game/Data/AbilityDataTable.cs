using System;
using Client.Game.Attributes;
using Client.Game.Animation;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public static class AbilityDataTable
	{


		private static Dictionary<int, AbilityData> _all;
		static void StaticInit() {
			_all = typeof(AbilityDataTable).GetProperties()
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
				ret.spawnableDataId = CharacterDataTable.PINK_PROJECTILE.Id;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, .5f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 18f
				));
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ProjectileAttack);
				return ret;
			}
		}

		public static AbilityData MELEE_SWIPE {
			get {
				var ret = new AbilityData ();
				ret.Id = 0;
				ret.name = "Player Melee Attack";
				//ret.animation = CharacterAnimState.ATTACK1;

				var swingTL = new TimelineData();
				swingTL.AsciiMap += "eeeeeee     ";
				swingTL.AsciiMap += "sssssss     ";
				swingTL.Duration = .5f;
				swingTL.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/JackhammerSwipe_Prefab", AttachPoint.Muzzle);
				swingTL.Lookup['s'] = new TimelineData.Point("SFX/Renders/AutoHammer_fire_1", AttachPoint.Muzzle);

				var hitTL = new TimelineData();
				hitTL.Duration = .5f;
				hitTL.AsciiMap += "eeeee  ";
				hitTL.AsciiMap += "ss     ";
				hitTL.Lookup['s'] = new TimelineData.Point("SFX/Renders/AutoHammer_hit_1", AttachPoint.Muzzle);
				hitTL.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/blood_prefab", AttachPoint.Muzzle);

				ret.Timelines.Add(swingTL);
				ret.Timelines.Add(hitTL);

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

		public static AbilityData PROJECTILE_SPREAD {
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
					AbilityAttributes.ProjectileSpeed.Id, 65f
				));
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.ProjectileAccel.Id, -70f
				));

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.ProjectileSpread.Id, 20f
				));

				ret.spawnableDataId = CharacterDataTable.PINK_PROJECTILE.Id;
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
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.DamageOnTouchBuff);
				
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

				
				ret.spawnableDataId = CharacterDataTable.RAIL_PROJECTILE.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RailGunAttack);

				var fireTimeline = new TimelineData(1f, true);
				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/hotRails", AttachPoint.Muzzle);
				ret.Timelines.Add(fireTimeline);
				

				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeee";
				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/hotRailsHit_prefab", AttachPoint.WeaponSlot);
				ret.Timelines.Add(hitTimeline);

				var projectileTL = new TimelineData(3f, true);
				projectileTL.AsciiMap += "eeeee";
				projectileTL.Lookup['e'] = "Projectiles/VFX/railTail_prefab";
				ret.Timelines.Add(projectileTL);

				var wallHit = new TimelineData(2f, false);
				wallHit.AsciiMap += "eeee";
				wallHit.Lookup['e'] = "Projectiles/VFX/railWallHit_prefab";
				ret.Timelines.Add(wallHit);

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
				ret.spawnableDataId = CharacterDataTable.PINK_PROJECTILE.Id;
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
				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/Renders/RustyRepeater_fire_1", AttachPoint.Muzzle);

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
				ret.spawnableDataId = CharacterDataTable.ROCKET_PROJECTILE.Id;

				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.Damage.Id, 0
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

				var fireTL = new TimelineData(1.5f, true);
				fireTL.AsciiMap += "sssss";
				fireTL.Lookup['s'] = "SFX/Renders/RocketLauncher_fire_1";



				var hitTL = new TimelineData();
				hitTL.AsciiMap += "sssss";
				hitTL.AsciiMap += "eeeee";

				hitTL.Duration = 1.5f;
				hitTL.Lookup['s'] = "SFX/Renders/RocketLauncher_explode_1";
				hitTL.Lookup['e'] = "Projectiles/VFX/rocketExplosion_prefab";
					

				ret.Timelines.Add(fireTL);
				ret.Timelines.Add(hitTL);
			

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.RocketProjectileAttack);

				return ret;
			}
		}

		public static AbilityData SMALL_HEAL {
			get {
				var ret = new AbilityData();
				ret.Id = 12;
				ret.DoesPropogate = true;
				ret.name = "Heal";
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.Damage.Id, -4
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
				ret.DoesPropogate = true;
				ret.name = "StatUp";
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Health.Id,
					1
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.StatUp);
				return ret;
			}
		}

		public static AbilityData AIM_RAY_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 16;
				ret.name = "aiming ray";
				ret.spawnableDataId = CharacterDataTable.AIM_RAY.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AimRay);
				return ret;
			}
		}

		public static AbilityData CONTINUOUS_BEAM {
			get {
				var ret = new AbilityData();
				ret.Id = 17;
				ret.name = "wave gun";
				ret.spawnableDataId = CharacterDataTable.BEAM_PROJECTILE.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.ContinuousBeam);

				var hummingTL = new TimelineData();
				hummingTL.Duration = 1f;
				hummingTL.AsciiMap += "sssss";
				hummingTL.Lookup['s'] = "SFX/waveGun";
				ret.Timelines.Add(hummingTL);

				var hitTL = new TimelineData();
				hitTL.Duration = 5f;
				hitTL.AsciiMap += "eeeeeee";
				hitTL.Lookup['e'] = "Projectiles/VFX/WaveGunImpact";

				ret.Timelines.Add(hitTL);

				return ret;
			}
		}

		public static AbilityData INVULNERABLE_AFTER_HIT_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 18;
				ret.name = "Invulnerable after hit";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.InvulnerableAfterHitBuff);
				
				return ret;
			}
		}

		public static AbilityData INVULNERABILITY_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 19;
				ret.DoesPropogate = true;
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
				ret.DoesPropogate = true;
				ret.name = "Move Boost Temp";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.MoveBoostTempBuff);
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
				ret.DoesPropogate = true;
				ret.name = "JumpBuff";
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.JumpBuff);
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
				ret.DoesPropogate = true;
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
				ret.DoesPropogate = true;
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
				ret.spawnableDataId = CharacterDataTable.SHIELD_BLOCK_PROJECTILE.Id;

				var hitTL = new TimelineData();
				hitTL.AsciiMap += "eeeeeee     ";
				hitTL.AsciiMap += "sssssss     ";
				hitTL.Duration = .5f;

				hitTL.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/SmallMuzzleFlash_prefab", AttachPoint.Muzzle);

				ret.Timelines.Add(hitTL);

				return ret;
			}
		}

		public static AbilityData STATIC_REPEATER_ABILITY {
			get {
				var ret = new AbilityData ();
				ret.Id = 26;
				ret.name = "Double shot";
				ret.spawnableDataId = CharacterDataTable.BLUE_PROJECTILE.Id;
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
				ret.Timelines.Add(fireTimeline);
				ret.Timelines.Add(hitTimeline);

				return ret;
			}
		}

		
		public static AbilityData ANXIETY_REGEN_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 29;
				ret.DoesPropogate = true;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.AnxietyRegenBuff);
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
				ret.spawnableDataId = CharacterDataTable.PINK_PROJECTILE.Id;
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Cooldown.Id, .5f
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.ProjectileSpeed.Id, 10f
				));
				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 1
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

		public static AbilityData ENERGY_HEAL {
			get {
				var ret = new AbilityData();
				ret.Id = 31;
				ret.name = "EnergyHeal";
				ret.DoesPropogate = true;
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
				ret.spawnableDataId = CharacterDataTable.SHOP_CLOSED_SIGN.Id;
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
				
				sapTimeline.Duration = .1f;
				sapTimeline.AsciiMap += "eeeeee   ";
				sapTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/rocketExplosion_prefab", AttachPoint.WeaponSlot);

				var explodeTL = new TimelineData();
				explodeTL.Duration = 2f;
				explodeTL.AsciiMap += "eeeeee   ";
				explodeTL.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/rocketExplosion_prefab", AttachPoint.WeaponSlot);

				ret.Timelines.Add(sapTimeline);
				ret.Timelines.Add(explodeTL);

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.EnergySap);

				return ret;
			}
		}

		public static AbilityData LOWER_ANXIETY_DAMAGE_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 34;
				ret.DoesPropogate = true;
				ret.attributeData.Add( new GameData.AttributeData(
					ActorAttributes.AnxietyDamageScalar.Id, .5f
				));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.AnxietyDamageReductionBuff);

				return ret;
			}
		}

		public static AbilityData SWAP_POSITIONS {
			get {
				var ret = new AbilityData();
				ret.Id = 35;

				ret.spawnableDataId = CharacterDataTable.RAIL_PROJECTILE.Id;
				var fireTimeline = new TimelineData();

				fireTimeline.AsciiMap += "sssssss     ";
				fireTimeline.Duration = .5f;

				fireTimeline.Lookup['s'] = new TimelineData.Point("SFX/Renders/HotRails_fire_1", AttachPoint.Muzzle);
				ret.Timelines.Add(fireTimeline);

				var hitTimeline = new TimelineData();
				hitTimeline.AsciiMap += "eeee";
				hitTimeline.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/enemyTestHit_prefab", AttachPoint.WeaponSlot);
				ret.Timelines.Add(hitTimeline);


				var projectileTL = new TimelineData(3f, true);
				projectileTL.AsciiMap += "eeeee";
				projectileTL.Lookup['e'] = "Projectiles/VFX/railTail_prefab";
				ret.Timelines.Add(projectileTL);


				var wallHit = new TimelineData(2f, false);
				wallHit.AsciiMap += "eeee";
				wallHit.Lookup['e'] = "Projectiles/VFX/railWallHit_prefab";
				ret.Timelines.Add(wallHit);

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

				ret.spawnableDataId = CharacterDataTable.FAT_BLACK_SLUG_PROJECTILE.Id;
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

				var tl = new TimelineData();
				tl.Duration = 1f;
				tl.AsciiMap += "eeeeeee";
				tl.Lookup['e'] = "Projectiles/VFX/LaunchDust_prefab";

				ret.Timelines.Add(tl);

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.LaunchPadBuff);
				return ret;
			}
		}
		
		public static AbilityData STATIONARY_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 38;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.StationaryBuff);
				return ret;
			}
		}
		
		public static AbilityData CURSED_COURAGE_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 39;
				ret.DoesPropogate = true;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.MaxHealth.Id, -50));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.DamageScalar.Id, 1.5f));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponCooldownScalar.Id, .6f));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.CursedCourageBuff);
				return ret;
				
			}
		}
		
		public static AbilityData TRIGGER_FINGERS_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 40;
				ret.DoesPropogate = true;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponCooldownScalar.Id, .7f));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.AttackSpeedBuff);
				return ret;
			}
			
		}
		
		public static AbilityData QUAD_SHOT {
			get {
				var ret = new AbilityData();
				ret.Id = 41;
				ret.name = "quad shot";

				ret.attributeData.Add (new GameData.AttributeData (
					AbilityAttributes.Damage.Id, 1
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

				ret.spawnableDataId = CharacterDataTable.PINK_PROJECTILE.Id;
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
				ret.DoesPropogate = true;
				ret.name = "Low Health Damage Amplifier";
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.DamageScalar.Id, 1f
				));
				
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.LowHealthDamageAmpBuff);
				return ret;
				
			}
		}
		
		public static AbilityData WEAPON_DE_CURSER {
			get {
				var ret = new AbilityData();
				ret.Id = 43;
				ret.DoesPropogate = true;
				return ret;
			}
		}
		
		public static AbilityData WEAPON_CURSE {
			get {
				var ret = new AbilityData();
				ret.Id = 44;
				ret.DoesPropogate = true;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.WeaponCurse);
				return ret;
			}
		}
		public static AbilityData TOWER_ACTOR_ABSORBER {
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
				ret.spawnableDataId = CharacterDataTable.GRENADE_PROJECTILE.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.LaunchGrenade);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.SplashRadius.Id, 2f
				));


				var launch = new TimelineData();
				launch.Duration = 1f;
				launch.AsciiMap += "ssss";
				launch.Lookup['s'] = "SFX/grenadeLaunch";
				ret.Timelines.Add(launch);

				var explosionEffect = new TimelineData();
				explosionEffect.AsciiMap += "eeeeeee";
				explosionEffect.Lookup['e'] = "Projectiles/VFX/rocketExplosion_prefab";
				explosionEffect.Duration = 1f;

				ret.Timelines.Add(explosionEffect);


				return ret;
			}
		}

		public static AbilityData ROOM_UNLOCK_HARDENER {
			get {
				var ret = new AbilityData();
				ret.Id = 47;
				ret.attributeData.Add(
					new GameData.AttributeData(ActorAttributes.RoomUnlockDifficultyIncr.Id, 2)
				);

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.PlayerRunHardenerBuff);
				return ret;
			}
		}

		public static AbilityData SHOP_CHEAPENER_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 48;
				ret.DoesPropogate = true;
				ret.attributeData.Add(
					new GameData.AttributeData(ActorAttributes.ShopPriceScalar.Id, .8f)	
				);
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.ShopCheapenerBuff);
				return ret;
			}
		}

		public static AbilityData KILL_DE_STRESSER_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 49;
				ret.DoesPropogate = true;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.Anxiety.Id, 20));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.KillDeStresserBuff);
				return ret;

			}
		}

		public static AbilityData YEE_HAW_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 50;
				ret.DoesPropogate = true;
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.Speed.Id, 5.2f));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.WeaponCooldownScalar.Id, .7f));
				ret.attributeData.Add(new GameData.AttributeData(ActorAttributes.AnxietyDamageScalar.Id, 3f));

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.YeeHawBuff);
				
				return ret;

			}
		}

		public static AbilityData ROOM_UNLOCK_DROP_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 51;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.RoomClearDropBuff);
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.DropRate.Id, 1f
				));
				return ret;
			}
		}

		public static AbilityData ANXIETY_DAMAGE_ITEM {
			get {
				var ret = new AbilityData();
				ret.Id = 52;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Items.AnxietyDamageAOEItem);

				ret.attributeData.Add(new GameData.AttributeData(AbilityAttributes.AnxietyToDamageScalar.Id, 2f));

				return ret;
			}
		}

		public static AbilityData LIMITED_USE_ITEM_DEBUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 53;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Debuffs.LimitedUseItemDebuff);
				var popTL = new TimelineData();
				popTL.AsciiMap += "eeeeeeee";
				popTL.Duration = 1f;
				popTL.Lookup['e'] = new TimelineData.Point("Projectiles/VFX/ceramicExhausted_prefab", AttachPoint.WeaponSlot);

				ret.Timelines.Add(popTL);
				return ret;
			}
		}


		public static AbilityData SMALL_ADD_MAX_ANXIETY {
			get {
				var ret = new AbilityData();
				ret.Id = 54;

				ret.DoesPropogate = true;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.AddMaxAnxiety);
				
				return ret;
			}
		}

		public static AbilityData NO_ANXIETY_FIRE_SPEED_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 55;
				ret.DoesPropogate = true;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Items.NoAnxietyFireSpeed);
				return ret;
			}
		}


		public static AbilityData DEFAULT_DODGE {
			get {
				var ret = new AbilityData();
				ret.Id = 56;
				ret.DoesPropogate = true;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.DodgeRoll);

				return ret;
			}
		}
		public static AbilityData HIT_ENEMY_FLASH_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 57;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.EnemyFlashOnHitBuff);
				return ret;
			}
		}

		public static AbilityData TOWER_ABSORPTION_TTL {
			get {
				var ret = new AbilityData();
				ret.Id = 58;
				ret.DoesPropogate = false;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.TowerAbsorptionTTLBuff);

				var tl = new TimelineData();
				tl.Duration = 1f;
				tl.AsciiMap += "eeeee";
				tl.AsciiMap += "sssss";
				tl.Lookup['e'] = "WorldFX/TowerAbsorption";
				tl.Lookup['s'] = "SFX/towerAbsorption";
				ret.Timelines.Add(tl);
				return ret;
			}
		}

		public static AbilityData UPGRADEABLE_TRAP_BUFF {
			get {
				var ret = new AbilityData();
				ret.Id = 59;

				var tl = new TimelineData();
				tl.Duration = 2f;
				tl.AsciiMap += "sss";
				tl.AsciiMap += "eee";

				tl.Lookup['s'] = "SFX/trapUpgrade";
				tl.Lookup['e'] = "WorldFX/trapUpgrade";

				ret.Timelines.Add(tl);

				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.UpgradeableTrapBuff);


				return ret;
			}
		}

		public static AbilityData GRENADE_REPEATER {
			get {
				var ret = new AbilityData();
				ret.Id = 60;
				ret.spawnableDataId = CharacterDataTable.GRENADE_PROJECTILE.Id;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.LaunchGrenade);
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.FiresFromJoint.Id, (int)AttachPoint.Muzzle
				));
				ret.attributeData.Add(new GameData.AttributeData(
					AbilityAttributes.SplashRadius.Id, 2f
				));


				var launch = new TimelineData();
				launch.Duration = 1f;
				launch.AsciiMap += "ssss";
				launch.Lookup['s'] = "SFX/grenadeLaunch";
				ret.Timelines.Add(launch);

				var explosionEffect = new TimelineData();
				explosionEffect.AsciiMap += "eeeeeee";
				explosionEffect.Lookup['e'] = "Projectiles/VFX/rocketExplosion_prefab";
				explosionEffect.Duration = 1f;

				ret.Timelines.Add(explosionEffect);


				return ret;
			}
		}

		public static AbilityData CONTROLLER_AIM_ASSIST {
			get {
				var ret = new AbilityData();
				ret.Id = 61;
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.Buffs.ControllerAimAssistBuff);
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.ControllerAimAssist.Id, 30f
				));
				return ret;
			}
		}


		public static AbilityData BIG_HEAL {
			get {
				var ret = new AbilityData();
				ret.Id = 62;
				ret.DoesPropogate = true;
				ret.attributeData.Add( new GameData.AttributeData(
					AbilityAttributes.Damage.Id, -10
				));
				ret.executionScript = typeof(Client.Game.Abilities.Scripts.HealPlayer);
				return ret;
			}
		}
	}
}

