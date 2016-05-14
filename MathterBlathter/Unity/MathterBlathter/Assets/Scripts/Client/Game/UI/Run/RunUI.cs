using System;
using UnityEngine;

namespace Client
{
	public abstract class RunUI : MonoBehaviour
	{

		public Client.Game.Core.Game Game {
			get {
				return Client.Game.Core.Game.Instance;
			}
		}


		public abstract void Show();
		public abstract void Hide();
		public bool ConsumeInput() {
			return false;
		}

	}


}

