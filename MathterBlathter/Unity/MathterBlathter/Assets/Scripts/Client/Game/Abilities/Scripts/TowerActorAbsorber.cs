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
			Game.RoomManager.OnRoomEntered -= OnRoomEntered;
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
            context.source.Destroy();

            //new TowerAbsorptionPayload().Apply();
            Game.PossessedActor.Attributes[ActorAttributes.RunDifficulty] += 1;
            
            UI.EventLog.Post("The tower grows stronger");    
            Abort(); 
        }
			

        public override void Update(float dt)
        {
            if(context.source.IsHeld) {
                Abort();
            }
        }
    }
}