using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;

namespace Client.Game.Abilities.Payloads
{
	public class DropPayload : Payload
	{


		public DropPayload(AbilityContext ctx, Actor killedActor) : base(ctx) {


 			var dropPct = killedActor.Attributes[ActorAttributes.DropRate];
			while(dropPct > 0) {

				bool shouldDrop = killedActor.Game.Seed.RollAgainst(dropPct);

				if(shouldDrop) {
					CharacterData dataToDrop = MockActorData.RANDOM_WEAPON_PICKUP;
					var actor = killedActor.Game.ActorManager.Spawn(dataToDrop);
					actor.transform.position = killedActor.transform.position;
				}
				
				dropPct -=1;
			}
		}


		#region implemented abstract members of Payload

		public override void Apply ()
		{
		}

		#endregion
	}
}

