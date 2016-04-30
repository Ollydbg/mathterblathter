using System;

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

		public bool RollAgainst(float ltOrEqualTo) {
			return random.NextDouble() <= ((double)ltOrEqualTo);
		}

		public int Next(int max) {
			return random.Next(max);
		}

		public int Next() {
			
			return random.Next();
		}
	}
}

