using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using UnityEngine;

namespace Client.Game.Map
{
	using Game = Client.Game.Core.Game;
	
	public class RoomPool
	{

		int Maximum;
		int ReadPosition = 0;
		List<int> OrderedIds;
		Dictionary<int, RoomData> PristineSet = new Dictionary<int, RoomData>();
		Dictionary<int, int> InstancesRemaining = new Dictionary<int, int>();
		List<ZoneCheck> ZoneRequirements = new List<ZoneCheck>();

		public RoomPool (List<RoomData> datas, int maximum, List<ZoneData.Requirement> requirements)
		{
			buildPool(datas, requirements);
			this.Maximum = maximum;
		}

		void buildPool (List<RoomData> datas, List<ZoneData.Requirement> reqs)
		{
			reqs.ForEach(p => ZoneRequirements.Add(new ZoneCheck(p)));
			datas.Sort(new RoomComparer());
			
			OrderedIds = datas.Select(p => p.Id).ToList();

			this.InstancesRemaining = datas.ToDictionary(p => p.Id, p=>p.MaxInstances);
			this.PristineSet = datas.ToDictionary(p => p.Id, p=>p);

		}

		public bool RequirementsSatisfied {
			get { return ZoneRequirements.Count == 0; }
		}

		public void Consume(RoomData data) 
		{
			foreach( var req in ZoneRequirements.ToList()) {
				if(req.Req.Accepts(data)) {
					req.NumSatistfied++;
					if(req.Satisfied) {
						ZoneRequirements.Remove(req);
					}
				}
			}

		}

		public RoomData Next() {
			RoomData ret = null;
			int i = 0;
			while(ret == null) {
				int roomId = OrderedIds[(ReadPosition + i) % OrderedIds.Count];
				if(ZoneRequirements.Any(p => p.Req.Accepts(PristineSet[roomId]))) {

					InstancesRemaining[roomId] --;

					if(InstancesRemaining[roomId] == 0) {
						//I know I know
						OrderedIds.Remove(roomId);
					}

					ret = PristineSet[roomId];
				}
				i++;
			}

			ReadPosition ++;

			return ret;

		}




		public bool Exhausted 
		{
			get {
				return ReadPosition == Maximum;
			}
		}
	}

	public class ZoneCheck {
		public bool Satisfied {
			get {
				return Req.Amount == NumSatistfied;
			}
		}

		public ZoneData.Requirement Req;
		public int NumSatistfied;
		public ZoneCheck( ZoneData.Requirement req) {this.Req = req;}
	}
}

