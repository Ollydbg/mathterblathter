using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

namespace Client.Game.UI.Titles
{
	[ExecuteInEditMode]
	public class StudioLogoScreen : MonoBehaviour
	{

		public float BloomIntensity;

		public float ChromaticAbbr;

		public float TriangleZ;


		public GameObject Triangle;

		void Awake() {}
		void Start() {
			this.shaftsComp = GetComponent<SunShafts>();
			this.abbrComp = GetComponent<VignetteAndChromaticAberration>();
			this.bloomComp = GetComponent<AmplifyBloom.AmplifyBloomBase>();
		}

		
		SunShafts shaftsComp;
		AmplifyBloom.AmplifyBloomBase bloomComp;
		VignetteAndChromaticAberration abbrComp;
		

		void Update() {
			abbrComp.chromaticAberration = ChromaticAbbr;
			this.bloomComp.OverallIntensity = BloomIntensity;
			var pos = Triangle.transform.position;
			pos.z = TriangleZ;
			Triangle.transform.position = pos;
		}

		void NextScene() {
			SceneManager.LoadScene("MainMenu");
		}
		
	}
}

