﻿using System;
using Client.Game.Actors;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.AI
{
	public class Brain
	{
		public AIAction Head;
		public AIAction CurrentAction;
		public Actor Self;

		public Brain (Actor actor)
		{
			this.Self = actor;
		}

		private bool Logs = true;
		void Log(string msg, params object[] args) {
			if(Logs) 
				UnityEngine.Debug.Log(string.Format(msg, args));
				
		}
		public void Update( float dt) {
			if (CurrentAction != null) {
				var result = CurrentAction.Update(dt, Self);
				
				if(result == AI.AIResult.Running)
					return;
					
				if(result == AIResult.Success) {
					CurrentAction.End();
					//Log("Action {0} was successful, moving to Next action: {1}", CurrentAction, CurrentAction.Next);
					CurrentAction = CurrentAction.Next;
					CurrentAction.Start(Self);
				}
				
				if(result == AIResult.Failure) {
					CurrentAction.End();
					//this should probably go back to logical parent
					CurrentAction = Head;
					CurrentAction.Start(Self);
				}
				
			}
		}

        public void LoadFromData(AIData aiData)
        {
			var actionData = aiData.ActionData;
			this.CurrentAction = RecurseData(null, actionData);
			this.Head = CurrentAction;
        }
		
		AIAction RecurseData(AIAction head, ActionData action) {
			
			AIAction brainAction;
			
			if(action.Action != null) {
				brainAction = (AIAction)Activator.CreateInstance(action.Action);
			} else {
				Sequence sequenceAction = new Sequence();
				for( var i = 0; i< action.Sequence.Count; i++) {
					sequenceAction.Actions.Add((AIAction)Activator.CreateInstance(action.Sequence[i].Action));	
				}
				brainAction = sequenceAction;
			}
			
			if(head == null) head = brainAction;
			
			if(action.Next != null) {
				var child = RecurseData(head, action.Next);
				child.Next = head;
				brainAction.Next = child;
			} else {
				brainAction.Next = head;
			}
			
			return brainAction;
		}
    }
}

