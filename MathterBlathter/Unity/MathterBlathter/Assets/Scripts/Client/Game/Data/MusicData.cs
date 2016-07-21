using System;

namespace Client.Game.Data
{
	public class MusicData : GameData
	{
		public MusicData ()
		{
		}

		public String Resource;
	}

	public static class MusicDataTable {

		public static MusicData TITLE_THEME {
			get {
				var ret = new MusicData();
				ret.Resource = "Music/theme";
				return ret;
			}
		}

		public static MusicData RUN_MUSIC {
			get {
				var ret = new MusicData();
				ret.Resource = "Music/intro";
				return ret;
			}
		}

	}
}

