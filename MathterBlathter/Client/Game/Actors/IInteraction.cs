using System;
using UnityEngine;

namespace Client.Game.Actors
{
	public interface IInteraction
	{
		void Interact(Actor withActor);
		string GetPrompt();
		Actor InteractionTarget { get; }

	}
}

