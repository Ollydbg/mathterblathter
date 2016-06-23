using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;

namespace Client.Game.Geometry
{
	public class PassthroughPlatform : MonoBehaviour
	{
		public BoxCollider2D Collider;
		public PlatformEffector2D Effector;

		public Actor Passing;

		public PassthroughPlatform ()
		{
			
		}



		public void Passthrough(Actor actor) {
			//Passing = actor;
			//Collider.enabled = false;

		}


	}

	public static class PassthroughPlatformFactory {
		

		public static void Init(GameObject go) {

			//destroy the collider that comes with the primitive
			GameObject.Destroy(go.GetComponent<Collider2D>());


			var effector = go.AddComponent<PlatformEffector2D>();
			var pt = go.AddComponent<PassthroughPlatform>();

			var collider = go.AddComponent<BoxCollider2D>();
			collider.usedByEffector = true;
			collider.size = collider.size;
			pt.Collider = collider;
			pt.Effector = effector;
		}
	}
}

