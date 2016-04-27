using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Items;
using Client.Game.Attributes;
using Client.Game.Animation;

namespace Client.Game.Actors
{
	using Game = Client.Game.Core.Game;
	using CharacterController = Client.Game.Actors.Controllers.CharacterController;

	public class PlayerCharacter : Character
	{

		public PickupController PickupController;

		public PlayerCharacter ()
		{
			
		}

		void onCollision (Collider collider)
		{
			
		}

		public override void EnterGame (Game game)
		{
			
			base.EnterGame (game);

			this.Animator = new PlayerAnimator3D(this);
			this.PickupController = new PickupController(this);

		}

		public override void Update (float dt)
		{
			PickupController.Update(dt);
			WeaponController.Update(dt);

			base.Update (dt);
		}


	}
}

