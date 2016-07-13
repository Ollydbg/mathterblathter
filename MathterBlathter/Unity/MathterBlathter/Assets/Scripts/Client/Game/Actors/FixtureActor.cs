using System;
using Client.Game.Data;
using Client.Game.Actors.Controllers;

namespace Client.Game.Actors
{
	public class FixtureActor : Character
	{

		public FixtureActor ()
		{
			ControllerClass = typeof(EmptyCharacterController);
		}



	}
}

 