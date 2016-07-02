using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Client.Game.UI.Titles
{
	[ExecuteInEditMode]
	public class StudioLogoScreen : MonoBehaviour
	{

		public float BloomIntensity;

		public float ChromaticAbbr;

		public float TriangleZ;

		public float ShaftY;
		
		public float GridZ;

		public GameObject Triangle;
		public GameObject ShaftsCaster;
		public GameObject GridTop;
		public GameObject GridBottom;

		public string NextSceneName = "MainMenu";

		void Awake() {}
		void Start() {
			this.abbrComp = GetComponent<VignetteAndChromaticAberration>();
			this.bloomComp = GetComponent<AmplifyBloom.AmplifyBloomBase>();

		}

		
		AmplifyBloom.AmplifyBloomBase bloomComp;
		VignetteAndChromaticAberration abbrComp;
		

		void Update() {
			abbrComp.chromaticAberration = ChromaticAbbr;
			this.bloomComp.OverallIntensity = BloomIntensity;
			var pos = Triangle.transform.position;
			pos.z = TriangleZ;
			Triangle.transform.position = pos;
		
			pos = ShaftsCaster.transform.position;
			pos.y = ShaftY;
			ShaftsCaster.transform.position = pos;

			pos = GridTop.transform.localPosition;
			pos.z = GridZ;
			GridTop.transform.localPosition = pos;

			pos = GridBottom.transform.localPosition;
			pos.z = GridZ;
			GridBottom.transform.localPosition = pos;

		}

		void NextScene() {

			StartCoroutine(LoadNext());
		}

		IEnumerator LoadNext() {

			var next = SceneManager.LoadSceneAsync(NextSceneName);

			while(!next.isDone) {
				yield return null;
			}
			//SceneManager.SetActiveScene(SceneManager.GetSceneByName(NextSceneName));

		}
	}
}

