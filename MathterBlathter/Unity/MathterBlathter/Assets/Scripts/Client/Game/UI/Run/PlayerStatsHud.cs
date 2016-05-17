using System;
using UnityEngine.UI;
using UnityEngine;
using Client.Game.Attributes;

namespace Client.Game.UI.Run
{
	using Game = Client.Game.Core.Game;

	public class PlayerStatsHud : RunUI
	{
		public GameObject healthMax;
		public GameObject healthCurrent;
		private RectTransform healthMaxRect;
		private RectTransform healthCurrentRect;

		public GameObject AnxietyMax;
		public GameObject AnxietyCurrent;

		public Text bloodTxt;

		private Vector2 baselineSize;
		AttributeMap playerAttributes;

		private float startingMax;

		private Bar healthBar;
		private Bar energyBar;

		void Awake() {

		}


		void Start() {
			playerAttributes = Game.Instance.PossessedActor.Attributes;

			healthBar = new Bar(healthCurrent, healthMax, ActorAttributes.Health, ActorAttributes.MaxHealth, playerAttributes);
			energyBar = new Bar(AnxietyCurrent, AnxietyMax, ActorAttributes.Anxiety, ActorAttributes.MaxAnxiety, playerAttributes);

		}

		void Update() {
			healthBar.Update();
			energyBar.Update();
			bloodTxt.text = "BLOOD: " + playerAttributes[ActorAttributes.BloodBalance];

		}

		public override void Show ()
		{
		}

		public override void Hide ()
		{
		}

		public class Bar {
			public GameObject currentBar;
			public GameObject maxBar;
			public GameAttributeI currentAttr;
			public GameAttributeI maxAttr;

			private RectTransform maxRect;
			private RectTransform currentRect;

			private float startingMax;
			private Vector2 baselineSize;
			AttributeMap map;
			public Bar(GameObject cbar, GameObject maxBar, GameAttributeI currentAtr, GameAttributeI maxAttr, AttributeMap map) {
				maxRect = maxBar.GetComponent<RectTransform>();
				currentRect = cbar.GetComponent<RectTransform>();
				baselineSize = maxRect.sizeDelta;
				this.currentAttr = currentAtr;
				this.maxAttr = maxAttr;

				this.map = map;
				startingMax = map[maxAttr];
			}



			public void Update() {
				var current = (float)map[currentAttr];	
				var max = (float)map[maxAttr];

				var newMaxRect = new Vector2(max/startingMax * baselineSize.x, baselineSize.y);

				maxRect.sizeDelta = newMaxRect;
				Vector2 targetRect = new Vector2(newMaxRect.x * (current/max), newMaxRect.y);
				currentRect.sizeDelta = Vector2.Lerp(currentRect.sizeDelta, targetRect, .5f);
			}

		}


	}
}

