using System;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Abilities.Payloads
{
	public class DamagePayload : Payload
	{
		public float Damage;
		public Actor Target;
		public DamagePayload (AbilityContext ctx, Actor target, int damage) : base(ctx)
		{
			float weaponBaseDamage = 0f;
			if(ctx.sourceWeapon != null) {
				weaponBaseDamage = (float)ctx.sourceWeapon.Attributes[ActorAttributes.BaseDamage];
			}


			Damage = (float)damage + weaponBaseDamage + (float)ctx.source.Attributes[ActorAttributes.BaseDamage];
			Target = target;

		}

		bool targetIsPlayer 
		{
			get {
				return Target.Id == Target.Game.PossessedActor.Id;
			}
		}

		public override void Apply() {
			if (AbilityManager.NotifyPayloadSender(this, Context.source))
				return;

			if (AbilityManager.NotifyPayloadReceiver (this, Target))
				return;
			
			int totalDamage = (int)Damage;

			int newHealth = Target.Attributes [ActorAttributes.Health] - totalDamage;
			Debug.Log(totalDamage);

			Target.Attributes [ActorAttributes.Health] = newHealth;

			if (newHealth <= 0) {

				if (targetIsPlayer) {
					new PlayerKilledPayload (Context, Target).Apply ();
				} else {
					new KillPayload (Context, Target).Apply ();
				}
					

			}


		}

	}
}

