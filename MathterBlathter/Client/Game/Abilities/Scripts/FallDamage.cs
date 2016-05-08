using System;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class FallDamage : BuffBase
	{
		public FallDamage ()
		{
		}

		#region implemented abstract members of AbilityBase
		float timeLeft = 0f;
		public override void Start ()
		{
			timeLeft = this.Attributes[AbilityAttributes.Duration];
			Debug.LogWarning("This buff not implemented yet");
		}


		public override void Update (float dt)
		{
			timeLeft -= dt;
		}

		public override bool isComplete ()
		{
			return timeLeft <= 0f;
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

