using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Core;
using System.Collections.Generic;
using System.Linq;

namespace Client.Game.Abilities.Payloads
{
    public class DropPayload : Payload
	{
		
		public List<DropSet> DropSets = new List<DropSet>();

		public Actor killedActor;

		public DropPayload(AbilityContext ctx, Actor killedActor) : base(ctx) {

			var sourceDropPct = ctx.source.Attributes[ActorAttributes.DropRate];
 			var dropPct = killedActor.Attributes[ActorAttributes.DropRate];
			this.killedActor = killedActor;
			
			var dropPercentage = dropPct + sourceDropPct;
			
			DropSets.Add(new DropSet(dropPercentage, DropList(killedActor.Attributes[ActorAttributes.DropType])));

		}

		private CharacterData getDrop(List<CharacterData> datas, Seed seed) {
					
			return seed.RandomInList(datas);
		}
			


		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, killedActor))
				return;

			foreach( var drop in DropSets ) {

				//while(drop.DropPercentage > 0) {
					bool shouldDrop = killedActor.Game.Seed.RollAgainst(drop.DropPercentage);

					if(shouldDrop) {
						CharacterData dataToDrop = getDrop(drop.PotentialDrops, killedActor.Game.Seed);
						var actor = killedActor.Game.ActorManager.Spawn(dataToDrop);
						actor.transform.position = killedActor.transform.position;
					}
					
					drop.DropPercentage -= 1f;
				//}
			}
		}

		

		private List<CharacterData> DropList(int type) {

			var items = CharacterDataTable.GetAll()
				.Where(p=>p.ActorType == ActorType.Pickup);

			if(type == (int)PickupType.Unassigned) {
				return items.Where(p => p.Availability != Availability.None).ToList();
			} else {
				return items.Where(p=>p.PickupType == (PickupType)type).ToList();
			} 
			
		}

	}

	public class DropSet {
		public float DropPercentage;
		public List<CharacterData> PotentialDrops;
		public DropSet(float percentage, List<CharacterData> drops) {
			this.DropPercentage = percentage;
			this.PotentialDrops = drops;
		}
	}
}

