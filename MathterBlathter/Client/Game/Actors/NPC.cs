using System;

namespace Client.Game.Actors
{
	public class NPC : Character, IInteraction
	{
		public NPC ()
		{
		}

		public Actor InteractionTarget {
			get {
				return this;
			}
		}

		#region IInteraction implementation

		public bool Interact (Actor withActor)
		{
			return false;
		}

		public string GetPrompt ()
		{
			return "Shop";
		}

		#endregion
	}
}

