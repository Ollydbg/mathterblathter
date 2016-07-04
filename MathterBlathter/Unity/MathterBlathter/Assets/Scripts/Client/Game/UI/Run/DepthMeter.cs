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
		MapManager roomManager;
		private float MaxHeight = float.MinValue;
		private float MinHeight = float.MaxValue;

		void Awake() {
			text = GetComponentInChildren<Text>();
		}

		void CacheHeight ()
		{
			foreach( var room in roomManager.Rooms) {
				if(room.Y > MaxHeight)
					MaxHeight = room.Y;

				if(room.Y < MinHeight) 
					MinHeight = room.Y;
			}
		}

		void Start() {
			roomManager = Game.Instance.RoomManager;

			CacheHeight();
		}

		void Update() {
			var currentY = (int)Game.PossessedActor.transform.position.y; 

			text.text = currentY.ToString() + "ft";

			var pctTowerClimb = (currentY - MinHeight) / (MaxHeight-MinHeight);
			float usableScreenSize = Screen.height - (2*text.rectTransform.rect.height);

			var screenSpaceRange = .5f*usableScreenSize;

			var xPos = text.rectTransform.anchoredPosition.x;


			text.rectTransform.anchoredPosition = new Vector2(xPos, pctTowerClimb * screenSpaceRange - screenSpaceRange);
			
		}

		public override void Show ()
		{
		}

		public override void Hide ()
		{
		}

	}
}

