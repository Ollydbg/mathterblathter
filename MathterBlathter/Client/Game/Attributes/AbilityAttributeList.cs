using System;
using System.Reflection;
using System.Linq;
using Client.Game.Enums;

namespace Client.Game.Attributes
{
	public partial class AbilityAttributes
	{

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

		public static readonly GameAttributeF Duration = new GameAttributeF(1, 2f, "duration", 0, float.MaxValue);
		public static readonly GameAttributeF Cooldown = new GameAttributeF(2, 1f, "cooldown", 0, float.MaxValue);
		public static readonly GameAttributeI Damage = new GameAttributeI(3, 10, "damage", int.MinValue, int.MaxValue);
		public static readonly GameAttributeF MeleeRange = new GameAttributeF(4, 10, "melee range", 0, float.MaxValue);
		public static readonly GameAttributeF ProjectileSpeed = new GameAttributeF(5, 2, "projectile speed", 0, int.MaxValue);
		public static readonly GameAttributeE FiresFromJoint = new GameAttributeE(6, 0, "weapon attach point", 0, int.MaxValue, typeof(AttachPoint));
		public static readonly GameAttributeI ProjectileCount = new GameAttributeI(7, 1, "projectile count for repeated weapons", 0, 100);
		public static readonly GameAttributeF ProjectileSpread = new GameAttributeF(8, 1f, "spread degrees for repeated weapons", 0, 180f); 
		public static readonly GameAttributeF ZoneDPS = new GameAttributeF(9, 0, "zone damage per second", float.MinValue, float.MaxValue);
		public static readonly GameAttributeF ZoneUpdateRate = new GameAttributeF(10, .5f, "zone update rate", 0, float.MaxValue);
		public static readonly GameAttributeF RepeatDelay = new GameAttributeF(11, .1f, "repeatDelay", 0, float.MaxValue);
		public static readonly GameAttributeI RepeatAmount = new GameAttributeI(12, 0, "repeatCount", 0, 10);
		public static readonly GameAttributeF SplashRadius = new GameAttributeF(13, 0f, "splashRadius", 0, float.MaxValue);
		public static readonly GameAttributeF ProjectileAccel = new GameAttributeF(14, 0f, "projectileAcceleration", 0, int.MaxValue);
		public static readonly GameAttributeF AimAssistRadius = new GameAttributeF(15, 1f, "AimAssist", 0, int.MaxValue);
	}
}

