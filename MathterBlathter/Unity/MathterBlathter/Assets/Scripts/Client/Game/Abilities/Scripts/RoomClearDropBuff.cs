using System;
using System.Collections.Generic;
using System.Linq;
using Client.Game.Abilities.Payloads;
using Client.Game.AI;
using Client.Game.Data;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class RoomClearDropBuff : BuffBase
	{
        public RoomClearDropBuff ()
		{
		}

        public override void End()
        {
        }

        public override void Start()
        {
        }

        public override void Update(float dt)
        {
        }

		private List<PickupData> DroppablePickups() {
			var items = MockActorData.GetAll()
				.Where(p=>p.GetType() == typeof(PickupData))
				.Cast<PickupData>();

			return items.Where(p => (p.Availability & Availability.RoomClearReward)==Availability.RoomClearReward).ToList();
		}

		public override bool OnPayloadSend(Payload payload) {
			var dp = payload as DropPayload;
			if(dp != null) {
				var waves = Game.RoomManager.CurrentRoom.Waves;
				if(!waves.HasWavesRemaining && waves.AliveActors.Count == 1) {
					var clearedPickups = DroppablePickups();
					dp.DropSets.Add(new DropSet(1f, clearedPickups));
				}
			}
			return false;
		}
    }
}