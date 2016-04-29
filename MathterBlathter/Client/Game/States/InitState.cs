using System;
using UnityEngine;

namespace Client.Game.States
{
	public class InitState : State
	{
		public InitState ()
		{
		}

		#region implemented abstract members of State

		public override void Enter ()
		{
			
		}

		public override void Exit ()
		{
		}

		public override void Update (float dt)
		{
			Change<GenerateMapState>();	
		}

		#endregion
	}
}

