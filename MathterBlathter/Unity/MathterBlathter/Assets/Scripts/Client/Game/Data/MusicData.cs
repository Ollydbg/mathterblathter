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

	public static class MockMusicData {

		public static MusicData TITLE_THEME {
			get {
				var ret = new MusicData();
				ret.Resource = "Music/theme";
				return ret;
			}
		}

	}
}

