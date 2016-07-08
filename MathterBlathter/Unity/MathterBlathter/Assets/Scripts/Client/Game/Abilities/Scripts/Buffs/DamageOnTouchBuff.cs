using System;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class DamageOnTouchBuff : BuffBase
	{
		public DamageOnTouchBuff ()
		{
		}

		private List<Actor> Targets = new List<Actor>();
		private float accumulator = 0f;
		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var actorRef = this.Owner.GameObject.GetComponent<ActorRef>();

			actorRef.OnTriggerActorEnter += AddTarget;
			actorRef.OnTriggerActorExit += RemoveTarget;
		}
		public override void Update (float dt)
		{
			
			var rate = Owner.Attributes[ActorAttributes.ZoneUpdateRate];

			accumulator += dt;
			if(accumulator >= rate) {
				accumulator-= rate;
				var dps = Owner.Attributes[ActorAttributes.BaseDamage];
				Targets.ForEach(p => DamageTarget(p, dps*rate));
			}

		}
		public override void End ()
		{
			
		}
		#endregion

		void DamageTarget (Actor obj, float damage)
		{
			new WeaponDamagePayload(this.context, obj, damage).Apply();
		}

		void RemoveTarget(Actor actor) {
			Targets.Remove(actor);
		}

		void AddTarget (Actor actor)
		{
			Targets.Add(actor);
			DamageTarget(actor, Owner.Attributes[ActorAttributes.BaseDamage]);

		}

	}
}

