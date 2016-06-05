using System;
using System.Collections.Generic;

namespace Client.Game.Data
{
	public class AIData : GameData
	{
		public ActionData ActionData;
		
		public AIData ()
		{
		}



	}
	
	public class ActionData {
		public List<ActionData> Sequence = new List<ActionData>();
		
		public Type Action;
		
		public ActionData Next;
		
		public ActionData(Type action) {
			this.Action = action;
		}
		public ActionData(params Type[] actions) {
			foreach( var t in actions) {
				Sequence.Add(new ActionData(t));
			}
		}
	}
}

