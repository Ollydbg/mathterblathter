using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
	public class YeeHawBuff : BuffBase
	{
		public YeeHawBuff ()
		{
			
		}
		

		public override void Start ()
		{
			context.targetActor.Attributes[ActorAttributes.Speed] += this.Attributes[ActorAttributes.Speed];
			context.targetActor.Attributes[ActorAttributes.AttackSpeedScalar] *= this.Attributes[ActorAttributes.AttackSpeedScalar];
			

		}


       
		public override void Update (float dt)
		{
			
		}

		

		public override void End ()
		{
			context.targetActor.Attributes[ActorAttributes.Speed] -= this.Attributes[ActorAttributes.Speed];
			context.targetActor.Attributes[ActorAttributes.AttackSpeedScalar] /= this.Attributes[ActorAttributes.AttackSpeedScalar];
		}

		public override bool OnPayloadReceive(Payload payload) {
			var dp = payload as DamagePayload;

			if(dp != null) {
				new AnxietyCostPayload(context, dp.Target, (int)dp.Damage).Apply();
				Abort();
				return true;
			}
			return false;
		}

	}
}

