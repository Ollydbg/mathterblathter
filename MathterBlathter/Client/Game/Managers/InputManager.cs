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
		public static string PS4_SQ = "PS4_SQ";
		public static string PS4_R1 = "R1";
		public static string PS4_TRI = "PS4_TRI";
		public static string PS4_RIGHT_STICK_X = "PS4_RIGHT_STICK_X";
		public static string PS4_RIGHT_STICK_Y = "PS4_RIGHT_STICK_Y";
		public static string JUMP = "Jump";
		public static string SWITCH_WEAPON = "SwitchWeapon";
		public static string ATTACK = "Attack";
		public static string Aim = "Aim";
		public static string Interact = "Interact";
		public static string PICKUP = "Pickup";


		public PlayerCharacter TargetActor;

		public InputManager ()
		{
		}

		public void SetPlayerCharacter (PlayerCharacter player)
		{
			this.TargetActor = player;
		}

		public void Start (Game game)
		{
			bindControls ();

		}
		public void Shutdown ()
		{
			
		}

		private void bindControls() {

		}

		public void Update (float dt)
		{
			
			if (Input.GetButton (JUMP)) {
				TargetActor.Controller.Jump ();
			}
			if(Input.GetButtonUp(JUMP)) {
				TargetActor.Controller.StopJumping();
			}

			if(Input.GetButtonDown(PICKUP)) {
				TargetActor.PickupController.PickupClosest();
			}

			var hor = Input.GetAxis (HORIZONTAL);
			var controllerHor = (Input.GetAxis(HORIZONTAL_D_PAD));
			TargetActor.Controller.MoveRight (hor+controllerHor);


			if (Input.GetButtonDown (SWITCH_WEAPON) || Input.GetButtonDown(PS4_TRI)) {
				TargetActor.WeaponController.ToggleWeapon ();
			}

			TargetActor.WeaponController.Aim(getAimingVector());

			if (Input.GetButtonDown (ATTACK) || Input.GetButtonDown(PS4_SQ)) {
				TargetActor.WeaponController.Attack ();
			}

			
		}

		private bool mousing = true;
		private Vector3 getAimingVector() {
			float controllerX = Input.GetAxis(PS4_RIGHT_STICK_X);
			float controllerY = Input.GetAxis(PS4_RIGHT_STICK_Y);

			if(controllerX + controllerY != 0) {
				mousing = false;
			}


			if(mousing) {
				return getMousingDirection();
			} else {
				return Vector3.right*controllerX + Vector3.up*controllerY;
			}

		}
		private Vector3 getMousingDirection() {
			var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var worldDir3 = worldPoint - TargetActor.transform.position;
			return new Vector3(worldDir3.x, worldDir3.y).normalized;
		}


	}


}

