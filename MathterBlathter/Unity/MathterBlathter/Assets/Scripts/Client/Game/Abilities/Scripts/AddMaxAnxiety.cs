using System;
using Client.Game.Attributes;

namespace Client.Game.Abilities.Scripts
{
	public class AddMaxAnxiety : AbilityBase
	{
		public AddMaxAnxiety ()
		{
		}


		public override void Start ()
		{
			context.targetActor.Attributes[ActorAttributes.MaxAnxiety] += this.Attributes[ActorAttributes.MaxAnxiety];
		}

		public override void Update (float dt)
		{
		}

		public override void End ()
		{
		}

	}
}

