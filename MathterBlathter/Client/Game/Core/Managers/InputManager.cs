using System;
using UnityEngine;
using Client.Game.Core.Actors;

namespace Client.Game.Core.Managers
{
	public class InputManager : IGameManager
	{
		public static string HORIZONTAL = "Horizontal";
		public static string HORIZONTAL_D_PAD = "PS4_DpadHorizontal";
		public static string JUMP = "Jump";

		public CharacterActor TargetActor;

		public InputManager ()
		{
		}



		#region IGameManager implementation

		public void Init ()
		{
			bindControls ();

			this.TargetActor = Game.Instance.PossessedActor;
		}

		private void bindControls() {

		}

		public void Update (float dt)
		{
			var hor = Input.GetAxis (HORIZONTAL);
			TargetActor.Controller.MoveRight (hor);

			if (Input.GetButtonDown (JUMP)) {
				TargetActor.Controller.Jump ();
			}
			
		}

		#endregion
	}
}

