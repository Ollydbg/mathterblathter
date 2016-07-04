﻿using System;
using System.Collections.Generic;

namespace Client.Game.Data
{
	public class MapData : GameData
	{
		public string ResourcePath;

		public float ReadScale;

		public List<ZoneData> Zones = new List<ZoneData>();

		public int MaxRooms {
			get {
				int max = 0;
				Zones.ForEach(p => max += p.MaxRooms);
				return max;
			}
		}

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
		public int MaxRooms;
		public int MinX = int.MinValue;
		public int MaxX = int.MaxValue;

		public struct Requirement {
			public RoomType RoomType;
			public int Amount;
			public Occurance Occurance;
			public int RoomId;

			public bool RoomSpecified {
				get {
					return RoomId != -1;
				}
			}

			public Requirement(RoomType roomType, int amount, Occurance occurance) {
				this.RoomType = roomType;
				this.Amount = amount;
				this.Occurance = occurance;
				RoomId = -1;
			}

			public Requirement(RoomData room, int amount, Occurance occurance) {
				this.RoomId = room.Id;
				this.Amount = amount;
				this.Occurance = occurance;
				this.RoomType = room.Type;
			}

			public bool Accepts(RoomData roomdata) {
				if(RoomSpecified) 
					return roomdata.Id == RoomId;

				return (roomdata.Type & RoomType) == RoomType;
			}


		}
		
		public enum Occurance {
			Guaranteed,
			Optional,
			Never	
		
		}
	}
}

