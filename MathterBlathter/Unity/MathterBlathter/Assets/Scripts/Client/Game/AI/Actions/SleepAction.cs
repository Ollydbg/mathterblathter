using System;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.AI.Actions
{
	public class SleepAction : AIAction
	{
		public SleepAction ()
		{
		}

		float accum;
		public override void Start (Actor selfActor)
		{
			accum = selfActor.Attributes[ActorAttributes.AISleepTime];
		}

		public override AIResult Update (float dt, Character actor)
		{
			accum -= dt;
			if(accum >= 0f ) {
				return AIResult.Running;
			}

			return AIResult.Success;
		}

	}
}

