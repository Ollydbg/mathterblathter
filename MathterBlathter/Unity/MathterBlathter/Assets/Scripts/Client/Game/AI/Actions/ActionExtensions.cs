using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Utils;

namespace Client.Game.AI.Actions
{
	public static class ActionUtil
	{

		public static bool InDetectionRange(Vector3 distanceVec, Actor selfActor) {
			var detectionRange = selfActor.Attributes [ActorAttributes.AIDetectionRadius];
			return distanceVec.sqrMagnitude <= (detectionRange * detectionRange);
		}

		public static void TryActivateAbility (Vector3 playerMid, Actor selfActor)
		{
			var direction = (playerMid - selfActor.transform.position).normalized;
			selfActor.WeaponController.Attack(direction);
		}

		public static bool HasLOS(Actor selfAIActor, Vector3 playerPosition) {
			var direction = playerPosition - selfAIActor.HalfHeight;

			var layerMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Player.ToString()});
			var hit = Physics2D.Raycast(selfAIActor.HalfHeight, direction.normalized, 100f, layerMask);

			if(hit.transform != null) {
				var transform = hit.transform;
				ActorRef actorRef = transform.gameObject.GetComponent<ActorRef>();

				if( actorRef != null && actorRef.Actor.ActorType== Client.Game.Data.ActorType.Player) {
					return true;
				}
			}

			return false;

		}

		public static bool PointToPointLOS(Vector3 from, Vector3 to) {
			
			var layerMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString()});
			var distance = (from - to).magnitude;
			var hits = Physics2D.RaycastAll(from, to, distance, layerMask);
			return hits.Length == 0;
		}

		public static bool LineHasActor(Vector3 from, Vector3 to, Actor target) {
			var layerMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Player.ToString()});
			var distance = (from - to).magnitude;
			var hits = Physics2D.LinecastAll(from, to, layerMask);
			Debug.DrawLine(from, to, Color.cyan, .1f);
			foreach ( var hit in hits ) {
				var transform = hit.transform.root;
				var actorRef = transform.gameObject.GetComponent<ActorRef>();

				if( actorRef != null && actorRef.Actor.Id == target.Id) {
					return true;
				}
			}
			return false;

		}

		public static bool AimingAtActor(Actor actor, Actor target, float error) {
			var angleBetween = Vector3.Angle(actor.transform.position, target.transform.position);
			return Math.Abs(angleBetween) <= error;
		}
	}
}

