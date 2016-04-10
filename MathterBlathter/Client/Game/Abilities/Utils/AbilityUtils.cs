using System;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Actors;

namespace Client.Game.Abilities.Utils
{
	using Filter = Func<AbilityContext, Actor, bool>;

	public class AbilityUtils
	{
		public static List<Actor> CollideSphere(Vector3 point, AbilityContext context, float size, params Filter[] filters ) {
			var colliders = Physics.OverlapSphere (point, size);
			List<Actor> buff = new List<Actor> ();
			foreach (var coll in colliders) {
				var actorRef = coll.gameObject.GetComponent<ActorRef> ();
				if (actorRef != null) {

					bool filterOk = true;
					foreach (var filter in filters) {
						filterOk &= filter (context, actorRef.Actor);

					}

					if(filterOk)
						buff.Add (actorRef.Actor);
				}
			}
			return buff;
		}

		public static bool NotSelfFilter(AbilityContext ctx, Actor actor) {
			return actor.Id != actor.Game.PossessedActor.Id;
		}

		public static bool IsEnemyFilter(AbilityContext ctx, Actor actor) {
			return actor.ActorType != Client.Game.Data.ActorType.Door;
		}


	}
}

