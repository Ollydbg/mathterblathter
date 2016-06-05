using System;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Abilities;

namespace Client.Game.Actors
{
	public class Pickup : Actor , IInteraction
	{
		public Pickup ()
		{
		}

		public Actor InteractionTarget {
			get {
				return this;
			}
		}

		public bool InteractionEnabled {
			get {
				return true;
			}
		}


		public bool Interact (Actor withActor)
		{
			//dump all our abilities onto the interactor
			for( int i = 0; i< int.MaxValue; i++ ) {
				var dataId = this.Attributes[ActorAttributes.Abilities, i];
				if(dataId == ActorAttributes.Abilities.DefaultValue) 
					break;

				var context = new AbilityContext(withActor, withActor, MockAbilityData.FromId(dataId));
				Game.AbilityManager.ActivateAbility(context);
			}

			Game.ActorManager.RemoveActor(this);

			return true;
		}

		public string GetPrompt ()
		{
			return Data.Name;
		}

		public bool CanActorPickup(Actor actor) {
			return true;
		}

		void onCollision (Collider Collider)
		{
			var hitRef = Collider.gameObject.GetComponent<ActorRef>();
			if(hitRef && hitRef.Actor.ActorType == ActorType.Player) {
				this.Game.ActorManager.RemoveActor(this);
			}
		}

		public override void EnterGame (Client.Game.Core.Game game)
		{
			GameObject.GetComponent<ActorRef>().TriggerEvent += onCollision;

			base.EnterGame (game);
		}

	}
}

