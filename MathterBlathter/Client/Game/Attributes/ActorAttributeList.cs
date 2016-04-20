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

		public static readonly GameAttributeI Health = new GameAttributeI(1, 100, "health", GameAttributeEncoding.Int, 0, 1000);
		public static readonly GameAttributeI MaxHealth = new GameAttributeI(2, 100, "max health", GameAttributeEncoding.Int, 0, 1000);

		public static readonly GameAttributeF Speed = new GameAttributeF(3, .5f, "speed", GameAttributeEncoding.Float16, 0, 10);
		public static readonly GameAttributeF MinJumpPower = new GameAttributeF(4, 0, "jumpHeight", GameAttributeEncoding.Float16, 0, 50);
		public static readonly GameAttributeF SustainedJumpPower = new GameAttributeF(14, 0, "sustained jumping height", GameAttributeEncoding.Float16, 0, 50);
		public static readonly GameAttributeF MaxJumpPower = new GameAttributeF(15, 0, "max jump power", GameAttributeEncoding.Float16, 0, 100); 
		public static readonly GameAttributeI Abilities = new GameAttributeI(5, 0, "abilities", GameAttributeEncoding.Int, 0 , int.MaxValue);
		public static readonly GameAttributeI Weapons = new GameAttributeI(6, 0, "weapons", GameAttributeEncoding.Int, 0, 10);
		public static readonly GameAttributeI CurrentWeaponIndex = new GameAttributeI(7, 0, "current weapon index", GameAttributeEncoding.Int, 0, 10);
		public static readonly GameAttributeF AIDetectionRadius = new GameAttributeF(8, 15, "ai detection radius", GameAttributeEncoding.Float16, 2, 1000);
		public static readonly GameAttributeF GravityScalar = new GameAttributeF(10, 1f, "gravity scalar", GameAttributeEncoding.Float16, -10, 1000);
		public static readonly GameAttributeF JumpSpeedY = new GameAttributeF(11, 8, "rising and falling speed", GameAttributeEncoding.Float16, 0, .5f);
		public static readonly GameAttributeF AirControlScalar = new GameAttributeF(12, .5f, "jumping speed xscalar", GameAttributeEncoding.Float16, 0f, 1f); //<-- Air Control
		public static readonly GameAttributeF MeleeBonusRangePct = new GameAttributeF(13, 1.0f, "Melee Bonus Range Percent", GameAttributeEncoding.Float16, 0f, 1f); //<-- Air Control
		public static readonly GameAttributeI BloodBalance = new GameAttributeI(16, 0, "blood", GameAttributeEncoding.Int, 0, int.MaxValue);
		public static readonly GameAttributeI BloodBounty = new GameAttributeI(17, 0, "blood bounty", GameAttributeEncoding.Int, 0, int.MaxValue);
		public static readonly GameAttributeF PickupRadius = new GameAttributeF(18, 4, "pickup radius", GameAttributeEncoding.Float16, 0, float.MaxValue);
		public static readonly GameAttributeE State = new GameAttributeE(19, (int)ActorState.Alive, "Actor's state", GameAttributeEncoding.Int, 0, int.MaxValue, typeof(ActorState));
		public static readonly GameAttributeI WeaponCount = new GameAttributeI(20, 0, "Actor's weapon count", GameAttributeEncoding.Int, 0, int.MaxValue);
		public static readonly GameAttributeB TakesDamage = new GameAttributeB(21, 0, "does this actor take damage?", GameAttributeEncoding.Int, 0, 1);
	}
}

