using System;
using Client.Game.Animation;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Abilities.Utils;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
	public class MeleeAttack : AbilityBase
	{
		public MeleeAttack ()
		{
		}

		float damageDelay = .1f;
		float accumulator = 0f;
		bool didDamage = false;

		bool isLeft {
			get {
				return context.source.transform.rotation.eulerAngles.y >180;
			}
		}
		Vector3 offset {
			get {
				var multiplier = isLeft ? -1 : 1;
				return multiplier * new Vector3 (Attributes[AbilityAttributes.MeleeRange], 0f, 0f);
			}
		}

		public override void Init (AbilityContext ctx)
		{
			base.Init (ctx);
		}
		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			this.context.source.Animator.RequestState (States.ATTACK1, 1, 1);	
			accumulator = 0f;
			
		}

		public override void Update (float dt)
		{
			accumulator += dt;
			if (accumulator > damageDelay && !didDamage) {
				DamageFacing ();
				didDamage = true;
			}

		}

		public override bool isComplete ()
		{
			return didDamage;
		}

		public void DamageFacing() {
			var point = context.source.HalfHeight + offset;

			var inRange = AbilityUtils.CollideSphere (point, context, Attributes[AbilityAttributes.MeleeRange], AbilityUtils.NotSelfFilter, AbilityUtils.IsEnemyFilter);
			foreach (var actor in inRange) {
				new DamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
			}

		}

		public override void End ()
		{
			
		}
		#endregion
	}
}

