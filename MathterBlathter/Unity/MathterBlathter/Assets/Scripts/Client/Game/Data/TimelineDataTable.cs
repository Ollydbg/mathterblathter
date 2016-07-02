using System;

namespace Client.Game.Data
{
	public static class TimelineDataTable
	{
	
		public static TimelineData SMALL_SPAWN_TL {
			get {
				var ret = new TimelineData();
				ret.Duration = 1f;
				ret.AsciiMap += "eeeee   ";
				ret.AsciiMap += "sssss   ";
				ret.Lookup['e'] = "WorldFX/SmallSpawnPortal";
				ret.Lookup['s'] = "SFX/warpIn";

				return ret;
			}
		}


		public static TimelineData SMALL_ACTOR_ENTERED_TL {
			get {
				var ret = new TimelineData();
				ret.Duration = 5f;
				ret.AsciiMap += "eeeee   ";
				//ret.AsciiMap += "sssss   ";
				ret.Lookup['e'] = "WorldFX/ActorEntered";
				//ret.Lookup['s'] = "SFX/actorEntered";

				return ret;
			}
		}

	}
}

