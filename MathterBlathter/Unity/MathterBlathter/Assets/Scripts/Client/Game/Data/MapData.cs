using System;
using System.Collections.Generic;

namespace Client.Game.Data
{
	public class MapData : GameData
	{
		public string ResourcePath;

		public int MaxRooms;
		
		public float ReadScale;

		public List<ZoneData> Zones = new List<ZoneData>();

		public MapData ()
		{
		}

	}
	
	public class ZoneData : GameData 
	{
		public String Name;
		public List<Requirement> Requirements = new List<Requirement>();
		
		public int MinElevation;
		public int MaxElevation;
		
		public int MinX = int.MinValue;
		
		public int MaxX = int.MaxValue;
		
		public class Requirement {
			public RoomType RoomType;
			public int Amount;
			public Occurance Occurance;
			public int RoomId = -1;

			public bool RoomSpecified {
				get {
					return RoomId != -1;
				}
			}

			public Requirement(RoomType roomType, int amount, Occurance occurance) {
				this.RoomType = roomType;
				this.Amount = amount;
				this.Occurance = occurance;
			}
			public Requirement(RoomData room, int amount, Occurance occurance) {
				this.RoomId = room.Id;
				this.Amount = amount;
				this.Occurance = occurance;
			}
		}
		
		public enum Occurance {
			Guaranteed,
			Optional,
			Never	
		
		}
	}
}

