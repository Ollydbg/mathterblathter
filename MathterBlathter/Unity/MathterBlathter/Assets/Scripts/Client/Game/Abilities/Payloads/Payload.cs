using System;
using Client.Game.Actors;

namespace Client.Game.Abilities.Payloads
{
	public abstract class Payload
	{
		public AbilityContext Context;

		public AbilityManager AbilityManager {
			get {
				return Context.source.Game.AbilityManager;
			}
		}

		public Payload (AbilityContext context)
		{
			this.Context = context;
		}

		public abstract void Apply ();
	}
}

