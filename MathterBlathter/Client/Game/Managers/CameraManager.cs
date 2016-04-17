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
		}

		RoomManager Rooms;

		Vector3 goalPosition {
			get {

				if (TargetTransform != null) {
					return new Vector3 (
						Game.Instance.PossessedActor.GameObject.transform.position.x, 
						Game.Instance.PossessedActor.GameObject.transform.position.y, 
						transform.position.z);
				} else {
					return transform.position;
				}

			}
		}

		float goalSize {
			get {
				return Mathf.Max(Rooms.CurrentRoom.Width*.5f, Rooms.CurrentRoom.Height*.5f) - 5;
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
			throw new NotImplementedException ();
		}

		public void Update (float dt)
		{
		
			//size
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, goalSize, dt);
			//position
			//transform.position = Rooms.CurrentRoom.roomCenter + Vector3.back*10;//goalPosition;
			transform.position = goalPosition;
		}
		#endregion
	}

}

