using System;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public class ActorRef : MonoBehaviour
	{
		public Actor Actor;

		void Awake() {}
		void Start() {}

		public delegate void TriggerDelegate(Collider Collider);
		public event TriggerDelegate TriggerEvent;

		public delegate void TriggerActorDelegate(Actor actor);
		public event TriggerActorDelegate OnTriggerActorEnter;
		public event TriggerActorDelegate OnTriggerActorExit;

		public delegate void CollisionDelegate(Collision collision);
		public event CollisionDelegate CollisionEvent;

		void OnColliderEnter(Collision collision) {
			if(CollisionEvent != null) {
				CollisionEvent(collision);
			}
		}

		void OnTriggerEnter(Collider collider) {
			if (TriggerEvent != null) {
				TriggerEvent (collider);
			}

			TryTriggerActorEvent(collider, OnTriggerActorEnter);

		}

		void OnTriggerExit(Collider collider) {
			TryTriggerActorEvent(collider, OnTriggerActorExit);
		}

		private void TryTriggerActorEvent(Collider collider, TriggerActorDelegate evt) {
			
			if(evt != null) {
				var touchingRef = collider.gameObject.GetComponent<ActorRef>();
				if(touchingRef != null) {
					evt(touchingRef.Actor);
				}
			}
		}

	}
}

