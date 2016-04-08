using System;
using Client.Game.Core.Managers;
using System.Collections.Generic;
using Client.Game.Core.Actors;
using UnityEngine;

namespace Client.Game.Core.Managers
{
	class CameraManager : IGameManager 
	{
		Transform transform;
		Camera camera;

		Vector3 goalPosition {
			get {
				return new Vector3 (
					Game.Instance.PossessedActor.GameObject.transform.position.x, 
					Game.Instance.PossessedActor.GameObject.transform.position.y, 
					transform.position.z);
			}
		}

		#region IGameManager implementation
		public void Init ()
		{
			camera = Camera.main;	
			transform = camera.transform;
		}
		public void Update (float dt)
		{
			//so dumb
			transform.position = goalPosition;

		}
		#endregion
	}

}

