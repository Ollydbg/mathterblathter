using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.AI.Actions
{
	public class WaitForAimLock : AIAction
	{
		float accum;

		public WaitForAimLock ()
		{
		}

		public override void Start (Actor selfActor)
		{
			accum = 0f;
		}
		public override AIResult Update (float dt, Character actor)
		{

			if(IsAimedAtPlayer(actor)) {
				accum += dt;
			} else {
				return AIResult.Failure;
			}

			if(accum >= actor.Attributes[ActorAttributes.AILockOnTime]) {
				return AIResult.Success;
			} else {
				return AIResult.Running;
			}
		}

	}
}

