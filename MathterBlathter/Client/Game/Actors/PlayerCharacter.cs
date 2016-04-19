using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Items;
using Client.Game.Attributes;

namespace Client.Game.Actors
{
	using Game = Client.Game.Core.Game;

	public class PlayerCharacter : Character
	{

		public PickupController PickupController;
		public WeaponController WeaponController;

		public PlayerCharacter ()
		{
			
		}

		public override ActorType ActorType {
			get {
				return ActorType.Player;
			}
		}

		void onCollision (Collider collider)
		{
			
		}

		public override void EnterGame (Game game)
		{
			base.EnterGame (game);
			this.WeaponController = new WeaponController(this);
			this.PickupController = new PickupController(this);
			GameObject.GetComponent<ActorRef> ().TriggerEvent += onCollision;
		}

		public override void Update (float dt)
		{
			PickupController.Update(dt);
			WeaponController.Update(dt);
			base.Update (dt);
		}


	}
}

