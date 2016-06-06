using System;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class StatUp : AbilityBase
	{
		public StatUp ()
		{
		}


		public override void Start ()
		{
			context.targetActor.Attributes[ActorAttributes.Health] += this.Attributes[ActorAttributes.Health];
			context.targetActor.Attributes[ActorAttributes.MaxHealth] += this.Attributes[ActorAttributes.MaxHealth];
		}

		public override void Update (float dt)
		{
		}

		public override bool isComplete ()
		{
			return true;
		}

		public override void End ()
		{
		}

	}
}

