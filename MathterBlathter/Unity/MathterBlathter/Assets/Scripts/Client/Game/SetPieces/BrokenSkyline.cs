using System;
using UnityEngine;

namespace Client.Game.SetPieces
{
	using Game = Client.Game.Core.Game;

	public class BrokenSkyline : MonoBehaviour
	{
		public GameObject Jet;
		public float JetSpeed = 1f;
		public float Turbulence = 1f;
		private Vector3 lastLinearPosition;
		public float maxDistance = 60;
		public float cameraShakeFactor = .2f;

		Vector3 jetStartingPos;
		float accumulator = 0f;
		Vector3 jetUp;

		void Awake(){}
		void Start() {
			jetStartingPos = Jet.transform.position;
			jetUp = Jet.transform.up;
		}

		void Update() {

			accumulator += Time.deltaTime;

			var turbulence = Jet.transform.right * UnityEngine.Random.Range(-1f, 1f) * Turbulence;

			Jet.transform.position = jetStartingPos + accumulator * JetSpeed * jetUp + turbulence;

			Vector2 actor2d = Game.Instance.PossessedActor.transform.position;
			Vector2 jet2d = Jet.transform.position;
			var distance = (jet2d - actor2d).magnitude;

			var shake = UnityEngine.Random.insideUnitSphere * cameraShakeFactor * (maxDistance - distance) / maxDistance;

			Game.Instance.CameraManager.Shake(shake);

		}
	}
}

