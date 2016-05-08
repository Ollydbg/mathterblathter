using System;
using UnityEngine;

namespace Client.Game.Items
{
	public class ItemBuffScript : MonoBehaviour
	{

		private Vector3 startPosition;
		private Vector3 rotationVector;

		void Start() {
			this.startPosition = gameObject.transform.position + Vector3.up*1f;
			this.rotationVector = UnityEngine.Random.insideUnitSphere;
		}

		void Update() {
			this.gameObject.transform.position = startPosition + Vector3.up*(float)Math.Sin(Time.realtimeSinceStartup) * .5f;
			this.gameObject.transform.Rotate(rotationVector, 1f, Space.Self);
		}

	}
}

