using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using UnityEngine;
using Client.Game.Core;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class CameraManager : IGameManager 
	{
		Transform transform;
		Camera camera;

		public Transform TargetTransform;
		Vector3 shakeAccum = Vector3.zero;
		public float shakeScalar = 2f;
		PlayerCharacter Player;
		public void SetPlayerCharacter (PlayerCharacter player)
		{
			Player = player;
			TargetTransform = player.transform;
			transform.position = goalPosition;
		}

		MapManager Rooms;


		Vector3 goalPosition {
			get {

				if (TargetTransform != null) {

					var room = Rooms.CurrentRoom;

					var vExtent = camera.orthographicSize;
					var hExtent = camera.orthographicSize * Screen.width / Screen.height;

					var minX = hExtent + room.X;
					var maxX = minX + room.Width - 2*hExtent;
					var minY = vExtent + room.Y;
					var maxY = minY + room.Height - 2*vExtent;

					var lookBias = Player.WeaponController.GetAimDirection() * 4f;

					var aa = TargetTransform.position;
					var bb = aa + lookBias;



					return new Vector3 (
						Mathf.Clamp(bb.x, minX, maxX), 
						Mathf.Clamp(bb.y, minY, maxY), 
						transform.position.z);
				} else {
					return transform.position;
				}

			}
		}

		public void Shake(Vector3 amt) {	
			shakeAccum += amt;
		}


		float goalSize {
			get {

				return Rooms.CurrentRoom.Height*.5f;

			}
		}

		#region IGameManager implementation

		public void Start (Game game)
		{ 
			camera = Camera.main;	
			transform = camera.transform;
			Rooms = Game.Instance.RoomManager;
			
		}

		public void Shutdown ()
		{
			TargetTransform = null;
		}


		Vector3 AddShake (Vector3 pos)
		{
			if(shakeAccum != Vector3.zero) {
				pos += shakeAccum * shakeScalar;
				shakeAccum = Vector3.zero;
				return pos;
			}
			return pos;
		}

		public void Update (float dt)
		{

			//size
			//camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, goalSize, dt);
			//position

			var pos = Vector3.Lerp(AddShake(transform.position), goalPosition, .1f);

			transform.position = pos; 
		}

		#endregion
	}

}

