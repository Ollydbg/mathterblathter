using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts.Items
{
	public class NoAnxietyFireSpeed : AbilityBase
	{
		public NoAnxietyFireSpeed ()
		{
		}

		float ttl = 0f;
		public override void Start ()
		{
			this.ttl = this.Attributes[AbilityAttributes.Duration];
			context.source.Attributes[ActorAttributes.WeaponCooldownScalar] *= this.Attributes[ActorAttributes.WeaponCooldownScalar];

		}

		public override void Update (float dt)
		{
			ttl -= dt;

		}

		public override bool isComplete ()
		{
			return ttl <= 0f;
		}

		
		public override bool OnPayloadReceive (Payload payload)
		{
			
			return payload is AnxietyCostPayload;
		}

		public override void End ()
		{
			context.source.Attributes[ActorAttributes.WeaponCooldownScalar] /= this.Attributes[ActorAttributes.WeaponCooldownScalar];

		}

	}
}

