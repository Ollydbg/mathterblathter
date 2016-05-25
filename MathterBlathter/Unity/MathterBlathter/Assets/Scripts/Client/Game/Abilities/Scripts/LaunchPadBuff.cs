
using System;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class LaunchPadBuff : BuffBase
	{
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
			var charactor = actor as Character;
			if(charactor != null)
				charactor.Controller.KnockDirection(Vector3.up, 3f);

		}

		public override void Update (float dt)
		{
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

