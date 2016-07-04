using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using UnityEngine;

namespace Client.Game.Map.GenConstraints
{
	public interface IGenConstraint
	{
		void InitWithMap(MapData mapData);
		bool Check(RoomData data, int x, int y, int width, int height);
		void Commit(RoomData data, int x, int y, int width, int height);
	}

	public class ConstraintList : List<IGenConstraint>, IGenConstraint {

		public ConstraintList() {
			var tests = this.GetType().Assembly.GetTypes()
				.Where(p=> !p.IsInterface && typeof(IGenConstraint).IsAssignableFrom(p)).ToList();

			tests.Remove(this.GetType());
			this.AddRange(tests.Select(p => (IGenConstraint)Activator.CreateInstance(p)));

		}

		public void InitWithMap (MapData mapData)
		{
			ForEach(p => p.InitWithMap(mapData));
		}
		

		public bool Check(RoomData data, int x, int y, int width, int height) {
			foreach( var constraint in this) {
				if(!constraint.Check(data, x, y, width, height)) {
					Debug.Log(constraint + " says no");
					return false;
				}
			}
			return true;
		}


		public void Commit (RoomData data, int x, int y, int width, int height)
		{
			ForEach(p => p.Commit(data, x, y, width, height));
		}
	}
}

