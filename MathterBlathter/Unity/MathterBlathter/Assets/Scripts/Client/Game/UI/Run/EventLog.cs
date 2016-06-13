using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Game.UI
{
	public class EventLog : RunUI
	{
		public Text Label;
		private bool showing = false;
		private const float SHOW_TIME = 2f;
		private float currentDuration = 0f;
		private static Queue<string> queue = new Queue<string>();
		

		public void Start() {
			Label.text = "";
		}

		public static void Post(string msg) {
			queue.Enqueue(msg);
		}
        public override void Hide()
        {
        }

		void Update() {
			
			if(showing) {
				currentDuration -= Time.deltaTime;
				if(currentDuration < 0f) {
					if(!TryAdvance()) {
						Label.text = "";
						showing = false;
					} 
				}
				
			} else if(queue.Count > 0) {
				showing = true;
			}
		}

		private bool TryAdvance() {
			if(queue.Count > 0) {
				showing = true;
				var msg = queue.Dequeue();
				Label.text = msg;
				currentDuration = SHOW_TIME;

				return true;
			}
			return false;
		}

        public override void Show()
        {
        }
    }
}