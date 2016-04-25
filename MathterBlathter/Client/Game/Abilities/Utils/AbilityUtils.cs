using System;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Actors;

namespace Client.Game.Abilities.Utils
{
	//using Filter = Func<AbilityContext, Actor, bool>;


	public class AbilityUtils
	{
		public static List<Actor> CollideSphere(Vector3 point, AbilityContext context, float size, FilterList filters ) {
			var colliders = UnityEngine.Physics.OverlapSphere (point, size);
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






	}

}

