using System;
using System.Collections.Generic;

namespace Client.Game.Data
{
	public class AIData : GameData
	{
		public ActionData ActionData;
		public string Name;
		public AIData ()
		{
		}



	}
	
	public class ActionData {
		public List<ActionData> Sequence = new List<ActionData>();
		
		public Type Action;
		public ActionData Next;
		public ActionData(){}
		public ActionData(Type action) {
			Action = action;
		}

		public static ActionData Of<T>() {
			return new ActionData(typeof(T));
		}

		public bool IsSequence {
			get {
				return Action == null;
			}
		}

		public static implicit operator ActionData (Type t) {
			return new ActionData(t);
		}

		public static implicit operator ActionData (Type[] types) {
			var aData = new ActionData();
			foreach( var t in types) 
				aData.Sequence.Add(t);

			return aData;
		}

		public ActionData And(ActionData data) {
			this.Sequence.Add(data);
			return this;
		}

		public ActionData Then(ActionData data) {
			var act = this;
			while(act.Next != null)
				act = act.Next;
			
			act.Next = data;
			return this;
		}

		public ActionData(params Type[] actions) {
			foreach( var t in actions) {
				Sequence.Add(new ActionData(t));
			}
		}
	}
}

