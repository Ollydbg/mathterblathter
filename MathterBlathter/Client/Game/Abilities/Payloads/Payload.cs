using System;
using Client.Game.Actors;

namespace Client.Game.Abilities.Payloads
{
	public abstract class Payload
	{

		public Actor target;
		public Actor source;

		public Payload ()
		{
		}

		public void Trigger() {
			Game.Core.Game.Instance.AbilityManager.TriggerPayload (this);
		}
	}
}

