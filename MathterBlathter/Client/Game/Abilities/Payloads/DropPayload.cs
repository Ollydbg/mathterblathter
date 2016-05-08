using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Core;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Abilities.Payloads
{
	public class DropPayload : Payload
	{
		

		public DropPayload(AbilityContext ctx, Actor killedActor) : base(ctx) {


 			var dropPct = killedActor.Attributes[ActorAttributes.DropRate];
			while(dropPct > 0) {

				bool shouldDrop = killedActor.Game.Seed.RollAgainst(dropPct);

				if(shouldDrop) {
					CharacterData dataToDrop = getDrop(killedActor.Game.Seed);
					var actor = killedActor.Game.ActorManager.Spawn(dataToDrop);
					actor.transform.position = killedActor.transform.position;
				}
				
				dropPct -=1;
			}
		}

		private CharacterData getDrop(Seed seed) {
			if(seed.RollAgainst(.3f)) {
				return MockActorData.RANDOM_WEAPON_PICKUP;
			} else {
				var pickups = new CharacterData[]{
					MockActorData.MAX_HEALTH_BOOST,
					MockActorData.HEALTH_PICKUP,
					MockActorData.MOVE_BOOST_PICKUP,
					MockActorData.SHORTENED_TENDONS_PICKUP,
					MockActorData.CURSED_RABBITS_FOOT,
					MockActorData.RABBITS_FOOT,
				
				}.ToList();

				return seed.RandomInList(pickups);
				
			}
		}

		#region implemented abstract members of Payload

		public override void Apply ()
		{
		}

		#endregion
	}
}

