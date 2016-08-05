using System;
using Client.Game.Actors;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.AI
{
	public class Brain
	{
		public AIAction Head;
		public AIAction CurrentAction;
		public Character Self;

		public Brain (Character actor)
		{
			this.Self = actor;
		}

		private bool Logs = true;
		void Log(string msg, params object[] args) {
			if(Logs) 
				UnityEngine.Debug.Log(string.Format(msg, args));		
		}

		public void Update( float dt) {
			if(Self.Destroyed)
				return;
			
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
					//Log("Action {0} was a Failure, moving to Head action: {1}", CurrentAction, Head);
					CurrentAction = CurrentAction.FailureCase;
					CurrentAction.Start(Self);
				}
				
			}
		}

        public void LoadFromData(AIData aiData)
        {
			var actionData = aiData.ActionData;
			this.CurrentAction = RecurseData(actionData, null);
			this.CurrentAction.Start(Self);
			this.Head = CurrentAction;
        }
		

		private AIAction RecurseData(ActionData data, AIAction logicalHead) {

			AIAction brainAction = null;

			if(data.IsSequence) {
				var seq = new Sequence();
				AIAction seqHead = null;
				foreach( var actData in data.Sequence) {
					
					var seqAction = RecurseData(actData, seqHead ?? logicalHead);

					if(seqHead == null) 
						seqHead = seqAction;
					
					seq.Actions.Add(seqAction);
				}
				seq.LocalHead = logicalHead ?? seq;

				if(data.Next != null) {
					seq.Next = RecurseData(data.Next, seq.LocalHead);
				}

				if(data.FailAction != null) {
					seq.FailureCase = RecurseData(data.FailAction, seq.LocalHead);
				}

				return seq;	
			} else {
				brainAction = Make(data);
			}

			if(logicalHead == null)
				logicalHead = brainAction;
			
			brainAction.LocalHead = logicalHead;

			if(data.Next != null) {
				brainAction.Next = RecurseData(data.Next, logicalHead);
			}

			if(data.FailAction != null) {
				brainAction.FailureCase = RecurseData(data.FailAction, logicalHead);
			}

			return brainAction;

		}

		private AIAction Make(ActionData data) {
			return (AIAction)Activator.CreateInstance(data.Action);
		}

    }
}

