using System;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Managers;
using Client.Game.Actors;
using Client.Game.Map;

namespace Client.Game.Abilities.Scripts
{
    public class TowerActorAbsorber : BuffBase
    {
        public override void End()
        {
			
        }

        public override void Start()
        {
			if(!(context.source is WeaponActor)) {
				Abort();
				return;
			}
				
			Game.RoomManager.OnRoomEntered += OnRoomEntered;
        }

        private void OnRoomEntered(Actor actor, Room oldRoom, Room newRoom)
        {
			if(!context.source.IsHeld) {
				context.source.Destroy();
				Debug.Log("The tower grows stronger");
			}
        }

        public override void Update(float dt)
        {
        }
    }
}