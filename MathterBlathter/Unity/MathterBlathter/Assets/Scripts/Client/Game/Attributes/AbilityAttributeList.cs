using System;
using System.Reflection;
using System.Linq;
using Client.Game.Enums;

namespace Client.Game.Attributes
{
	public partial class AbilityAttributes
	{

		private static int OFFSET = 2<<8;

		static void AbilityAttribute() {
			_all = typeof(AbilityAttributes).GetFields ()
				.Where (a => a.IsStatic && a.FieldType.IsSubclassOf (typeof(GameAttribute)))
				.Select (a => a.GetValue (null) as GameAttribute)
				.OrderBy (a => a.Id)
				.ToArray();
		}

		private static GameAttribute[] _all;
		public static GameAttribute[] GetAll() {
			return _all;
		}


		//THIS IS DUMB, AND THEY SHOULD ALL BE MOVED INTO ACTORATTRIBUTELIST
		public static readonly GameAttributeF Duration = new GameAttributeF(OFFSET + 1, 2f, "duration", 0, float.MaxValue);
		public static readonly GameAttributeF Cooldown = new GameAttributeF(OFFSET + 2, 1f, "cooldown", 0, float.MaxValue);
		public static readonly GameAttributeI Damage = new GameAttributeI(OFFSET + 3, 10, "damage", int.MinValue, int.MaxValue);
		public static readonly GameAttributeF MeleeRange = new GameAttributeF(OFFSET + 4, 10, "melee range", 0, float.MaxValue);
		public static readonly GameAttributeF ProjectileSpeed = new GameAttributeF(OFFSET + 5, 2, "projectile speed", 0, int.MaxValue);
		public static readonly GameAttributeE FiresFromJoint = new GameAttributeE(OFFSET + 6, 0, "weapon attach point", 0, int.MaxValue, typeof(AttachPoint));
		public static readonly GameAttributeI ProjectileCount = new GameAttributeI(OFFSET + 7, 1, "projectile count for repeated weapons", 0, 100);
		public static readonly GameAttributeF ProjectileSpread = new GameAttributeF(OFFSET + 8, 1f, "spread degrees for repeated weapons", 0, 180f); 
		public static readonly GameAttributeF ZoneDPS = new GameAttributeF(OFFSET + 9, 0, "zone damage per second", float.MinValue, float.MaxValue);
		public static readonly GameAttributeF ZoneUpdateRate = new GameAttributeF(OFFSET + 10, .5f, "zone update rate", 0, float.MaxValue);
		public static readonly GameAttributeF RepeatDelay = new GameAttributeF(OFFSET + 11, .1f, "repeatDelay", 0, float.MaxValue);
		public static readonly GameAttributeI RepeatAmount = new GameAttributeI(OFFSET + 12, 0, "repeatCount", 0, 10);
		public static readonly GameAttributeF SplashRadius = new GameAttributeF(OFFSET + 13, 0f, "splashRadius", 0, float.MaxValue);
		public static readonly GameAttributeF ProjectileAccel = new GameAttributeF(OFFSET + 14, 0f, "projectileAcceleration", float.MinValue, float.MaxValue);
		public static readonly GameAttributeF AimAssistRadius = new GameAttributeF(OFFSET + 15, 1f, "AimAssist", 0, float.MaxValue);
		public static readonly GameAttributeF SpeedBoost = new GameAttributeF(OFFSET + 16, 0f, "SpeedBoost", float.MinValue, float.MaxValue);
		public static readonly GameAttributeF MaxJumpPower = new GameAttributeF(OFFSET + 15, 0, "max jump power", 0, 100); 
		public static readonly GameAttributeF FallDamageThreshold = new GameAttributeF(OFFSET + 16, 0, "fall damage threshold", 0, float.MaxValue);
		public static readonly GameAttributeI EnergyCost = new GameAttributeI(OFFSET + 17, 10, "energy cost", 0, int.MaxValue); 
		public static readonly GameAttributeF EnergyRegenScalar = new GameAttributeF(OFFSET + 18, 2f, "energyRegenScalar", 0, float.MaxValue);
		public static readonly GameAttributeF EnergyRegenBoostDelay = new GameAttributeF(OFFSET + 19, 4f, "regenBoostDelay", 0, float.MaxValue);
	}
}

