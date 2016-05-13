using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Data;
using System.Linq;

namespace Client.Game.Abilities.Scripts
{
	public class LevelAppropriateWeaponDrop : BuffBase
	{
		public LevelAppropriateWeaponDrop ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var allWeapons = MockActorData.GetAll().Where(p => p.ActorType == ActorType.Weapon).ToList();

			var dataToSpawn = Owner.Game.Seed.RandomInList(allWeapons);
			var replacement = Owner.Game.ActorManager.Spawn(dataToSpawn);
			replacement.transform.position = Owner.transform.position;
			Owner.Game.ActorManager.RemoveActor(Owner);

		}

		public override bool isComplete ()
		{
			return true;
		}

		public override void Update (float dt)
		{
		}
		public override void End ()
		{
		}

		#endregion
	}
}

