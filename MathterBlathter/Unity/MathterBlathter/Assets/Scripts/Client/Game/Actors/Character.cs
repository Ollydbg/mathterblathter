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

		public Character ()
		{
			
		}

	
		public override void EnterGame (Client.Game.Core.Game game)
		{
			
			Controller = new Client.Game.Actors.Controllers.CharacterController2D(this);
			base.EnterGame (game);
		}

		public override void FixedUpdate() {
			Controller.FixedUpdate();

		}

		public override void Update (float dt)
		{
			Controller.Update(dt);
		}


	}
}

