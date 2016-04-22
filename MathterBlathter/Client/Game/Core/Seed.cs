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

		public int Next() {

			return random.Next();
		}
	}
}

