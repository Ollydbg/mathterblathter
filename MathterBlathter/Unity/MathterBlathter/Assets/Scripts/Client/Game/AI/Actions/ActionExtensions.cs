using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;

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

		public static bool HasLOS(Actor selfAIActor, Vector3 target) {
			var direction = target - selfAIActor.HalfHeight;

			var layerMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Player.ToString()});
			var hits = Physics2D.RaycastAll(selfAIActor.HalfHeight, direction.normalized, 10, layerMask);

			foreach( var hit in hits) {
				
				var transform = hit.transform;
				while(transform.parent != null) {
					transform = transform.parent;
				}

				var actorRef = transform.gameObject.GetComponent<ActorRef>();
				
				if( actorRef != null && actorRef.Actor.ActorType== Client.Game.Data.ActorType.Player) {
					return true;
				}
			}

			return false;

		}
	}
}

