
using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class LaunchPadBuff : BuffBase
	{
		public static Actor JustLaunched;

		public LaunchPadBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var actorRef = this.Owner.GameObject.GetComponent<ActorRef>();
			actorRef.OnTriggerActorEnter += LaunchTarget;
		}

		void LaunchTarget (Actor actor)
		{
			if(JustLaunched != actor) {	
				var charactor = actor as Character;
				if(charactor != null) {
					charactor.Controller.KnockDirection(Vector3.up, this.context.source.Attributes[ActorAttributes.KnockbackForce]);
					PlayTimeline(context.data.Timelines[0], actor.transform.position);
					JustLaunched = actor;
				}
				
			}
		}

		public override void Update (float dt)
		{
			JustLaunched = null;
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

