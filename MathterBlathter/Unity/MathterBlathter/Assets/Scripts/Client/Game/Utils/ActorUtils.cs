using System;
using Client.Game.Actors;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Abilities;
using Client.Utils;
using Client.Game.Enums;

namespace Client.Game.Utils
{
	public static class ActorUtils
	{
		public static bool TryHitToActor(RaycastHit2D hit, out Actor actor) {

			if(hit.transform == null) {
				actor = null;
				return false;
			}

			var comp = hit.transform.root.gameObject.GetComponent<ActorRef>();
			if(comp == null) {
				actor = null;
				return false;
			}

			actor = comp.Actor;
			return true;
		}

		public static bool RayCastForActor(Vector3 origin, Vector3 direction, out Actor actor, int layerMask) {
			float distance = 100f;
			var hitInfo = Physics2D.Raycast(VectorUtils.Vector2(origin), VectorUtils.Vector2(direction), distance, layerMask);
			if(hitInfo != null) {
				return TryHitToActor(hitInfo, out actor);
			} else {
				actor = null;
				return false;
			}
		}

		public static void FaceRelativeDirection(Actor actor, Vector3 direction) {

			Quaternion targetRotation = Quaternion.identity;
			if(direction == Vector3.left) {
				targetRotation = Quaternion.AngleAxis(90, Vector3.forward);
			} else if(direction == Vector3.right) {
				targetRotation = Quaternion.AngleAxis(-90, Vector3.forward);
			} else if (direction == Vector3.down) {
				targetRotation = Quaternion.AngleAxis(180, Vector3.forward);
			} 
			

			actor.transform.rotation = targetRotation;


		}

		public static Vector3 GetTransformFacing(Actor actor) {
			return Vector3.right;
		}

		//works as long as we only change it by 1 unit each time.
		public static void SetDataIdAttributes(Actor actor, GameAttributeI attr, List<int> ids) {
			for (int i = 0; i< int.MaxValue; i++) {
				var currentId = actor.Attributes[attr,i];
				if(currentId == attr.DefaultValue) {
					return;
				} else {
					if(i < ids.Count) {
						actor.Attributes[attr, i] = ids[i];
					} else {
						actor.Attributes[attr, i] = attr.DefaultValue;
					}
				}
			}
		}

		public static List<int> IterateAttributes(Actor actor, GameAttributeI attr) {
			List<int> buffer = new List<int>();
			for( int i = 0; i< int.MaxValue; i++ ) {
				var dataId = actor.Attributes[attr, i];
				if(dataId == attr.DefaultValue) 
					break;
				else 
					buffer.Add(dataId);
			}

			return buffer;
		}


		public static void ParentToActor(Actor owner, Actor child, AttachPoint ap) {

			child.transform.parent = GetAttachTransform(owner, ap);
			foreach( var childTrans in child.GameObject.GetComponentsInChildren<Transform>()) 
				childTrans.gameObject.layer = owner.GameObject.layer;

			child.GameObject.SetActive(false);
			child.GameObject.SetActive(true);

		}

		private static Transform GetAttachTransform(Actor owner, AttachPoint pt) {
			foreach( var ap in owner.GameObject.GetComponentsInChildren<AttachPointComponent>()) {
				if(ap.Type == pt) {
					return ap.transform; 
				}
			}
			return owner.transform;
		}

		public static void PropogateBuffs(Actor pickup, Actor toActor) {
			for( int i = 0; i< int.MaxValue; i++ ) {
				var dataId = pickup.Attributes[ActorAttributes.Abilities, i];
				
				if(dataId == ActorAttributes.Abilities.DefaultValue) 
					break;

				var data = AbilityDataTable.FromId(dataId);
				if(data.DoesPropogate) {
					var context = new AbilityContext(pickup, toActor, data);
					toActor.Game.AbilityManager.ActivateAbility(context);
				}
			}
		}
	}
}

