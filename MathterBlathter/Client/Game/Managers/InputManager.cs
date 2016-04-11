using System;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class InputManager : IGameManager
	{
		public static string HORIZONTAL = "Horizontal";
		public static string HORIZONTAL_D_PAD = "PS4_DpadHorizontal";
		public static string PS4_X = "PS4_X";
		public static string PS4_SQ = "PS4_SQ";
		public static string JUMP = "Jump";
		public static string SWITCH_WEAPON = "SwitchWeapon";
		public static string ATTACK = "Attack";
		public static string Aim = "Aim";
		public static string Interact = "Interact";


		public Character TargetActor;

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
			var controllerHor = (Input.GetAxis(HORIZONTAL_D_PAD));
			TargetActor.Controller.MoveRight (hor+controllerHor);

			if (Input.GetButtonDown (JUMP) || Input.GetButtonDown(PS4_X)) {
				TargetActor.Controller.Jump ();
			}

			if (Input.GetButtonDown (SWITCH_WEAPON)) {
				TargetActor.Controller.SwitchWeapon ();
			}


			if (Input.GetButtonDown (ATTACK) || Input.GetButtonDown(PS4_SQ)) {
				TargetActor.Controller.Attack ();
			}

			
		}

		#endregion
	}
}

