using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class AttackSpeedBuff : BuffBase
	{
		public AttackSpeedBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var delta = this.Attributes[ActorAttributes.AttackSpeedScalar];
			this.context.targetActor.Attributes[ActorAttributes.AttackSpeedScalar] *= delta;
		}

		public override void Update(float dt) {}
		
		public override void End ()
		{
			var delta = this.Attributes[ActorAttributes.AttackSpeedScalar];
			this.context.targetActor.Attributes[ActorAttributes.AttackSpeedScalar] /= delta;
		}

		#endregion
	}
}

