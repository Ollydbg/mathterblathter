using System;
using System.Collections.Generic;

namespace Client.Game.Data
{
	public class ParallaxData : GameData
	{
		public static string materialPath = "Backgrounds/backgroundMat";

		public enum Layer {
			RoomWall,
			RoomForeground,
			ExtremeForeground,
		}

		public Dictionary<Layer, string> Layers = new Dictionary<Layer, string>();

	}

	public static class ParallaxDataTable {




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
				return ret;
			}
				
		}


		public static ParallaxData SQUARES {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = "Backgrounds/background1";
				return ret;
			}

		}


		public static ParallaxData STRIPES {
			get {
				var ret = new ParallaxData();
				ret.Layers[ParallaxData.Layer.RoomWall] = "Backgrounds/background2";
				return ret;
			}

		}

	}


}

