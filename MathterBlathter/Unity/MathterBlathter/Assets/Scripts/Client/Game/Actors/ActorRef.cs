using System;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public class ActorRef : MonoBehaviour
	{
		public Actor Actor;

/*
		public float MinJumpPower = 27f;
		public int JumpBoostFrameThresh = 6;
		public float SustainedJumpPower = 9f;
		public int BoostFramesFloor = 3;
		*/
		
		void Awake() {}
		void Start() {}

		public delegate void TriggerDelegate(Collider2D Collider);
		public event TriggerDelegate TriggerEvent;

		public delegate void TriggerActorDelegate(Actor actor);
		public event TriggerActorDelegate OnTriggerActorEnter;
		public event TriggerActorDelegate OnTriggerActorExit;

		public delegate void CollisionDelegate(Collision2D collision);
		public event CollisionDelegate CollisionEvent;
        
		void OnColliderEnter2D(Collision2D collision) {
			if(CollisionEvent != null && collision.gameObject != null) {
				CollisionEvent(collision);
			}
		}

		void OnTriggerEnter2D(Collider2D collider) {
            if (TriggerEvent != null && collider.gameObject != null) {
				TriggerEvent (collider);
			}

			TryTriggerActorEvent(collider, OnTriggerActorEnter);

		}

		void OnTriggerExit2D(Collider2D collider) {
			TryTriggerActorEvent(collider, OnTriggerActorExit);
		}

		private void TryTriggerActorEvent(Collider2D collider, TriggerActorDelegate evt) {
			
			if(evt != null && collider.gameObject != null) {
				var touchingRef = collider.gameObject.GetComponent<ActorRef>();
				if(touchingRef != null) {
					evt(touchingRef.Actor);
				}
			}
		}

	}
}

