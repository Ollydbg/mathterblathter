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

		public float MinJumpPower = 38.5f;
		public float SustainedJumpPower = 38.18f;
		public float MaxJumpPower = 96.4f;


		public delegate void TriggerDelegate(Collider2D Collider);
		public event TriggerDelegate TriggerEvent;

		public delegate void TriggerActorDelegate(Actor actor);
		public event TriggerActorDelegate OnTriggerActorEnter;
		public event TriggerActorDelegate OnTriggerActorExit;

		public delegate void CollisionDelegate(Collision2D collision);
		public event CollisionDelegate CollisionEvent;

		void OnColliderEnter2D(Collision2D collision) {
			if(CollisionEvent != null) {
				CollisionEvent(collision);
			}
		}

		void OnTriggerEnter2D(Collider2D collider) {

			if (TriggerEvent != null) {
				TriggerEvent (collider);
			}

			TryTriggerActorEvent(collider, OnTriggerActorEnter);

		}

		void OnTriggerExit2D(Collider2D collider) {
			TryTriggerActorEvent(collider, OnTriggerActorExit);
		}

		private void TryTriggerActorEvent(Collider2D collider, TriggerActorDelegate evt) {
			
			if(evt != null) {
				var touchingRef = collider.gameObject.GetComponent<ActorRef>();
				if(touchingRef != null) {
					evt(touchingRef.Actor);
				}
			}
		}

	}
}

