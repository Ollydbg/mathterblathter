using System;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Attributes;

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
		
		public CharacterData Item {
			get {
				var itemId = this.Attributes[ActorAttributes.PickupItemId];
				CharacterData weaponData = MockActorData.FromId(itemId);

				return weaponData;
			}
		}


		public bool Interact (Actor withActor)
		{
			if(Item.ActorType == ActorType.Weapon) {
				withActor.WeaponController.AddWeapon(Item);

			} else {

				//just spawn it and see what happens!
				Game.ActorManager.Spawn(Item);
			}

			Game.ActorManager.RemoveActor(this);
			return true;
		}

		public string GetPrompt ()
		{
			return Item.Name;
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

