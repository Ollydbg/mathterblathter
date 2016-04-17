using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Abilities.Payloads
{
	public class PlayerKilledPayload : Payload
	{
		Actor Target;

		public PlayerKilledPayload (AbilityContext ctx, Actor target) : base (ctx)
		{
			this.Target = target;
		}


		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Context.target))
				return;
			
			//find player death ability
			var id = Target.Attributes[ActorAttributes.Abilities, (int)AbilitySlots.Death];
			var deathBuff = MockAbilityData.FromId(id);

			var deathContext = new AbilityContext(this.Context.source, Target, deathBuff);
			AbilityManager.ActivateAbility(deathContext);
			//trigger it

		}

	}
}

