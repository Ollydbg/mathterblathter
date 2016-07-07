using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
	public class TowerAbsorptionTTLBuff : BuffBase
	{
		public TowerAbsorptionTTLBuff ()
		{
		}

		float TTL = 0f;
		public override void Start ()
		{
			TTL = context.targetActor.Attributes[ActorAttributes.TowerAbsorptionTTL];
		}
		
		public override void Update (float dt)
		{
			TTL -= dt;

			if(TTL <= 0f) {
				Abort();
			}
		}

		bool didEnd = false;
		public override void End ()
		{
			if(!didEnd) {
				didEnd = true;

				new TowerAbsorptionPayload(1, context).Apply();
				context.targetActor.Destroy();
			}
		}

	}
}

