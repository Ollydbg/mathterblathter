using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class KillDeStresserBuff : BuffBase
	{
		public KillDeStresserBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			
		}

		public override void Update(float dt) {}
		
		public override void End ()
		{
			
		}

        public override bool OnPayloadSend(Payload payload) {
            var kp = payload as KillPayload;
            if(kp != null) {
                this.context.targetActor.Attributes[ActorAttributes.Anxiety] -= this.Attributes[ActorAttributes.Anxiety];
            }
            
            return false;
        }

		#endregion
	}
}

