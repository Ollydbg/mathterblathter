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
			var playerBuffs = CharacterDataTable.GetAll()
				.Where(p=>p.PickupType == PickupType.Buff)
				.ToList();


			var dataToSpawn = Owner.Game.Seed.RandomInList(playerBuffs);
			var replacement = Owner.Game.ActorManager.Spawn(dataToSpawn);
			replacement.transform.position = Owner.transform.position;

			Owner.Game.ActorManager.RemoveActor(Owner);
		}

		public override bool IsComplete ()
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

