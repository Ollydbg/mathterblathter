using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using Client.Game.Map;

namespace Client.Game.UI.Run {
    using Game = Client.Game.Core.Game;

    public class MiniMap : RunUI {
		
		
		
		public GameObject InnerPanel;
		List<Room> SeenRooms = new List<Room>();
		
		private GameObject currentDraw;
		
        public override void Hide()
        {
        }

        public override void Show()
        {
        }
		
		void Start() {
			
			SeenRooms.Add(Game.RoomManager.CurrentRoom);
			
			Game.RoomManager.OnRoomEntered += (actor, oldroom, newRoom) => {
				SeenRooms.Add(newRoom);
				Render();
			};
			Render();
		}

		void Render() {
			
			
			
		}
	}
}
