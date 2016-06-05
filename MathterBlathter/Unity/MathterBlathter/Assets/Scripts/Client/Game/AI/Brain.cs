using System;
using Client.Game.Actors;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.AI
{
	public class Brain
	{
		public AIAction CurrentAction;
		public Actor Self;

		public Brain (Actor actor)
		{
			this.Self = actor;
		}

		public void Update( float dt) {
			if (CurrentAction != null) {
				if (CurrentAction.Update (dt, Self) != AIResult.Running) {
					CurrentAction.End();
					CurrentAction = CurrentAction.Next;
					CurrentAction.Start(Self);
				}
			}
		}

        public void LoadFromData(AIData aiData)
        {
			var actionData = aiData.ActionData;
			this.CurrentAction = RecurseData(null, actionData);
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

