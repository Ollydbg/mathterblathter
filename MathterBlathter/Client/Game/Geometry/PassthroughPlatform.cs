using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Geometry
{
	public class PassthroughPlatform : MonoBehaviour
	{
		public BoxCollider Collider;
		public BoxCollider Trigger;

		public Actor Passing;

		public PassthroughPlatform ()
		{
			
		}

		void OnTriggerEnter(Collider coll) {
			Actor actor;
			if(tryGetActor(coll, out actor)) {
				if(actor.Attributes[ActorAttributes.PassesThroughPlatforms]) {
					Passthrough(actor);
				}
			}
		}

		void OnTriggerExit(Collider coll) {
			Actor actor;
			if(tryGetActor(coll, out actor)) {
				if( actor == Passing) {
					Collider.enabled = true;
					Passing = null;
				}
			};

		}

		bool didPass() {
			return Passing != null &&
				Collider.bounds.IntersectRay( new Ray(Passing.transform.position, Vector3.up*Passing.colliderHeight));
		}

		bool tryGetActor(Collider coll, out Actor actor) {
			var actorRef = coll.gameObject.GetComponent<ActorRef>();
			if(actorRef) {
				actor = actorRef.Actor;
				return true;
			}
			actor = null;
			return false;
		}


		public void Passthrough(Actor actor) {
			Passing = actor;
			Collider.enabled = false;
		}


	}

	public static class PassthroughPlatformFactory {

		static Vector3 Depth = new Vector3(0, 0, 1f);
		static Vector3 DetectionRange = new Vector3(0, 3f, 0f);

		public static void Init(GameObject go) {

			//destroy the collider that comes with the primitive
			GameObject.Destroy(go.GetComponent<Collider>());

			var pt = go.AddComponent<PassthroughPlatform>();
			var trigger = go.AddComponent<BoxCollider>();
			trigger.isTrigger = true;
			trigger.size = trigger.size + Depth + DetectionRange;
			trigger.center -= .5f*DetectionRange;
			pt.Trigger = trigger;


			var collider = go.AddComponent<BoxCollider>();
			collider.size = collider.size + Depth;
			pt.Collider = collider;

		}
	}
}

