using System;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class DamageOnTouchBuff : BuffBase
	{
		public DamageOnTouchBuff ()
		{
		}


		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			var actorRef = this.Owner.GameObject.GetComponent<ActorRef>();

			actorRef.OnTriggerActor += DamageTarget;

		}
		public override void Update (float dt)
		{
		}
		public override void End ()
		{
		}
		#endregion

		void DamageTarget (Actor actor)
		{
			new DamagePayload(this.context, actor, this.Attributes[AbilityAttributes.Damage]);
		}
	}
}

