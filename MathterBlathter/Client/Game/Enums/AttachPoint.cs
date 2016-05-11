using System;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Enums
{
	public enum AttachPoint
	{
		World,
		Muzzle,
		Arm,
		Face,
		Eyes,
	}



	public class AttachPointComponent : MonoBehaviour {
		public AttachPoint Type;

		public static Vector3 AttachPointPositionOnActor(AttachPoint point, Actor actor) {

			var components = actor.GameObject.GetComponentsInChildren<AttachPointComponent>();

			foreach( var comp in components ) {

				if(comp.Type == point) {
					return comp.gameObject.transform.position;
				}

			}

			//default just return the feet position of the actor
			return actor.GameObject.transform.position;

		}
	}
}

