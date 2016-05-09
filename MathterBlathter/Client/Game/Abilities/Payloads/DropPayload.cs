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
					CharacterData dataToDrop = getDrop(ctx.source, killedActor, killedActor.Game.Seed);
					var actor = killedActor.Game.ActorManager.Spawn(dataToDrop);
					actor.transform.position = killedActor.transform.position;
				}
				
				dropPct -=1;
			}
		}

		private CharacterData getDrop(Actor killer, Actor killed, Seed seed) {
			
			var dropList = DropList(killed.Attributes[ActorAttributes.DropType]);

			return seed.RandomInList(dropList);
		}


		public override void Apply ()
		{
		}

		private List<PickupData> DropList(int type) {

			var items = MockActorData.GetAll()
				.Where(p=>p.GetType() == typeof(PickupData))
				.Cast<PickupData>();

			if(type == (int)PickupData.Type.Unassigned) {
				return items.ToList();
			} else {
				return items.Where(p=>p.PickupType == (PickupData.Type)type).ToList();
			}
			
		}

	}
}

