using System;
using Client.Game.Actors;
using Client.Game.Attributes;
using UnityEngine;
using UnityEngine.UI;
using Client.Game.Data;
using Client.Game.Items;

namespace Client.Game.UI
{
    public class ActiveItemHud : RunUI
    {

        public Image LoadBar;
        public Text Label;
        PlayerCharacter playerCharacter;
		bool hasItem;

		float normalYScale;

        public override void Hide()
        {
        }

		public ActiveItem Current {
			get {
				return playerCharacter.ActiveItemController.CurrentItem;
			}
		}

        void Start() {
            playerCharacter = Game.PossessedActor;
			playerCharacter.ActiveItemController.OnItemAdded += cdata => DisplayItem();
            DisplayItem();
			var rt = LoadBar.GetComponent<RectTransform>();

			normalYScale = rt.localScale.y;
        }

		void DisplayItem() {


			if(Current == null) {
				this.gameObject.SetActive(false);
				hasItem = false;
			} else {
				Label.text = Current.ItemData.Name + "\n[SHIFT]";
            	this.gameObject.SetActive(true);
				hasItem = true;
			}
        }


		void Update() {
			if(hasItem) {

				float firedAt = playerCharacter.Attributes[ActorAttributes.LastFiredTime, Current.ItemData.Id];
				float now = Time.realtimeSinceStartup;
				float usableAt = Current.Cooldown + firedAt;

				var pct = (now - firedAt) / (usableAt - firedAt);
				pct = Mathf.Clamp01(pct);

				var targetScale = new Vector3(LoadBar.transform.localScale.x, pct * normalYScale, 1f); 
				LoadBar.transform.localScale = targetScale;
			}
		}

        public override void Show()
        {
        }
    }
}