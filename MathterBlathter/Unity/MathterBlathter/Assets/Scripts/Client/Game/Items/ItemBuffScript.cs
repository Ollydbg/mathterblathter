using System;
using UnityEngine;

namespace Client.Game.Items
{
	public class ItemBuffScript : MonoBehaviour
	{

		private Vector3 startPosition;
		private Vector3 rotationVector;
		Rigidbody2D Rigidbody;
		void Start() {
			this.startPosition = gameObject.transform.position + Vector3.up*1f;
			this.rotationVector = UnityEngine.Random.insideUnitSphere;
			this.Rigidbody = gameObject.GetComponent<Rigidbody2D>();

		}

		void Update() {
			var pos = startPosition + Vector3.up*(float)Math.Sin(Time.realtimeSinceStartup) * .5f;
			if(this.Rigidbody != null) {
				this.Rigidbody.position = pos;
			} else {
				this.gameObject.transform.position = pos;
				this.gameObject.transform.Rotate(rotationVector, 1f, Space.Self);
				
			}
		}

	}
}

