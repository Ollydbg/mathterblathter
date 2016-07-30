using System;
using UnityEngine.UI;
using UnityEngine;
using Client.Game.Attributes;
using System.Collections.Generic;

namespace Client.Game.UI.Run
{
	using Game = Client.Game.Core.Game;

	public class PlayerStatsHud : RunUI
	{

		public GameObject AnxietyMax;
		public GameObject AnxietyCurrent;

		public Text bloodTxt;

		private Vector2 baselineSize;
		AttributeMap playerAttributes;

		private float startingMax;

		private Bar energyBar;

		public GameObject HealthTickTemplate;
		public GameObject MissingHealthTemplate;
		private HealthStatus healthStatus;

		void Awake() {

		}


		void Start() {
			playerAttributes = Game.Instance.PossessedActor.Attributes;

			energyBar = new Bar(AnxietyCurrent, AnxietyMax, ActorAttributes.Anxiety, ActorAttributes.MaxAnxiety, playerAttributes);
			healthStatus = new HealthStatus(HealthTickTemplate, MissingHealthTemplate, playerAttributes);
		}

		void Update() {
			energyBar.Update();
			healthStatus.Update();
			bloodTxt.text = "BLOOD: " + playerAttributes[ActorAttributes.BloodBalance];

		}

		public override void Show ()
		{
		}

		public override void Hide ()
		{
		}

		public class HealthStatus {
			public GameObject template;

			GameObject hurtTemplate;

			public AttributeMap attributes;

			public List<GameObject> ActiveTicks = new List<GameObject>();
			public List<GameObject> InactiveTicks = new List<GameObject>();
			private const float SPACING = 23f; 
			int cachedTotal;
			int cachedCurrent;

			private int Current {
				get {
					return attributes[ActorAttributes.Health];
				}
			}

			private int Max {
				get {
					return attributes[ActorAttributes.MaxHealth];
				}
			}

			public HealthStatus(GameObject template, GameObject hurtTemplate, AttributeMap attributes) {
				this.template = template;
				this.hurtTemplate = hurtTemplate;
				this.attributes = attributes;

				this.template.SetActive(false);
				this.hurtTemplate.SetActive(false);
			}

			public void Update() {

				if(Current != cachedCurrent || Max != cachedTotal) {
					Rebuild();
				}

			}

			private void Rebuild() {
				ActiveTicks.ForEach(GameObject.Destroy);
				InactiveTicks.ForEach(GameObject.Destroy);

				ActiveTicks.Clear();
				InactiveTicks.Clear();

				cachedTotal = Max;
				cachedCurrent = Current;

				for( var i = 0; i< cachedTotal; i++) {

					var targetPos = template.transform.localPosition + (Vector3.right * SPACING * i);
					GameObject go = null;
					if(i > cachedCurrent) {
						go = GameObject.Instantiate(hurtTemplate);
						InactiveTicks.Add(go);
					
					} else {
						go = GameObject.Instantiate(template);
						ActiveTicks.Add(go);

					}

					go.SetActive(true);
					go.transform.parent = template.transform.parent;
					go.transform.localPosition = targetPos;

				}




			}
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

