using System;
using UnityEngine;


namespace Client.Game.UI.Titles
{
	public class VortexWigglerEffect : MonoBehaviour
	{
        public bool wiggle = false;

        public float xRadiusFrom;
        public float xRadiusTo;
        public float radiusAlpha;

        public float yRadiusFrom;
        public float yRadiusTo;
        UnityStandardAssets.ImageEffects.Fisheye fisheye;
        void Start() {
            fisheye = GetComponent<UnityStandardAssets.ImageEffects.Fisheye>();
        }


        void Update() {
            if(wiggle) {
                wiggle = false;

                fisheye.strengthX = xRadiusFrom;    
                fisheye.strengthY = yRadiusFrom;
            }
            
            fisheye.strengthX = Mathf.Lerp(fisheye.strengthX, xRadiusTo, radiusAlpha);
            fisheye.strengthY = Mathf.Lerp(fisheye.strengthY, xRadiusTo, radiusAlpha);

        }
    }
}