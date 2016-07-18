using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;
using System.Collections.Generic;

namespace Client.Game.Geometry
{
	public class PassthroughPlatform : MonoBehaviour
	{
		public BoxCollider2D Collider;
		public PlatformEffector2D Effector;

		public GameObject Passing;
		Collider2D[] PassingColliders;
		public PassthroughPlatform ()
		{
			
		}


		void OnTriggerExit2D(Collider2D collider) {
			if(collider.gameObject == Passing) {
				foreach( var coll in PassingColliders ) 
					Physics2D.IgnoreCollision(coll, this.Collider, false);
				Passing = null;
				PassingColliders = null;
			}
		}

		public void Passthrough(Actor actor) {
			Passing = actor.GameObject;
			PassingColliders = actor.GameObject.GetComponentsInChildren<Collider2D>();
			foreach( var coll in PassingColliders ) 
				Physics2D.IgnoreCollision(coll, this.Collider, true);

		}


	}

	public static class PassthroughPlatformFactory {
		
		static Vector2 DetectionRange = new Vector2(0, 1f);

		public static void Init(GameObject go) {

			//destroy the collider that comes with the primitive
			GameObject.Destroy(go.GetComponent<Collider2D>());

			var effector = go.AddComponent<PlatformEffector2D>();
			effector.useColliderMask = false;
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

