using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Data
{
	public class MusicData : GameData
	{
		public MusicData ()
		{
		}

		public String Resource;

		public bool RunMusic;

	}

	public static class MusicDataTable {


		private static Dictionary<int, MusicData> _all;
		static void StaticInit() {
			_all = typeof(MusicDataTable).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as MusicData)
				.ToDictionary(p => p.Id, p=>p);

		}

		public static List<MusicData> GetAll() {
			if(_all == null) StaticInit();
			return _all.Values.ToList();
		}

		public static MusicData CARPENTER_THEME {
			get {
				var ret = new MusicData();
				ret.Id = 1;
				ret.Resource = "Music/TheCarptenter";
				ret.RunMusic = true;
				return ret;
			}
		}

		public static MusicData STRANGER_THEME {
			get {
				var ret = new MusicData();
				ret.Id = 2;
				ret.Resource = "Music/StrangerTheme";
				ret.RunMusic = true;
				return ret;
			}
		}

		public static MusicData SHOP_MUSIC {
			get {
				var ret = new MusicData();
				ret.Id = 3;
				ret.Resource = "Music/ShopMusic";
				return ret;
			}
		}

		public static MusicData RUN_MUSIC {
			get {
				var ret = new MusicData();
				ret.Id = 4;
				ret.Resource = "Music/intro";
				ret.RunMusic = true;
				return ret;
			}
		}

	}
}

