using System;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class EnergyRegenBuff : BuffBase
	{
		public EnergyRegenBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
		}

		float accum = 0f;

		public override void Update (float dt) {
			accum += dt;

			if( accum >= 1f) {
				accum -= 1f;

				context.source.Attributes[ActorAttributes.Energy] += context.source.Attributes[ActorAttributes.EnergyRegen];
			}
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

