using System;
using UnityEngine;
using Client.Game.AI;
using Client.Game.Animation;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public class Character : Actor
	{
		public IAnimator Animator;
		public CharacterController Controller;
		public Brain Brain;
		public float HalfHeight;

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
			HalfHeight = GameObject.GetComponent<CapsuleCollider>().height * .5f;

			base.EnterGame (game);
		}

		public override void LoadFromData(GameData data) {
			var charData = (CharacterData)data;
			Attributes.LoadFromData (charData.attributeData);

			base.LoadFromData (data);
		}

		public override void Update(float dt) {
			if(Brain != null) 
				Brain.Update (dt);

			Controller.Update(dt);

			base.Update (dt);
		}

	}
}

