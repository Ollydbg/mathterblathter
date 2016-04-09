using System;
using UnityEngine;

namespace Client.Game.Actors
{
	public class Character : Actor
	{
		public PlayerAnimator3D Animator;
		public CharacterController Controller;

		public Character ()
		{
		}

		void onCollision (Collider collider)
		{
			Debug.Log ("colliding");
		}

		public override void EnterGame (Client.Game.Core.Game game)
		{
			Controller = new CharacterController (this);
			Animator = new PlayerAnimator3D(this);

			GameObject.GetComponent<ActorRef> ().CollisionEvent += onCollision;

			base.EnterGame (game);
		}

		public override void Update(float dt) {
			Controller.Update(dt);

			base.Update (dt);
		}
	}
}

