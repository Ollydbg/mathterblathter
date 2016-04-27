using System;
using UnityEngine;
using UnityEngine.UI;
using Client.Game.Managers;

namespace Client.Game.UI.Run
{
	using Game = Client.Game.Core.Game;

	public class DepthMeter : RunUI
	{

		Text text;
		RoomManager roomManager;

		void Awake() {
			text = GetComponentInChildren<Text>();
		}

		void Start() {
			roomManager = Game.Instance.RoomManager;
		}

		void Update() {
			text.text = roomManager.CurrentRoom.Y.ToString() + "ft";
		}

		public override void Show ()
		{
		}

		public override void Hide ()
		{
		}

	}
}

