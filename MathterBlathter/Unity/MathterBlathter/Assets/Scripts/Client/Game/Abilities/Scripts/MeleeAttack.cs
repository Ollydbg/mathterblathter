using System;
using Client.Game.Animation;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Abilities.Utils;
using Client.Game.Abilities.Payloads;
using Client.Game.Actors;

namespace Client.Game.Abilities.Scripts
{
	public class MeleeAttack : AbilityBase
	{
		private FilterList AttackFilters;

		public MeleeAttack ()
		{
			AttackFilters = new FilterList(
				Filters.NotSelfFilter,
				HittableOrProjectile,
				Filters.NotPendingDelete
			);
		}

		public static bool HittableOrProjectile(AbilityContext ctx, Actor actor) {
			return actor.ActorType == Client.Game.Data.ActorType.Projectile || actor.Attributes[ActorAttributes.TakesDamage] == true;
		}

		bool isLeft {
			get {
				return context.source.transform.rotation.eulerAngles.y >180;
			}
		}
		Vector3 offset {
			get {
				var multiplier = isLeft ? -1 : 1;
				return multiplier * new Vector3 (0f, 0f, 0f);
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
			var range = SourceWeapon.Attributes[ActorAttributes.MeleeRange];
			var size = SourceWeapon.Attributes[ActorAttributes.MeleeWidth];
			var inRange = AbilityUtils.CircleCastAll(point, context, size, AttackFilters, range);
			foreach (var actor in inRange) {

				if(actor.ActorType == Client.Game.Data.ActorType.Projectile) {
					actor.Destroy();
					continue;
				}

				PlayTimeline(context.data.Timelines[1], actor.transform.position);
				new WeaponDamagePayload (context, actor, Attributes[AbilityAttributes.Damage]).Apply();
				ApplyEnergyCost(context.source);
			}

		}

		public override void End ()
		{
			
		}
		#endregion
	}
}

