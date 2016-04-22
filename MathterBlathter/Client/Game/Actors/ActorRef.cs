using System;
using UnityEngine;

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
		public event TriggerActorDelegate OnTriggerActor;


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

			if(OnTriggerActor != null) {
				var touchingRef = collider.gameObject.GetComponent<ActorRef>();
				if(touchingRef != null) {
					OnTriggerActor(touchingRef.Actor);
				}
			}
		}

	}
}

