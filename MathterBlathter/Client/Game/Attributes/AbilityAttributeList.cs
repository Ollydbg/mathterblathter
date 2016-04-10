using System;
using System.Reflection;
using System.Linq;

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

		public static readonly GameAttributeF Duration = new GameAttributeF(1, 2f, "duration", GameAttributeEncoding.Float16, 0, float.MaxValue);
		public static readonly GameAttributeF Cooldown = new GameAttributeF(2, 1f, "cooldown", GameAttributeEncoding.Float16, 0, float.MaxValue);
		public static readonly GameAttributeI Damage = new GameAttributeI(3, 10, "damage", GameAttributeEncoding.Int, 0, int.MaxValue);
		public static readonly GameAttributeF MeleeRange = new GameAttributeF(4, 10, "melee range", GameAttributeEncoding.Float16, 0, float.MaxValue);

	}
}

