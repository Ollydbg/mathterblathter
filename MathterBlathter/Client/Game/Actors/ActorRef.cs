using System;
using UnityEngine;

namespace Client.Game.Actors
{
	public class ActorRef : MonoBehaviour
	{
		public Actor Actor;

		public ActorRef ()
		{
		}

		public delegate void CollisionDelegate(Collider Collider);
		public event CollisionDelegate CollisionEvent;

		void OnTriggerEnter(Collider collider) {
			if (CollisionEvent != null) {
				CollisionEvent (collider);
			}
		}

	}
}

