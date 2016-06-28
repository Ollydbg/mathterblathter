using System;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.AI.Actions
{
	
	public class PathToPlayer : AIAction {
		
		public override AIResult Update (float dt, Actor actor)
		{
			var path = CurrentRoom.Grid.SearchPath(actor.transform.position, PlayerMid);

			foreach( var point in path ) {
				var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				sphere.transform.position = point;
			}
			return AIResult.Success;
		}

	}
}

