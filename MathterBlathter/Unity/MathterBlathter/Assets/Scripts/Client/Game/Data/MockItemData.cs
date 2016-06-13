namespace Client.Game.Data
{
	public static partial class MockActorData
	{
        public static CharacterData AOE_FREEZE_ITEM {
            get {
                var ret = new CharacterData();
                ret.Id = 3000;
                ret.Availability = Availability.None;
                return ret;
            }
        }

        public static CharacterData WEAPON_POISONER_ITEM {
            get {
                var ret = new CharacterData();
                ret.Id = 3001;

                ret.Availability = Availability.None;
                return ret;
            }
        }

        public static CharacterData TRAP_MALFUNCTIONER_ITEM {
            get {
                var ret = new CharacterData();
                ret.Id = 3002;

                ret.Availability = Availability.None;
                return ret;
            }
        }
        public static CharacterData WEAPON_THROWER_ITEM {
            get {
                var ret = new CharacterData();
                ret.Id = 3003;

                ret.Availability = Availability.None;
                return ret;
            }
        }

        public static CharacterData ANXIETY_DAMAGE_AOE_ITEM {
            get {
                var ret = new CharacterData();
                ret.Id = 3004;

                ret.Availability = Availability.None;
                return ret;
            }
        }

    }
}