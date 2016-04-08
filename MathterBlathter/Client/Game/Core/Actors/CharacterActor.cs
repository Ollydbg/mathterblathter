using System;
using UnityEngine;

namespace Client.Game.Core.Actors
{
	public class CharacterActor : Actor
	{
		public PlayerAnimator3D Animator;
		public PlayerController Controller;

		public CharacterActor ()
		{
		}

		void onCollision (Collider collider)
		{
			Debug.Log ("colliding");
		}

		public override void EnterGame (Game game)
		{
			Controller = new PlayerController (this);
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

