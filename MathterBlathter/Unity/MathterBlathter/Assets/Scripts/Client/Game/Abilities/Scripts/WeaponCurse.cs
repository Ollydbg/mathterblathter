
using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
    public class WeaponCurse : BuffBase
    {
        public override void End()
        {
			
        }

        public override void Start()
        {
			
        }

        public override void Update(float dt)
        {
			
        }
        
        public override bool OnPayloadReceive(Payload payload) {
            WeaponPickupPayload wpp = payload as WeaponPickupPayload;
         
            if(wpp != null) {
                return true;
            }
         
            return false;
        }
         
    }
}