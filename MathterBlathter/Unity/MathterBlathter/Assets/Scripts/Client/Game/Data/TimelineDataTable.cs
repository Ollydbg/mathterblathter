using System;

namespace Client.Game.Data
{
	public static class TimelineDataTable
	{
	
		public static TimelineData SMALL_SPAWN_TL {
			get {
				var ret = new TimelineData();
				ret.Duration = 1.4f;
				ret.AsciiMap += "eeeee   ";
				ret.Lookup['e'] = "WorldFX/SmallSpawnPortal";
				return ret;
			}
		}

	}
}

