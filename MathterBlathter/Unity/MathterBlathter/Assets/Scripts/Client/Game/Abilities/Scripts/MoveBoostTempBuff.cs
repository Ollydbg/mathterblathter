using System;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class MoveBoostTempBuff : BuffBase
	{
		public MoveBoostTempBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		float timeLeft;

		public override void Start ()
		{
			
			this.context.targetActor.Attributes[ActorAttributes.Speed] += this.Attributes[AbilityAttributes.SpeedBoost];
			this.timeLeft = this.Attributes[AbilityAttributes.Duration];

		}

		public override void Update (float dt)
		{
			timeLeft -= dt;
		}

		public override bool IsComplete ()
		{
			return timeLeft <= 0f;
		}

		public override void End ()
		{
			this.context.targetActor.Attributes[ActorAttributes.Speed] -= this.Attributes[AbilityAttributes.SpeedBoost];
		}

		#endregion
	}
}

