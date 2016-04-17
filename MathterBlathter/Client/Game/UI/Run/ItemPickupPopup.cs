using System;
using UnityEngine;
using UnityEngine.UI;
using Client.Game.Items;
using Client.Game.Actors;

namespace Client.Game.UI.Run
{

	using Game = Client.Game.Core.Game;

	public class ItemPickupPopup : MonoBehaviour
	{

		public Text Label;
		PickupController pickupController;
		private bool hidden;

		void Awake(){
			Hide();
		}

		void Start(){
			pickupController = Game.Instance.PossessedActor.PickupController;	
		}

		void Update() {
			var pickup = pickupController.ClosestPickup;
			if(pickup != null) {
				Show(pickup);
			} else {
				Hide();
			}

			if(!hidden) {
				var screenPoint = Camera.main.WorldToScreenPoint(pickup.transform.position);
				this.transform.position = screenPoint;
			}
		}

		void Show(Pickup item) {
			if(hidden) {
				hidden = false;
				Label.text = item.Data.Name + "\n[E]";
				foreach( Transform child in transform) {
					child.gameObject.SetActive(true);
				}
			}

		}


		void Hide() {

			if(!hidden) {
				hidden = true;
				foreach( Transform child in transform) {
					child.gameObject.SetActive(false);
				}

			}
		}
	}
}

