using System;

namespace Client.Game.Enums
{
	
	public enum AbilitySlots
	{
		Melee,
		Ranged,
		MeleeTwoHanded,
		RangedTwoHanded,
		Death,
		Pickup,
	}
	
	[FlagsAttribute]
	public enum WeaponFlags {
		Melee,
		Ranged,
		OneHanded,
		TwoHanded
	}
	public class WeaponFlagsUtil {
		public static WeaponFlags MELEE_ONE_HANDED = WeaponFlags.Melee | WeaponFlags.OneHanded;
		public static WeaponFlags MELEE_TWO_HANDED = WeaponFlags.Melee | WeaponFlags.TwoHanded;
	
		public static WeaponFlags RANGED_ONE_HANDED = WeaponFlags.Ranged | WeaponFlags.OneHanded;
		public static WeaponFlags RANGED_TWO_HANDED = WeaponFlags.Ranged | WeaponFlags.TwoHanded;
	}
}

