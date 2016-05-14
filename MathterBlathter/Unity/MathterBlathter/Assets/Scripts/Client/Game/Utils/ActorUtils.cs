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

		public static void FaceRelativeDirection(Actor actor, Vector3 direction) {
			
			Quaternion targetRotation = Quaternion.identity;
			if(direction == Vector3.left) {
				targetRotation = Quaternion.AngleAxis(-180, Vector3.up);
				var pos = actor.transform.position;
				//this is SO dirty
				actor.transform.position = new Vector3(pos.x+1f, pos.y, pos.z);
			} else if (direction == Vector3.up || direction == Vector3.down) {
				targetRotation = Quaternion.Euler(direction);
			} 

			actor.transform.rotation = targetRotation;


		}

	}
}

