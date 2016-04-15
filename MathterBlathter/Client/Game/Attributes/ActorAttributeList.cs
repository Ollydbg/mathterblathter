using System;
using System.Reflection;
using System.Linq;

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

		public static readonly GameAttributeI Health = new GameAttributeI(1, 100, "health", GameAttributeEncoding.Int, 0, 1000);
		public static readonly GameAttributeI MaxHealth = new GameAttributeI(2, 100, "max health", GameAttributeEncoding.Int, 0, 1000);

		public static readonly GameAttributeF Speed = new GameAttributeF(3, .5f, "speed", GameAttributeEncoding.Float16, 0, 10);
		public static readonly GameAttributeF JumpPower = new GameAttributeF(4, 1f, "jumpHeight", GameAttributeEncoding.Float16, 0, 50);
		public static readonly GameAttributeI Abilities = new GameAttributeI(5, 0, "abilities", GameAttributeEncoding.Int, 0 , int.MaxValue);
		public static readonly GameAttributeI Weapons = new GameAttributeI(6, 0, "weapons", GameAttributeEncoding.Int, 0, int.MaxValue);
		public static readonly GameAttributeI CurrentWeaponIndex = new GameAttributeI(7, 0, "current weapon index", GameAttributeEncoding.Int, 0, 10);
		public static readonly GameAttributeF AIDetectionRadius = new GameAttributeF(8, 15, "ai detection radius", GameAttributeEncoding.Float16, 2, 1000);
		public static readonly GameAttributeF GravityScalar = new GameAttributeF(10, -1.8f, "gravity scalar", GameAttributeEncoding.Float16, -10, 1000);
		public static readonly GameAttributeF JumpSpeedY = new GameAttributeF(11, 8, "rising and falling speed", GameAttributeEncoding.Float16, 0, .5f);
		public static readonly GameAttributeF JumpSpeedXScalar = new GameAttributeF(12, .5f, "jumping speed xscalar", GameAttributeEncoding.Float16, 0f, 1f); //<-- Air Control
	}
}

