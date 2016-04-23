using System;
using UnityEngine.UI;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.UI.Run
{
	using Game = Client.Game.Core.Game;

	public class PlayerStatsHud : MonoBehaviour
	{
		public GameObject healthMax;
		public GameObject healthCurrent;
		private RectTransform healthMaxRect;
		private RectTransform healthCurrentRect;

		public Text bloodTxt;

		private Vector2 baselineSize;
		AttributeMap playerAttributes;

		private float startingMax;


		void Awake() {

			healthMaxRect = healthMax.GetComponent<RectTransform>();
			healthCurrentRect = healthCurrent.GetComponent<RectTransform>();
			baselineSize = healthMaxRect.sizeDelta;
		}


		void Start() {
			playerAttributes = Game.Instance.PossessedActor.Attributes;
			startingMax = playerAttributes[ActorAttributes.MaxHealth];
		}

		void Update() {
			var current = (float)playerAttributes[ActorAttributes.Health];	
			var max = (float)playerAttributes[ActorAttributes.MaxHealth];

			var maxRect = new Vector2(max/startingMax * baselineSize.x, baselineSize.y);

			healthMaxRect.sizeDelta = maxRect;
			Vector2 targetRect = new Vector2(maxRect.x * (current/max), maxRect.y);
			healthCurrentRect.sizeDelta = Vector2.Lerp(healthCurrentRect.sizeDelta, targetRect, .5f);
			bloodTxt.text = "BLOOD: " + playerAttributes[ActorAttributes.BloodBalance];

		}
	}
}

