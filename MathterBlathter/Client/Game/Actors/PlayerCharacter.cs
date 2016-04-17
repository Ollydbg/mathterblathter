using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Items;

namespace Client.Game.Actors
{
	using Game = Client.Game.Core.Game;

	public class PlayerCharacter : Character
	{

		public PickupController PickupController;

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
			//var hitRef = collider.gameObject.GetComponent<ActorRef>();
		
		}

		public override void EnterGame (Game game)
		{
			base.EnterGame (game);
			this.PickupController = new PickupController(this);
			GameObject.GetComponent<ActorRef> ().TriggerEvent += onCollision;
		}

		public override void Update (float dt)
		{
			PickupController.Update(dt);
			base.Update (dt);
		}

	}
}

