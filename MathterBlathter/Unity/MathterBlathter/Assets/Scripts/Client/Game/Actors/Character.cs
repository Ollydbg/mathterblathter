using System;
using UnityEngine;
using Client.Game.AI;
using Client.Game.Animation;
using Client.Game.Data;
using Client.Game.Items;
using Client.Game.Actors.Controllers;

namespace Client.Game.Actors
{
	public class Character : Actor
	{

		public ICharacterController Controller = new EmptyCharacterController();
		public virtual Type ControllerClass {get ; set; }

		public Character ()
		{
			ControllerClass = typeof(Client.Game.Actors.Controllers.CharacterController2D);
		}

	
		public override void EnterGame (Client.Game.Core.Game game)
		{
			
			Controller = (ICharacterController)Activator.CreateInstance(ControllerClass);
			Controller.SetOwner(this);
			base.EnterGame (game);
		}

		public override void FixedUpdate() {
			Controller.FixedUpdate();

		}

		public override void Update (float dt)
		{
			WeaponController.Update(dt);
			Controller.Update(dt);
			
		}


	}
}

