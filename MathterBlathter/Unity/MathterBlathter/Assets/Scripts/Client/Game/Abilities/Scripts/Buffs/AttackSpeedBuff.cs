using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class AttackSpeedBuff : BuffBase
	{
		public AttackSpeedBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var delta = this.Attributes[ActorAttributes.WeaponCooldownScalar];
			this.context.targetActor.Attributes[ActorAttributes.WeaponCooldownScalar] *= delta;
		}

		public override void Update(float dt) {}
		
		public override void End ()
		{
			var delta = this.Attributes[ActorAttributes.WeaponCooldownScalar];
			this.context.targetActor.Attributes[ActorAttributes.WeaponCooldownScalar] /= delta;
		}

		#endregion
	}
}

