using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Data;

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
			var allWeapons = MockWeaponData.GetAll();

			var index = Owner.Game.Seed.Next(allWeapons.Count-1);

			this.Owner.Attributes[ActorAttributes.PickupItemId] = allWeapons[index].Id;
		

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

