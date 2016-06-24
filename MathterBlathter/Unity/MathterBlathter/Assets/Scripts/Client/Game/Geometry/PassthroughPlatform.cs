using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;

namespace Client.Game.Geometry
{
	public class PassthroughPlatform : MonoBehaviour
	{
		public BoxCollider2D Collider;
		public PlatformEffector2D Effector;

		public GameObject Passing;
		Collider2D PassingCollider;
		public PassthroughPlatform ()
		{
			
		}


		void OnTriggerExit2D(Collider2D collider) {
			if(collider.gameObject == Passing) {
				Physics2D.IgnoreCollision(PassingCollider, this.Collider, false);
				Passing = null;
				PassingCollider = null;
			}
		}

		public void Passthrough(Actor actor) {
			Passing = actor.GameObject;
			PassingCollider = actor.GameObject.GetComponent<Collider2D>();
			Physics2D.IgnoreCollision(PassingCollider, this.Collider, true);

		}


	}

	public static class PassthroughPlatformFactory {
		
		static Vector2 DetectionRange = new Vector2(0, 1f);

		public static void Init(GameObject go) {

			//destroy the collider that comes with the primitive
			GameObject.Destroy(go.GetComponent<Collider2D>());

			var effector = go.AddComponent<PlatformEffector2D>();
			var pt = go.AddComponent<PassthroughPlatform>();


			var trigger = go.AddComponent<BoxCollider2D>();
			trigger.isTrigger = true;
			trigger.size = trigger.size + DetectionRange;
			trigger.offset -= .5f*DetectionRange;


			var collider = go.AddComponent<BoxCollider2D>();
			collider.usedByEffector = true;
			collider.size = collider.size;
			pt.Collider = collider;
			pt.Effector = effector;
		}
	}
}

