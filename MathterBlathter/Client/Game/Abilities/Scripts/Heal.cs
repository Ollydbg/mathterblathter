using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
	public class Heal : AbilityBase
	{
		public Heal ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			new HealPayload(this.context,  -this.Attributes[AbilityAttributes.Damage]).Apply();
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

