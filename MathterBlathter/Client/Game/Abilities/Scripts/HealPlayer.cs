using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class HealPlayer : BuffBase
	{
		public HealPlayer ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			new HealPayload(this.context, this.context.targetActor,  -this.Attributes[AbilityAttributes.Damage]).Apply();
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

