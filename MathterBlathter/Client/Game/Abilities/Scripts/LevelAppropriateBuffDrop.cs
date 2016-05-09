using System;
using Client.Game.Data;
using System.Linq;

namespace Client.Game.Abilities.Scripts
{
	public class LevelAppropriateBuffDrop : BuffBase
	{
		public LevelAppropriateBuffDrop ()
		{
		}

		public override void Start ()
		{
			var playerBuffs = MockActorData.GetAll()
				.Where(p=>p.GetType() == typeof(PickupData))
				.Cast<PickupData>()
				.Where( p=>p.PickupType == PickupData.Type.Buff)
				.ToList();


			var dataToSpawn = Owner.Game.Seed.RandomInList(playerBuffs);
			var replacement = Owner.Game.ActorManager.Spawn(dataToSpawn);
			replacement.transform.position = Owner.transform.position;

			Owner.Game.ActorManager.RemoveActor(Owner);
		}

		public override bool isComplete ()
		{
			return true;
		}

		#region implemented abstract members of AbilityBase

		public override void Update (float dt)
		{
		}

		public override void End ()
		{

		}

		#endregion
	}
}

