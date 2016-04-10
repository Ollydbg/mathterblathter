using System;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Abilities.Payloads
{
	public class KillPayload : Payload
	{
		Actor Target;

		public KillPayload(AbilityContext ctx, Actor target) : base(ctx) {
			Target = target;
		}


		public override void Apply ()
		{
			Target.Game.RemoveActor (Target);
		}


	}

}

