using System;
using UnityEngine;
using Client.Game.Data;

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
		public GameObject Train;
		public GameObject PlayerEntrance;

		Vector3 jetStartingPos;
		float accumulator = 0f;
		Vector3 jetUp;

		Vector2 PlayerEntrancePosition {
			get {
				return new Vector2(
					PlayerEntrance.transform.position.x,
					PlayerEntrance.transform.position.y
				);
			}
		}

		void Awake(){}
		void Start() {
			//jetStartingPos = Jet.transform.position;
			//jetUp = Jet.transform.up;
			Game.Instance.PossessedActor.GameObject.SetActive(false);
		}
		void CameraTrack() {
			Game.Instance.CameraManager.SetOverrideTarget(Train.transform);
		}

		void PlayMusic() {
			Game.Instance.CameraManager.ClearOverrideTarget();
			Game.Instance.MusicManager.Play(MusicDataTable.RUN_MUSIC);

			Game.Instance.PossessedActor.GameObject.SetActive(true);
			Game.Instance.PossessedActor.Controller.MoveTo(PlayerEntrancePosition);
		}

		void Jets() {

		}


		void Update() {
			


			accumulator += Time.deltaTime;

			/*
			var turbulence = Jet.transform.right * UnityEngine.Random.Range(-1f, 1f) * Turbulence;
			Jet.transform.position = jetStartingPos + accumulator * JetSpeed * jetUp + turbulence;
			
			Vector2 actor2d = Game.Instance.PossessedActor.transform.position;
			Vector2 jet2d = Jet.transform.position;
			var distance = (jet2d - actor2d).magnitude;
			distance = Mathf.Clamp(distance, 0, maxDistance);*/
			var clampedTime = (2 - accumulator);
			clampedTime = Mathf.Clamp(clampedTime, 0, 1f);
			var shake = UnityEngine.Random.insideUnitSphere * (clampedTime);//* cameraShakeFactor * (maxDistance - distance) / maxDistance;

			Game.Instance.CameraManager.Shake(shake);


		}
	}

}

