// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace Client.Game.Core
{
	public class GameManagerProxy : MonoBehaviour
	{

		Game Game;

		void Awake() {
			Game = Game.Instance;
		}

		void Start() {
			
		}

		void Update() {
			Game.Update (Time.deltaTime);
		}


		void FixedUpdate() {
			Game.FixedUpdate();
		}



	}
}

