using System;
using UnityEngine;

namespace Client.Game.Abilities.Utils
{
	public class EffectTTL : MonoBehaviour
	{
		public EffectTTL ()
		{
		}

		internal float TimeToLive = 0;
		
		void Update() {
			TimeToLive -= Time.deltaTime;

			if(TimeToLive <= 0) {
				GameObject.Destroy(this.gameObject);
			}
		}

		public static void AddToObject(GameObject go, float ttl) {
			go.AddComponent<EffectTTL>().TimeToLive = ttl;
		}
	}


}

