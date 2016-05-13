using System;
using Client.Game.Actors;
using UnityEngine;

namespace Client.Game.Utils
{
	public static class ActorUtils
	{
		public static bool TryHitToActor(RaycastHit hit, out Actor actor) {

			var comp = hit.transform.root.gameObject.GetComponent<ActorRef>();
			if(comp == null) {
				actor = null;
				return false;
			}

			actor = comp.Actor;
			return true;
		}

		public static bool RayCastForActor(Vector3 origin, Vector3 direction, out Actor actor, int layerMask) {
			RaycastHit hitInfo;
			float distance = 100f;
			if(Physics.Raycast(origin, direction, out hitInfo, distance, layerMask)) {
				return TryHitToActor(hitInfo, out actor);
			} else {
				actor = null;
				return false;
			}
		}

	}
}

