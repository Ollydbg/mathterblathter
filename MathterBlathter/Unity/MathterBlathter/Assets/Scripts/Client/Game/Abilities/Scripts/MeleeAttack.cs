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

		bool isLeft {
			get {
				return context.source.transform.rotation.eulerAngles.y >180;
			}
		}
		Vector3 offset {
			get {
				var multiplier = isLeft ? -1 : 1;
				return multiplier * new Vector3 (3f, 0f, 0f);
			}
		}



		public override void Init (AbilityContext ctx)
		{
			base.Init (ctx);
		}

		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			
			PlayTimeline(context.data.Timelines[0], SourceWeapon.transform.position + context.targetDirection * SourceWeapon.Attributes[ActorAttributes.MeleeRange], context.targetDirection);
			DamageFacing();
		}

		public override void Update (float dt)
		{
			
		}


		public void DamageFacing() {
			var point = context.source.HalfHeight + offset;

			
			var inRange = AbilityUtils.CircleCastAll(point, context, SourceWeapon.Attributes[ActorAttributes.MeleeRange], FilterList.QuickFilters);
			foreach (var actor in inRange) {
				Debug.Log("GOT A HIT!");

				new WeaponDamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
			}

		}

		public override void End ()
		{
			
		}
		#endregion
	}
}

