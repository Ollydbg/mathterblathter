using System;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts
{
	public class CursedCourageBuff : BuffBase
	{
		public CursedCourageBuff ()
		{
		}

		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var delta = this.Attributes[ActorAttributes.MaxHealth];
			
			this.context.targetActor.Attributes[ActorAttributes.MaxHealth] += delta;
			var currentHealth = this.context.targetActor.Attributes[ActorAttributes.Health];
			var projectedHealth = currentHealth + delta;
			if(projectedHealth <= 0) {
				projectedHealth = 1;	
			}
			
			this.context.targetActor.Attributes[ActorAttributes.Health] = projectedHealth;
			
			context.targetActor.Attributes[ActorAttributes.DamageScalar] += this.Attributes[ActorAttributes.DamageScalar];
			
            Abort();
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

