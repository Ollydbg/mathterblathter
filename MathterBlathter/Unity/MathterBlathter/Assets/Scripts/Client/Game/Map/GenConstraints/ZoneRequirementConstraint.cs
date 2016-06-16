using System;
using Client.Game.Data;
using Client.Game.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game.Map.GenConstraints
{
	//makes sure there's a store every 100 ft
	public class ZoneRequirementConstraint : IGenConstraint
	{
		public ZoneRequirementConstraint ()
		{
		}

		public Dictionary<ZoneData, ZoneRecord> zoneRecords = new Dictionary<ZoneData, ZoneRecord>();

		#region GenConstraint implementation

		MapData mapData;

		public void InitWithMap (MapData mapData)
		{
			this.mapData = mapData;
			mapData.Zones.ForEach(zd => zoneRecords.Add(zd, new ZoneRecord()));
		}

		public bool Check (RoomData data, int x, int y, int width, int height)
		{

			var zd = MapUtils.ZoneForXY(x, y, mapData);

			return true;
		}

		public void Commit (RoomData data, int x, int y, int width, int height)
		{
			var zd = MapUtils.ZoneForXY(x, y, mapData);
			zoneRecords[zd].Record(data.Type);
		}

		#endregion
	}

	public class ZoneRecord {
		int numRoomTypes = 0;
		private Dictionary<RoomType, int> records = new Dictionary<RoomType, int>();
		public ZoneRecord() {
			
			numRoomTypes = Enum.GetNames(typeof(RoomType)).Length;
			for( int i = 0; i < numRoomTypes; i++ ) {
				records[(RoomType)i] = 0;
			}
		}


		public bool IsSet(RoomType type) {
			return true;
		}

		public void Record(RoomType flags) {
			for(int i = 0; i < numRoomTypes; i++ ) {
				int mask = (int)flags;

				var flag = 2 << i;

				var flagSet = (mask & flag) == flag;
				if(flagSet) {
					records[(RoomType)i]++;
				}

			}
		}

	}
}

