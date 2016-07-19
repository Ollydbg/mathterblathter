using System;
using System.Reflection;
using System.Linq;
using Client.Game.Enums;

namespace Client.Game.Attributes
{
	public partial class ActorAttributes
	{

		static void ActorAttribute() {
			_all = typeof(ActorAttributes).GetFields ()
				.Where (a => a.IsStatic && a.FieldType.IsSubclassOf (typeof(GameAttribute)))
				.Select (a => a.GetValue (null) as GameAttribute)
				.OrderBy (a => a.Id)
				.ToArray();
		}

		private static GameAttribute[] _all;
		public static GameAttribute[] GetAll() {
			return _all;
		}

		public static readonly GameAttributeI Health = new GameAttributeI(1, 100, "health",  0, 1000);
		public static readonly GameAttributeI MaxHealth = new GameAttributeI(2, 100, "max health",  0, 1000);

		public static readonly GameAttributeF Speed = new GameAttributeF(3, .5f, "speed", 0, 10);
		public static readonly GameAttributeF MinJumpPower = new GameAttributeF(4, 0, "jumpHeight", 0, 50);
		public static readonly GameAttributeF SustainedJumpPower = new GameAttributeF(14, 0, "sustained jumping height", 0, 50);
		public static readonly GameAttributeF MaxJumpPower = new GameAttributeF(15, 0, "max jump power", 0, 100); 
		public static readonly GameAttributeI Abilities = new GameAttributeI(5, 0, "abilities",  0 , int.MaxValue);
		public static readonly GameAttributeI Weapons = new GameAttributeI(6, 0, "weapons",  0, 10);
		public static readonly GameAttributeI CurrentWeaponIndex = new GameAttributeI(7, 0, "current weapon index",  0, 10);
		public static readonly GameAttributeF AIDetectionRadius = new GameAttributeF(8, 15, "ai detection radius", 2, 1000);
		public static readonly GameAttributeF GravityScalar = new GameAttributeF(10, 1f, "gravity scalar", -10, 1000);
		public static readonly GameAttributeF JumpSpeedY = new GameAttributeF(11, 8, "rising and falling speed", 0, .5f);
		public static readonly GameAttributeF AirControlScalar = new GameAttributeF(12, .5f, "jumping speed xscalar", 0f, 1f); //<-- Air Control
		public static readonly GameAttributeF MeleeBonusRangePct = new GameAttributeF(13, 1.0f, "Melee Bonus Range Percent", 0f, 1f); //<-- Air Control
		public static readonly GameAttributeI BloodBalance = new GameAttributeI(16, 0, "blood",  0, int.MaxValue);
		public static readonly GameAttributeI BloodBounty = new GameAttributeI(17, 0, "blood bounty",  0, int.MaxValue);
		public static readonly GameAttributeF InteractionRadius = new GameAttributeF(18, 4, "interaction radius", 0, float.MaxValue);
		public static readonly GameAttributeE State = new GameAttributeE(19, (int)ActorState.Alive, "Actor's state",  0, int.MaxValue, typeof(ActorState));
		public static readonly GameAttributeI WeaponCount = new GameAttributeI(20, 0, "Actor's weapon count",  0, int.MaxValue);
		public static readonly GameAttributeB TakesDamage = new GameAttributeB(21, 0, "does this actor take damage?",  0, 1);
		public static readonly GameAttributeI BaseDamage = new GameAttributeI(22, 0, "base damage amount",  0, int.MaxValue);
		public static readonly GameAttributeI PickupItemId = new GameAttributeI(23, 0, "item to give player",  0, int.MaxValue);
		public static readonly GameAttributeF WeaponCooldownScalar = new GameAttributeF(24, 1f, "attack multipler", 0, float.MaxValue);
		public static readonly GameAttributeF Cooldown = new GameAttributeF(25, 1f, "attack speed", 0, float.MaxValue);
		public static readonly GameAttributeF LastFiredTime = new GameAttributeF(26, float.MinValue, "last fired time", float.MinValue, float.MaxValue);
		public static readonly GameAttributeB PassesThroughPlatforms = new GameAttributeB(27, 0, "Passes Through Platforms", 0, 1);
		public static readonly GameAttributeI MinLevelSpawn = new GameAttributeI(28, 0, "MinimumElevationForSpawn", int.MinValue, int.MaxValue);
		public static readonly GameAttributeI MaxLevelSpawn = new GameAttributeI(29, 0, "MaximumElevationForSpawn", int.MinValue, int.MaxValue);
		public static readonly GameAttributeF DropRate = new GameAttributeF(30, .04f, "DropRate", 0, float.MaxValue);
		public static readonly GameAttributeF FallFireVelocity = new GameAttributeF(31, 10f, "FallFireVelocity", float.MinValue, float.MaxValue);
		public static readonly GameAttributeF Inaccuracy = new GameAttributeF(32, 0f, "inaccuracy", float.MinValue, float.MaxValue);
		public static readonly GameAttributeI MaxWeapons = new GameAttributeI(33, 2, "maxWeapons", 0, int.MaxValue);
		public static readonly GameAttributeF DropQuality = new GameAttributeF(34, 1, "dropQuality", 0, float.MaxValue);
		public static readonly GameAttributeE DropType = new GameAttributeE(35, 0, "DropType", 0, int.MaxValue, typeof(Client.Game.Data.PickupType));
		public static readonly GameAttributeF AIScanDegrees = new GameAttributeF(36, 90, "AiScanDegrees", 0, 360);
		public static readonly GameAttributeI Anxiety = new GameAttributeI(37, int.MaxValue, "energy", 0, int.MaxValue);
		public static readonly GameAttributeI MaxAnxiety = new GameAttributeI(38, int.MaxValue, "max energy", 0, int.MaxValue);
		public static readonly GameAttributeI AnxietyRegen = new GameAttributeI(39, 2, "energy regen", 0, int.MaxValue);
		public static readonly GameAttributeI WeaponAnxietyCost = new GameAttributeI(40, 10, "energy cost", 0, int.MaxValue); 
		public static readonly GameAttributeI ShopkeeperInventory = new GameAttributeI(41, -1, "inventory", 0, int.MaxValue);
		public static readonly GameAttributeF DamageScalar = new GameAttributeF(42, 1, "damage scalar", float.MinValue, float.MinValue);
		public static readonly GameAttributeF AIAttackDelay = new GameAttributeF(43, 1, "waitThenAttackDelay", 0, float.MaxValue); 
		public static readonly GameAttributeF AnxietyDamageScalar = new GameAttributeF(44, 1f, "anxietyDamageScalar", 0, float.MaxValue);
		public static readonly GameAttributeF KnockbackForce = new GameAttributeF(45, 0f, "knockback force", 0, float.MaxValue);
		public static readonly GameAttributeI ShopsSkipped = new GameAttributeI(46, 0, "shops skipped", 0, int.MaxValue);
		public static readonly GameAttributeE WeaponFlags = new GameAttributeE(47, 0, "weapon flags", 0, int.MaxValue, typeof(WeaponFlags));
		public static readonly GameAttributeI WaveDifficulty = new GameAttributeI(48, 1, "run difficulty", 0, int.MaxValue);
		public static readonly GameAttributeI RoomUnlockDifficultyIncr = new GameAttributeI(49, 0, "difficulty increment", 0, int.MaxValue);
		public static readonly GameAttributeF ShopPriceScalar = new GameAttributeF(50, 1f, "shop price scalar", 0f, float.MaxValue);
		public static readonly GameAttributeI ActiveItemId = new GameAttributeI(51, 0, "ActiveItem Id",  int.MinValue, int.MaxValue);
		public static readonly GameAttributeF ItemActivationTime = new GameAttributeF(52, -10f, "Last used time", 0, float.MaxValue);
		public static readonly GameAttributeF ItemCooldownScalar = new GameAttributeF(53, 1f, "Item cooldown scalar", 0, float.MaxValue);
		public static readonly GameAttributeI Charges = new GameAttributeI(54, -1, "charges", -1, int.MaxValue);
		public static readonly GameAttributeF ProjectileLifespan = new GameAttributeF(55, 5f, "projectileLifespan", 0, float.MaxValue);
		public static readonly GameAttributeF CameraShakeForce = new GameAttributeF(56, .1f, "kick force", 0, float.MaxValue);
		public static readonly GameAttributeF ProjectileBeamWidth = new GameAttributeF(57, 1f, "projectileBeamWidth", 0, float.MaxValue);
		public static readonly GameAttributeF CurseProbability = new GameAttributeF(58, 0f, "curseProbability", 0, 1);
		public static readonly GameAttributeF MeleeRange = new GameAttributeF(59, 1f, "melee range", 0, float.MaxValue);
		public static readonly GameAttributeF MeleeWidth = new GameAttributeF(60, 1f, "melee width", 0, float.MaxValue);
		public static readonly GameAttributeB ReflectsProjectiles= new GameAttributeB(61, 0, "reflect projectiles", 0, 1);
		public static readonly GameAttributeF ExplosionRadius = new GameAttributeF(62, 1f, "explosion radius", 0, float.MaxValue);
		public static readonly GameAttributeF DodgeRollDistance = new GameAttributeF(63, 1f, "roll distance", 0, 10f);
		public static readonly GameAttributeF DodgeRollSpeed = new GameAttributeF(64, 1f, "roll speed", 0, 10f);
		public static readonly GameAttributeF TimeSkipDuration = new GameAttributeF(65, .025f, "on hit time skip", 0, 1f);
		public static readonly GameAttributeF TimeSkipAmount = new GameAttributeF(66, .05f, "on hit time skip to", 0, 1f);
		public static readonly GameAttributeF AIActivationRange = new GameAttributeF(67, 40f, "ai weapon activation range", 0, float.MaxValue);
		public static readonly GameAttributeI JumpBoostFrameThresh = new GameAttributeI(68, 6, "jump boost threshold in frames", 0, int.MaxValue);
		public static readonly GameAttributeF ProjectileSpeed = new GameAttributeF(69, 5f, "projectileSpeed", float.MinValue, float.MaxValue);
		public static readonly GameAttributeB ProjectileDestroyOnGeometry = new GameAttributeB(70, 1, "projectile destroys on geometry", 0, 1);	
		public static readonly GameAttributeF TowerAbsorptionTTL = new GameAttributeF(71, 6f, "absorptionTTL", 0, float.MaxValue);
		public static readonly GameAttributeI DataIds = new GameAttributeI(72, 0, "dataIds", 0, int.MaxValue);
		public static readonly GameAttributeI RoomDifficulty = new GameAttributeI(73, 0, "room difficulty", 0, int.MaxValue);
		public static readonly GameAttributeF ZoneUpdateRate = new GameAttributeF(74, .1f, "Zone tick rate", .01f, float.MaxValue);
		public static readonly GameAttributeF ControllerAimAssist = new GameAttributeF(75, 0f, "ControllerAimAssist", 0, 90f, "controller aim slop tolerance in degrees");
		public static readonly GameAttributeB UsesAnxiety = new GameAttributeB(76, 0, "usesAnxiety", 0, 1);
		public static readonly GameAttributeI JumpBoostFrameFloor = new GameAttributeI(77, 0, "jumpBoostFramesFloor", 0, int.MaxValue);
		public static readonly GameAttributeF AIIdleRange = new GameAttributeF(78, .5f, "ai idle range", 0f, float.MaxValue);
		public static readonly GameAttributeF AISleepTime = new GameAttributeF(79, 1f, "ai sleep time", 0, float.MaxValue);
		public static readonly GameAttributeF AILockOnTime = new GameAttributeF(80, .5f, "ai lock on time", 0, float.MaxValue);
		public static readonly GameAttributeI TeamID = new GameAttributeI(0, 0, "teamId", 0, 10);
	}
}

