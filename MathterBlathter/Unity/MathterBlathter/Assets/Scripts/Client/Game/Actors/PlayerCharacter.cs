using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Items;
using Client.Game.Attributes;
using Client.Game.Animation;
using Client.Game.Actors.Controllers;

namespace Client.Game.Actors
{
	using Game = Client.Game.Core.Game;
	using CharacterController = Client.Game.Actors.Controllers.CharacterController;

	public class PlayerCharacter : Character
	{
		
		public InteractionController InteractionController;
		public ActiveItemController ActiveItemController;

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
			this.InteractionController = new InteractionController(this);
			this.ActiveItemController = new ActiveItemController(this);
		}

		public override void Update (float dt)
		{
			WeaponController.Update(dt);
			ActiveItemController.Update(dt);
			InteractionController.Update(dt);


			base.Update (dt);
		}


	}
}

