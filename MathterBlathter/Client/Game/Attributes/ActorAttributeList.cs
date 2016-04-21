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
		public static readonly GameAttributeF PickupRadius = new GameAttributeF(18, 4, "pickup radius", 0, float.MaxValue);
		public static readonly GameAttributeE State = new GameAttributeE(19, (int)ActorState.Alive, "Actor's state",  0, int.MaxValue, typeof(ActorState));
		public static readonly GameAttributeI WeaponCount = new GameAttributeI(20, 0, "Actor's weapon count",  0, int.MaxValue);
		public static readonly GameAttributeB TakesDamage = new GameAttributeB(21, 0, "does this actor take damage?",  0, 1);
		public static readonly GameAttributeI BaseDamage = new GameAttributeI(22, 0, "base damage amount",  0, int.MaxValue);
		public static readonly GameAttributeI PickupItemId = new GameAttributeI(23, 0, "item to give player",  0, int.MaxValue);
	}
}

