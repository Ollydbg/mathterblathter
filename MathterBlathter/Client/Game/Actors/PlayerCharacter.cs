using System;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public class PlayerCharacter : Character
	{
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

		public override void EnterGame (Client.Game.Core.Game game)
		{
			base.EnterGame (game);
			GameObject.GetComponent<ActorRef> ().TriggerEvent += onCollision;

		}
	}
}

