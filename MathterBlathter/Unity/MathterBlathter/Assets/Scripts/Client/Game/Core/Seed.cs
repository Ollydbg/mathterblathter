using System;
using System.Collections.Generic;

namespace Client.Game.Core
{
	public class Seed
	{
		public int Value;
		private Random random;

		public Seed (int seedValue)
		{
			random = new Random(Value);
		}

		public float NextFloat() {
			return (float)random.NextDouble();
		}


		public bool RollAgainst(float ltOrEqualTo) {
			return NextFloat() <= ltOrEqualTo;
		}

		public float InRange(float min, float max) {
			float range = max - min;
			return (NextFloat() * range) + min;
		}

		public int Next(int max) {
			return random.Next(max);
		}

		public T RandomInList<T>(List<T> items) {
			return items[Next(items.Count)];
		}

		public int Next() {
			
			return random.Next();
		}
	}
}

