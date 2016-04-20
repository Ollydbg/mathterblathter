using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using Client.Game.Core;
using Client.Game.Actors;
using Client.Game.Enums;
using UnityEngine;

namespace Client.Game.Map
{
	using DoorLinkMapping = Dictionary<RoomData.Link, DoorActor>;
	using Game = Game.Core.Game;

	public class RoomComparer : IComparer<RoomData>
	{
		#region IComparer implementation
		public int Compare (RoomData x, RoomData y)
		{
			if(x.SortOrder < y.SortOrder) {
				return -1;
			} else if( x.SortOrder == y.SortOrder) {
				return CompareMaxElevation(x, y);
			} else {
				return 1;
			}
		}
		#endregion

		private int CompareMinElevation(RoomData x, RoomData y) {
			if(x.MinElevation > y.MinElevation) {
				return 1;
			} else if( x.SortOrder == y.SortOrder) {
				return CompareRoomId(x, y);
			} else {
				return -1;
			}
		}

		private int CompareMaxElevation(RoomData x, RoomData y) {
			if( x.MaxElevation < y.MaxElevation) {
				return -1;
			} else if(x.MaxElevation == y.MaxElevation) {
				return CompareRoomId(x, y);
			} else {
				return 1;
			}
		}

		private int CompareRoomId(RoomData x, RoomData y) {
			return x.Id.CompareTo(y.Id);
		}
	}

}
