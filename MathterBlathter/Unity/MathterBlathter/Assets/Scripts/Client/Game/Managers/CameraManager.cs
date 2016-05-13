using System;
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

		public void SetPlayerCharacter (PlayerCharacter player)
		{
			TargetTransform = player.transform;
			transform.position = goalPosition;
		}

		RoomManager Rooms;


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

					return new Vector3 (
						Mathf.Clamp(Game.Instance.PossessedActor.GameObject.transform.position.x, minX, maxX), 
						Mathf.Clamp(Game.Instance.PossessedActor.GameObject.transform.position.y, minY, maxY), 
						transform.position.z);
				} else {
					return transform.position;
				}

			}
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

		public void Update (float dt)
		{

			//size
			//camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, goalSize, dt);
			//position

			transform.position = Vector3.Lerp(transform.position, goalPosition, .1f);
		}

		#endregion
	}

}

