using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using UnityEngine;

namespace Client.Game.Map
{
	
	public class RoomPool
	{

		int Maximum;
		int ReadPosition = 0;
		List<int> OrderedIds;
		Dictionary<int, RoomData> PristineSet = new Dictionary<int, RoomData>();
		Dictionary<int, int> InstancesRemaining = new Dictionary<int, int>();

		public RoomPool (List<RoomData> datas, int maximum)
		{
			

			buildPool(datas);
			this.Maximum = maximum;
		}

		void buildPool (List<RoomData> datas)
		{
			datas.Sort(new RoomComparer());
			OrderedIds = datas.Select(p => p.Id).ToList();

			this.InstancesRemaining = datas.ToDictionary(p => p.Id, p=>p.MaxInstances);
			this.PristineSet = datas.ToDictionary(p => p.Id, p=>p);
		}

		public RoomData Next() {
			
			int roomId = OrderedIds[ReadPosition % OrderedIds.Count];

			InstancesRemaining[roomId] --;

			if(InstancesRemaining[roomId] == 0) {
				//I know I know
				OrderedIds.Remove(roomId);
			}

			RoomData ret = PristineSet[roomId];

			ReadPosition++;
			return ret;

		}


		public bool Exhausted 
		{
			get {
				return ReadPosition == Maximum;
			}
		}
	}
}

