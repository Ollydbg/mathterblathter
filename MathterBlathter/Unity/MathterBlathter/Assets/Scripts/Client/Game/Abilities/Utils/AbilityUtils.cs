using System;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Utils;

namespace Client.Game.Abilities.Utils
{
	//using Filter = Func<AbilityContext, Actor, bool>;


	public class AbilityUtils
	{
		public static List<Actor> OverlapCircle(Vector3 point, AbilityContext context, float size, FilterList filters ) {
			var colliders = Physics2D.OverlapCircleAll(VectorUtils.Vector2(point), size);
			List<Actor> buff = new List<Actor> ();
			foreach (var coll in colliders) {
				var actorRef = coll.gameObject.GetComponent<ActorRef> ();
				if (actorRef != null) {
					
					if(filters.Check(context, actorRef.Actor))
						buff.Add (actorRef.Actor);
				}
			}
			return buff;
		}


		public static List<Actor> CircleCastAll(Vector3 point, AbilityContext context, float size, FilterList filters, float distance ) {
			var hits = Physics2D.CircleCastAll(VectorUtils.Vector2(point), size, context.targetDirection, distance);
			
			List<Actor> buff = new List<Actor> ();
			foreach (var hit in hits) {
				var coll = hit.collider;
				var actorRef = coll.gameObject.GetComponent<ActorRef> ();
				if (actorRef != null) {

					if(filters.Check(context, actorRef.Actor))
						buff.Add (actorRef.Actor);
				}
			}
			return buff;
		}

		public static Vector3 AdjustWithInaccuracy(Vector3 direction, AbilityContext context) {
			float weaponInacc = context.sourceWeapon.Attributes[ActorAttributes.Inaccuracy];
			float sourceInacc = context.source.Attributes[ActorAttributes.Inaccuracy];

			float adjustAmt = Mathf.Clamp(weaponInacc + sourceInacc, 0, float.MaxValue);
			adjustAmt = UnityEngine.Random.Range(-adjustAmt, adjustAmt);
			return Quaternion.AngleAxis(adjustAmt, Vector3.back) * direction;

			//return direction;
		}



	}

}

