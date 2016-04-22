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
		public Actor target;
		public AbilityData data;
		public Vector3 direction;

		public AbilityContext(Actor source, Actor target, AbilityData data) {
			this.source = source;
			this.target = target;
			this.data = data;
		}

		public AbilityContext(Actor source, Vector3 direction, AbilityData data) {
			this.source = source;
			this.direction = direction;
			this.data = data;
		}

	}

}

