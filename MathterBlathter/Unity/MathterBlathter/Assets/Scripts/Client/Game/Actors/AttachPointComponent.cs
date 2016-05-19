using System;
using UnityEngine;
using Client.Game.Enums;

namespace Client.Game.Actors
{
	public class AttachPointComponent : MonoBehaviour {
		public AttachPoint Type;

		public static Vector3 AttachPointPositionOnActor(AttachPoint point, Actor actor) {

			var components = actor.GameObject.GetComponentsInChildren<AttachPointComponent>();

			foreach( var comp in components ) {

				if(comp.Type == point) {
					var position = comp.gameObject.transform.position;
					return new Vector3(position.x, position.y);
				}

			}

			//default just return the feet position of the actor
			return actor.GameObject.transform.position;

		}
	}
}

