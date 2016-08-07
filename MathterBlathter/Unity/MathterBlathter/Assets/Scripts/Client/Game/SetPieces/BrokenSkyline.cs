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
			jetStartingPos = Jet.transform.position;
			jetUp = Jet.transform.up;
			Jet.SetActive(false);
			Game.Instance.PossessedActor.GameObject.SetActive(false);
		}
		void CameraTrack() {
			Game.Instance.CameraManager.SetOverrideTarget(Train.transform);
		}

		void PlayVO() {
			var clip = Resources.Load("VoiceOver/Echo-7/killTheOldMasters") as AudioClip;
			var audioSource = Camera.main.GetComponent<AudioSource>();
			audioSource.PlayOneShot(clip);
			
		}

		void PlayMusic() {

			PlayVO();

			Game.Instance.CameraManager.ClearOverrideTarget();
			Game.Instance.MusicManager.StartRun();

			Game.Instance.PossessedActor.GameObject.SetActive(true);
			Game.Instance.PossessedActor.Controller.MoveTo(PlayerEntrancePosition);
		}

		void Jets() {

		}


		Vector3 sampledTrainPos;
		public float maxShake = 2.5f;

		void Update() {


			var moveDelta = Train.gameObject.transform.position - sampledTrainPos;
			var shakeMag = moveDelta.magnitude;
			shakeMag = Mathf.Clamp(shakeMag, 0, maxShake);

			var shake = UnityEngine.Random.insideUnitSphere * (shakeMag);
			Game.Instance.CameraManager.Shake(shake);
			sampledTrainPos = Train.gameObject.transform.position;

		}
	}

}

