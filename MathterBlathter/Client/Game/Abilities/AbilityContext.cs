using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Data;
using UnityEngine;

namespace Client.Game.Abilities
{
	public class AbilityContext
	{
		public Actor source;
		public Actor sourceWeapon;

		public Actor target;

		public AbilityData data;
		public Vector3 direction;

		public AbilityContext(Actor source, Actor weapon, Vector3 direction, AbilityData data) {
			this.source = source;
			this.sourceWeapon = weapon;
			this.data = data;
			this.direction = direction;
		}

		public AbilityContext(Actor source, AbilityData data)
		{
			this.source = source;
			this.data = data;
		}

		public AbilityContext(Actor source, Actor target, AbilityData data)
		{
			this.source = source;
			this.target = target;
			this.data = data;
		}


	}

}

