using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Items;
using Client.Game.Attributes;
using Client.Game.Animation;

namespace Client.Game.Actors
{
	using Game = Client.Game.Core.Game;

	public class PlayerCharacter : Character
	{

		public PickupController PickupController;
		public WeaponController WeaponController;
		public CharacterController Controller;


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

			Controller = new CharacterController (this);
			Animator = new PlayerAnimator3D(this);

			this.WeaponController = new WeaponController(this);
			this.PickupController = new PickupController(this);

		}

		public override void Update (float dt)
		{
			PickupController.Update(dt);
			WeaponController.Update(dt);
			Controller.Update(dt);

			base.Update (dt);
		}


	}
}

