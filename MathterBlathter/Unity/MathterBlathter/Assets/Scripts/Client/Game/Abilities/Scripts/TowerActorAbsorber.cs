using System;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Managers;
using Client.Game.Actors;
using Client.Game.Map;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
    public class TowerActorAbsorber : BuffBase
    {
        public override void End()
        {
			Game.RoomManager.OnRoomEntered -= OnRoomEntered;
        }

        public override void Start()
        {
			Game.RoomManager.OnRoomEntered += OnRoomEntered;
        }

        private void OnRoomEntered(Actor actor, Room oldRoom, Room newRoom)
        {
			if(!context.source.IsHeld) {
					
				context.source.Destroy();

	            new TowerAbsorptionPayload(1, context).Apply();
	              
	            Abort();
				
			}
        }
			

        public override void Update(float dt)
        {
        }
    }
}