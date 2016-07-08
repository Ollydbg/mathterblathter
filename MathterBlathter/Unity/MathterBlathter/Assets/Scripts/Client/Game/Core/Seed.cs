using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Core
{
	public class Seed
	{
		public int Value;


		public Seed (int seedValue)
		{

			Debug.Log("Seeding with value: " + seedValue);
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

		public List<T> TakeFromList<T>(List<T> items, int num) {
			Dictionary<T, bool> taken = new Dictionary<T, bool>();
			var buff = new List<T>();
			while (num > 0) {
				var item = RandomInList(items);
				if(item == null)
					return buff;
				
				if(!taken.ContainsKey(item)){
					buff.Add(item);
					num--;
				}

			}

			return buff;
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

