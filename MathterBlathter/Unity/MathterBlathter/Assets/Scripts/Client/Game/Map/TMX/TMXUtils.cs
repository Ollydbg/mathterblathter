using System;
using TiledSharp;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game.Map.TMX
{
	public static class TMXUtils
	{

		private static Dictionary<String, String> Defaults = new Dictionary<string, string>() {
			{Constants.Facing, "UP"}
		};
		

		public static string TryGetProperty(this TmxObjectGroup.TmxObject obj, string prop) {
			if(obj.Properties.ContainsKey(prop)) {
				return obj.Properties[prop];
			}

			return Defaults[prop];
		}

		public static Vector3 FacingDirection (string facing)
		{
			switch (facing.ToLower()) {
				
				case "down":
					return Vector3.down;
				case "left":
					return Vector3.left;
				case "right":
					return Vector3.right;
				default:
				case "up" :
					return Vector3.up;

			}


		}
	}
}

