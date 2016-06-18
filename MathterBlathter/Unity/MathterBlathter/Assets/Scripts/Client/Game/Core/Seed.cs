using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Core
{
	public class Seed
	{
		public int Value;
		private Random random;

		public Seed (int seedValue)
		{
			Random.seed = seedValue;
		}

		public float NextFloat() {

			return Random.value;

		}


		public bool RollAgainst(float ltOrEqualTo) {
			return NextFloat() <= ltOrEqualTo;
		}

		public float InRange(float min, float max) {
			return Random.Range(min, max);
		}

		public int Next(int max) {
			return Random.Range(0, max);
		}

		public T RandomInList<T>(List<T> items) {
			if(items.Count == 0)
				return default(T);
					
			return items[Next(items.Count)];
		}

		public Vector3 RandomUnitVector() {
			return new Vector3(NextFloat(), NextFloat(), 0f);
		}

	}
}

