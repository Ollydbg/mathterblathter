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

		private CharacterData getDrop(List<PickupData> datas, Seed seed) {
					
			return seed.RandomInList(datas);
		}
			


		public override void Apply ()
		{
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, killedActor))
				return;

			foreach( var drop in DropSets ) {

				while(drop.DropPercentage > 0) {
					bool shouldDrop = killedActor.Game.Seed.RollAgainst(drop.DropPercentage);

					if(shouldDrop) {
						CharacterData dataToDrop = getDrop(drop.PotentialDrops, killedActor.Game.Seed);
						var actor = killedActor.Game.ActorManager.Spawn(dataToDrop);
						actor.transform.position = killedActor.transform.position;
					}
					
					drop.DropPercentage -= 1f;
				}
			}
		}

		

		private List<PickupData> DropList(int type) {

			var items = MockActorData.GetAll()
				.Where(p=>p.GetType() == typeof(PickupData))
				.Cast<PickupData>();

			if(type == (int)PickupData.Type.Unassigned) {
				return items.Where(p => p.Availability != Availability.None).ToList();
			} else {
				return items.Where(p=>p.PickupType == (PickupData.Type)type).ToList();
			} 
			
		}

	}

	public class DropSet {
		public float DropPercentage;
		public List<PickupData> PotentialDrops;
		public DropSet(float percentage, List<PickupData> drops) {
			this.DropPercentage = percentage;
			this.PotentialDrops = drops;
		}
	}
}

