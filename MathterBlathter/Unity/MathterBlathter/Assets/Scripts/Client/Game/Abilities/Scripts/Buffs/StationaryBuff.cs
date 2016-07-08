using System;
using Client.Game.Abilities.Payloads;
using Client.Game.AI;
using UnityEngine;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class StationaryBuff : BuffBase
	{

		public StationaryBuff ()
		{
		}

		public override void Start ()
		{
			
		}

		public override void Update (float dt)
		{
            
		}

		public override void End ()
		{
            
		}
		
		public override bool OnPayloadReceive(Payload payload) {
			if(payload is KnockbackPayload)
				return true;
			return false;
		}
		

	}
}

