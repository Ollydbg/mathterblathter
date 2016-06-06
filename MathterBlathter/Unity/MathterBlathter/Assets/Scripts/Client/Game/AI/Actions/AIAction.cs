using System;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Attributes;
using System.Collections.Generic;

namespace Client.Game.AI
{
	using Game = Client.Game.Core.Game;

	public abstract class AIAction
	{
		public virtual void Start(Actor selfActor) {}
		public virtual void End(){}

		public abstract AIResult Update(float dt, Actor actor);
		public AIAction Next;

		internal bool inAbilityRange(Vector3 distanceVec, Actor selfActor) {
			
			return distanceVec.sqrMagnitude < (AbilityRange() * AbilityRange());
		}

		internal float AbilityRange() {
			return 25;
		}

		internal Vector3 PlayerMid
		{
			get {
				var possessed = Game.Instance.PossessedActor;
				return possessed.HalfHeight;
			}
		}


		internal void FaceTarget(Actor selfActor, Vector3 target) {

			float angle = target.x < selfActor.transform.position.x ? -180 : 0;

			selfActor.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}
	}



	public enum AIResult {
		Success,
		Failure,
		Running,
		Invalid
	}
	
	

	//Runs multiple actions, detects early success and early failure
	public class Sequence : AIAction {
		public List<AIAction> Actions = new List<AIAction>();

		public override AIResult Update (float dt, Actor actor)
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
		
		public override AIResult Update (float dt, Actor actor)
		{
			return AIResult.Running;
		}



	}
}

