using System;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game.Data.Ascii
{
	public class Chunk : List<Vector3>
	{
		public Chunk ()
		{
		}


		//set to opposite maxes, so that they'll be set during enumeration
		//otherwise something with a positive min x won't be able to 
		//override the default minX of 0
		float minX = float.MaxValue;
		float maxX = float.MinValue;
		float minY = float.MaxValue;
		float maxY = float.MinValue;

		public float Width {
			get {
				return maxX - minX + 1;
			}
		}

		public float Height {
			get {
				return maxY - minY + 1;
			}
		}


		public Chunk (IEnumerable<Vector3> enumerable)
		{
			this.AddRange(enumerable);

			foreach( var vect in this) { 
				if (vect.x < minX ) {
					minX = vect.x;
				}
				if (vect.x > maxX ) {
					maxX = vect.x;
				}
				if (vect.y < minY ) {
					minY = vect.y;
				}
				if (vect.y > maxY ) {
					maxY = vect.y;
				}
			}
		}

		public Vector3 Origin {
			get {
				return this[0];
			}
		}
	}
}

