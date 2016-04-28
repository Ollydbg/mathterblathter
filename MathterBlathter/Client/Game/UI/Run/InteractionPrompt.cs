using System;
using UnityEngine;
using UnityEngine.UI;
using Client.Game.Items;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Actors.Controllers;

namespace Client.Game.UI.Run
{

	using Game = Client.Game.Core.Game;

	public class InteractionPrompt : RunUI
	{

		public Text Label;
		InteractionController controller;
		private bool hidden;

		void Awake(){
			Hide();
		}

		void Start(){
			controller = Game.Instance.PossessedActor.InteractionController;	
		}

		void LateUpdate() {
			var interaction = controller.Closest;
			if(interaction != null && interaction.InteractionTarget != null) {
				Show(interaction);
			} else {
				Hide();
			}

			if(!hidden) {
				var screenPoint = Camera.main.WorldToScreenPoint(interaction.InteractionTarget.transform.position);
				this.transform.position = screenPoint;
			}
		}

		public override void Show() {
			foreach( Transform child in transform) {
				child.gameObject.SetActive(true);
			}
		}

		public void Show(IInteraction interaction) {
			if(hidden) {
				hidden = false;

				Label.text = interaction.GetPrompt() + "\n [E]";

				Show();
			}

		}


		public override void Hide() {

			if(!hidden) {
				hidden = true;
				foreach( Transform child in transform) {
					child.gameObject.SetActive(false);
				}

			}
		}
	}
}

