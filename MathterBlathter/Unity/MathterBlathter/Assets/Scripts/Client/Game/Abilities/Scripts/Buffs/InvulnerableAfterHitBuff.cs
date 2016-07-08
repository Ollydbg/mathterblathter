using System;
using Client.Game.Abilities.Payloads;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class InvulnerableAfterHitBuff : BuffBase
	{
		public InvulnerableAfterHitBuff ()
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

		public override bool OnPayloadReceive (Payload payload)
		{
			if(payload is DamagePayload) {
				var buffContext = new AbilityContext(context.source, AbilityDataTable.INVULNERABILITY_BUFF);
				context.source.Game.AbilityManager.ActivateAbility(buffContext);
			}

			return false;
		}


	}
}

