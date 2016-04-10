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
		public Character source;
		public Actor target;
		public AbilityData data;
		public Vector3 direction;

		public AbilityContext(Character source, Actor target, AbilityData data) {
			this.source = source;
			this.target = target;
			this.data = data;
		}

		public AbilityContext(Character source, Vector3 direction, AbilityData data) {
			this.source = source;
			this.direction = direction;
			this.data = data;
		}

	}

}

