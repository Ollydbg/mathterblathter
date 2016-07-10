using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Payloads
{
	public class TowerAbsorptionPayload : Payload
	{
		public int DifficultyAmount; 
		public TowerAbsorptionPayload (int difficultyAmt, AbilityContext ctx) : base(ctx)
		{
			this.DifficultyAmount = difficultyAmt;
		}


		public override void Apply ()
		{
			var player = Context.targetActor.Game.PossessedActor;

			if(AbilityManager.NotifyPayloadSender(this, Context.targetActor))
				return;
			
			if(AbilityManager.NotifyPayloadReceiver(this, player)) 
				return;
		

			player.Attributes[ActorAttributes.WaveDifficulty] += DifficultyAmount;
			UI.EventLog.Post("The tower grows stronger");  

			
		}


	}
}

