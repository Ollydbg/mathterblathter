using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Data
{
	public class ParallaxData : GameData
	{
		public static string materialPath = "Backgrounds/backgroundMat";
		public bool InRandomPool;
		public enum Layer {
			RoomWall,
			RoomForeground,
			ExtremeForeground,
		}

		public Dictionary<Layer, string> Layers = new Dictionary<Layer, string>();

	}

	public static class ParallaxDataTable {

		
		private static List<ParallaxData> _all;
		static void StaticInit() {
			_all = typeof(ParallaxDataTable).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as ParallaxData)
				.ToList();
		}

		public static List<ParallaxData> GetAll() {
			
			if (_all == null) {
				StaticInit();
			}

			return _all;

		}


		public static ParallaxData OUTDOORS {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = null;
				return ret;
			}

		}


		public static ParallaxData INDOORS {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = "Backgrounds/background0";
				ret.InRandomPool = true;
				return ret;

			}
				
		}


		public static ParallaxData SQUARES {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = "Backgrounds/background1";
				ret.InRandomPool = true;
				return ret;
			}

		}


		public static ParallaxData STRIPES {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = "Backgrounds/background2";
				ret.InRandomPool = true;
				return ret;
			}

		}

		public static ParallaxData ABSTRACT {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = "Backgrounds/background3";
				ret.InRandomPool = true;
				return ret;
			}
		}

		public static ParallaxData LIGHTNING {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = "Backgrounds/background4";
				ret.InRandomPool = true;
				return ret;
			}
		}

	}


}

