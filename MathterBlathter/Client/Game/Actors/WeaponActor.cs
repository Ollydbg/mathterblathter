using System;
using Client.Game.Data;
using Client.Game.Abilities;

namespace Client.Game.Actors
{
	public class WeaponActor : Actor, IInteraction
	{
		public WeaponActor ()
		{
		}

		public bool InteractionEnabled {
			get {
				//use this to flag that we're not currently held by anyone
				return transform.parent == null;
			}
		}


		public bool Interact (Actor withActor)
		{
			withActor.WeaponController.AddWeapon(this);
			return true;
		}

		public override void EnterGame (Client.Game.Core.Game game)
		{
			base.EnterGame(game);

			WeaponController.AddWeapon(this);
		}

		public string GetPrompt ()
		{
			return Data.Name;
		}

		public Actor InteractionTarget {
			get {
				return this;
			}
		}

	}
}

