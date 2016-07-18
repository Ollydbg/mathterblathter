using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;
using System.Collections.Generic;
using Client.Game.Map;
using Client.Game.Enums;
using Client.Game.Utils;

namespace Client.Game.AI
{
	using Game = Client.Game.Core.Game;

	public abstract class AIAction
	{
		public virtual void Start(Actor selfActor) {}
		public virtual void End(){}

		private static int _castingMask = -1;
		public static int CastingMask {
			get {
				if(_castingMask == -1) {
					_castingMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Player.ToString()});

				}
				return _castingMask;
			}
		}

		public abstract AIResult Update(float dt, Character actor);

		private AIAction _next;
		private AIAction _else;
		public AIAction Next {
			get {
				return _next ?? LocalHead;
			} set {
				_next = value;
			}
		}

		public AIAction FailureCase {
			get {
				return _else ?? LocalHead;
			}
			set {
				_else = value;
			}
		}

		public AIAction LocalHead;

		internal bool inAbilityRange(Vector3 distanceVec, Character selfActor) {
			var weaponRange = selfActor.WeaponController.currentWeapon.Attributes[ActorAttributes.AIActivationRange];
			return distanceVec.sqrMagnitude < (weaponRange * weaponRange);
		}


		internal Actor Player
		{
			get {
				return Game.Instance.PossessedActor;
			}
		}

		internal Room CurrentRoom {
			get {
				return Game.Instance.RoomManager.CurrentRoom;
			}
		}

		internal Vector3 PlayerMid
		{
			get {
				var possessed = Game.Instance.PossessedActor;
				return possessed.HalfHeight;
			}
		}

		internal Vector3 GetFacingVector(Character selfActor) {
			var angles = selfActor.transform.eulerAngles;
			if(angles.y == -180)
				return Vector3.left;
			else if(angles.y == 0)
				return Vector3.right;
			else if(angles.y == 1) 
				return Vector3.up;
			else 
				return Vector3.down;
		}
		

		internal bool IsAimedAtPlayer(Actor actor) {

			Actor hitActor;
			var origin = AttachPointComponent.AttachPointPositionOnActor(AttachPoint.Muzzle, actor);
			if (ActorUtils.RayCastForActor(origin, actor.WeaponController.AimDirection, out hitActor, CastingMask)) {
				if(hitActor.Id == actor.Game.PossessedActor.Id) {
					return true;
				}
			}
			return false;

		}

		internal void FaceTarget3D(Character selfActor, Vector3 target) {

			float angle = target.x < selfActor.transform.position.x ? -180 : 0;

			selfActor.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);


		}
		internal void FaceTarget2D(Character selfActor, Vector3 target) {

			var xScale = target.x > selfActor.transform.position.x ? 1f : -1f;

			var scale = selfActor.transform.localScale;

			if((xScale < 0 && scale.x > 0) || (xScale > 0 && scale.x < 0)) {
				scale.x *= -1f;
				selfActor.transform.localScale = scale;
			}


		}
	}



	public enum AIResult {
		Success,
		Failure,
		Running,
		SubTreeFailure,
		Invalid,
	}
	
	

	//Runs multiple actions, detects early success and early failure
	public class Sequence : AIAction {
		public List<AIAction> Actions = new List<AIAction>();

		public override AIResult Update (float dt, Character actor)
		{
			AIResult result = AIResult.Invalid;
			
			foreach( var action in Actions) {
				var tmp = action.Update(dt, actor);
				if(result == AIResult.Invalid) 
					result = tmp;
				
				//Log("Action {0} was {1}", action, tmp);
				
				if(tmp == AIResult.Success)
					return AIResult.Success;
					
				if(tmp == AIResult.Failure)
					return AIResult.Failure;
			}
			
			return AIResult.Running;
			
		}

		public override void Start (Actor selfActor)
		{
			Actions.ForEach(p => p.Start(selfActor));
		}

		public override void End ()
		{
			Actions.ForEach(p => p.End());
		}


		
		public override string ToString() {
			string buff = "[Sequence: ";
			foreach( var action in Actions) 
				buff += action.ToString() + " ";
				
			buff += "]"; 
			return buff;
		}
		
		private bool Logs = true;
		void Log(string msg, params object[] args) {
			if(Logs) 
				UnityEngine.Debug.Log(string.Format(msg, args));
				
		}
	}

	public class EmptyAction : AIAction {
		
		public override AIResult Update (float dt, Character actor)
		{
			return AIResult.Running;
		}



	}
}

