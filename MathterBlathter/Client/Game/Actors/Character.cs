using System;
using UnityEngine;
using Client.Game.AI;
using Client.Game.Animation;

namespace Client.Game.Actors
{
	public class Character : Actor
	{
		public IAnimator Animator;
		public CharacterController Controller;
		public Brain Brain;

		public Character ()
		{
		}

		void onCollision (Collider collider)
		{
			
		}

		public override void EnterGame (Client.Game.Core.Game game)
		{
			Controller = new CharacterController (this);
			Animator = new PlayerAnimator3D(this);

			GameObject.GetComponent<ActorRef> ().CollisionEvent += onCollision;

			base.EnterGame (game);
		}

		public override void Update(float dt) {
			if(Brain != null) 
				Brain.Update (dt);

			Controller.Update(dt);

			base.Update (dt);
		}

	}
}

