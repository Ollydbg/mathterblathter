using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class AnxietyHealPlayer : BuffBase
	{
		public AnxietyHealPlayer ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			context.targetActor.Attributes[ActorAttributes.Anxiety] -= this.Attributes[ActorAttributes.Anxiety];

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

