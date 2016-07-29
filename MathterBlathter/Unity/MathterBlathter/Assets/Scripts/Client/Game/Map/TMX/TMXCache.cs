using System;
using Client.Game.Data;
using TiledSharp;
using System.Collections.Generic;

namespace Client.Game.Map.TMX
{
	public static class TMXCache
	{

		private static Dictionary<string, TmxMap> cache = new Dictionary<string, TmxMap>();

		public static TmxMap Get(RoomData data) {

			TmxMap map = null;

			if(!cache.TryGetValue(data.TMXResource, out map)) {
				map = new TmxMap("Assets/Resources/" + data.TMXResource);
				cache[data.TMXResource] = map;
				
			}

			return map;


		}

	}
}

