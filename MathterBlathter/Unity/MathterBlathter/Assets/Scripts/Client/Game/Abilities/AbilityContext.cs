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
		public WeaponActor sourceWeapon;

		public Actor targetActor;

		public AbilityData data;
		public Vector3 targetDirection;
		public Vector3 targetPosition;

		public AbilityContext(Actor source, WeaponActor weapon, Vector3 direction, AbilityData data) {
			this.source = source;
			this.sourceWeapon = weapon;
			this.data = data;
			this.targetDirection = direction;
		}

		public AbilityContext(Actor source, AbilityData data)
		{
			this.source = source;
			this.data = data;
		}

		public AbilityContext(Actor source, Actor target, AbilityData data)
		{
			this.source = source;
			this.targetActor = target;
			this.data = data;
		}

		public override string ToString() {
			var targetId = targetActor != null ? targetActor.Id.ToString() : "none";
			var sourceId = source != null ? source.Id.ToString() : "none";
			var targetName = targetActor != null? targetActor.Data.Name : "none";
			var sourceName = source != null ? source.Data.Name : "none";
			
			return string.Format("[AbilityContext source:[{0}:{1}], target:[{2}:{3}], abilityId:{4}]", sourceName, sourceId, targetName, targetId, data.Id);
		}

	}

}

