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
		public float colliderHeight;
		public Vector3 HalfHeight {
			get {
				return transform.position + new Vector3 (0f, colliderHeight*.5f, 0f);
			}
		}

		public override ActorType ActorType {
			get {
				return Data.ActorType;
			}
		}


		public Character ()
		{
		}

	
		public override void EnterGame (Client.Game.Core.Game game)
		{
			Controller = new CharacterController (this);
			Animator = new PlayerAnimator3D(this);

			colliderHeight = GameObject.GetComponent<CapsuleCollider> ().height;

			base.EnterGame (game);
		}

		public override void LoadFromData(CharacterData data) {
			var charData = data;
			Attributes.LoadFromData (charData.attributeData);

			base.LoadFromData (data);
		}

		public override void Update(float dt) {
			if(Brain != null) 
				Brain.Update (dt);

			Controller.Update(dt);

			base.Update (dt);
		}

		public override void FixedUpdate() {
			Controller.FixedUpdate();
		}

	}
}

