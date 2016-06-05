using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.AI.Actions
{
	public class PatrolAction : AIAction
	{
		public PatrolAction ()
		{
		}


		#region IAction implementation


		public override AIResult Update (float dt, Actor actor)
		{
			return AIResult.Success;
		}

		#endregion



	}
}

