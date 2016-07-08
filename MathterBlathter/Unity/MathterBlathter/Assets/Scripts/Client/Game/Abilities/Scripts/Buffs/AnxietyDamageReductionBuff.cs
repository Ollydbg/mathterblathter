using System;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class AnxietyDamageReductionBuff : BuffBase
	{
		public AnxietyDamageReductionBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

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
			var pl = payload as AnxietyDamagePayload;
			if(pl != null) {
				pl.Damage *= this.Attributes[ActorAttributes.AnxietyDamageScalar];
			}

			return false;
		}

		#endregion
	}
}

