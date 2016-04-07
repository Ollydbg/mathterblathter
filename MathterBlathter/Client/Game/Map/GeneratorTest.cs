using System;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;

namespace Client.Game.Map
{
	public class GeneratorTest : MonoBehaviour
	{
		public const int NUM_ROOMS = 2;

		public void Awake ()
		{
			var rooms = new DataMocker().Mock (500);
			var generator = new MapGenerator ();
			generator.GenerateFromDataSet (rooms);
		}


	}
}

