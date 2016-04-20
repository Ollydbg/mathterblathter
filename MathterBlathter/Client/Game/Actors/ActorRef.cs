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
		}

	}
}

