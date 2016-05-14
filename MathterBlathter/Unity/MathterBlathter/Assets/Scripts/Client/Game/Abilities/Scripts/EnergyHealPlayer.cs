using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class EnergyHealPlayer : BuffBase
	{
		public EnergyHealPlayer ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			context.targetActor.Attributes[ActorAttributes.Energy] += this.Attributes[ActorAttributes.Energy];

		}

		public override void Update (float dt)
		{

		}
		public override bool isComplete ()
		{
			return true;
		}

		public override void End ()
		{
		}

		#endregion
	}
}

