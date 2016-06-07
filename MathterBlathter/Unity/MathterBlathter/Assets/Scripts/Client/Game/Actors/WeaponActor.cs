using System;
using Client.Game.Data;
using Client.Game.Abilities;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Actors
{
	public class WeaponActor : Actor, IInteraction
	{
		public WeaponActor ()
		{
		}

		public delegate void AttackToggle();
		public delegate void AttackContext(AbilityContext context);
		public event AttackContext OnAttackStart;
		public event AttackToggle OnAttackEnd;

		public bool InteractionEnabled {
			get {
				//use this to flag that we're not currently held by anyone
				return transform.parent == null;
			}
		}

		public void AttackStart(AbilityContext ctx) {
			if(OnAttackStart != null) 
				OnAttackStart(ctx); 
		}

		public void AttackStop() {
			if(OnAttackEnd != null)
				OnAttackEnd();
		}

		public bool Interact (Actor withActor)
		{
			//having a null ability data will eventually get me in trouble!
			var ctx = new AbilityContext(withActor, this, UnityEngine.Vector3.zero, null);
			
			//routes to WeaponController.AddWeapon on success
			new WeaponPickupPayload(ctx).Apply();
			
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

