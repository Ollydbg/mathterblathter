using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Geometry
{
	public class PassthroughPlatform : MonoBehaviour
	{
		public BoxCollider2D Collider;
		public BoxCollider2D Trigger;

		public Actor Passing;

		public PassthroughPlatform ()
		{
			
		}

		void OnTriggerEnter2D(Collider2D coll) {
			Actor actor;
			if(tryGetActor(coll, out actor)) {
				if(actor.Attributes[ActorAttributes.PassesThroughPlatforms]) {
					Debug.Log("Doing passthrough");
					Passthrough(actor);
				}
			}
		}

		void OnTriggerExit2D(Collider2D coll) {
			Actor actor;
			if(tryGetActor(coll, out actor)) {
				if( actor == Passing) {
					Debug.Log("completing passthrough");
					Collider.enabled = true;
					Passing = null;
				}
			};

		}

		bool didPass() {
			return Passing != null &&
				Collider.bounds.IntersectRay( new Ray(Passing.transform.position, Vector3.up*Passing.colliderHeight));
		}

		bool tryGetActor(Collider2D coll, out Actor actor) {
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
		
		static Vector2 DetectionRange = new Vector2(0, 3f);

		public static void Init(GameObject go) {

			//destroy the collider that comes with the primitive
			GameObject.Destroy(go.GetComponent<Collider2D>());

			var pt = go.AddComponent<PassthroughPlatform>();
			var trigger = go.AddComponent<BoxCollider2D>();
			trigger.isTrigger = true;
			trigger.offset -= (.5f*DetectionRange + Vector2.up*trigger.size.y); 
			trigger.size = trigger.size + DetectionRange;

			pt.Trigger = trigger;


			var collider = go.AddComponent<BoxCollider2D>();
			collider.size = collider.size;
			pt.Collider = collider;

		}
	}
}

