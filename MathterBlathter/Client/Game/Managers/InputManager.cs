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


			if (Input.GetButtonDown (SWITCH_WEAPON)) {
				TargetActor.Controller.SwitchWeapon ();
			}


			if (Input.GetButtonDown (ATTACK) || Input.GetButtonDown(PS4_SQ)) {
				TargetActor.Controller.Attack ();
			}

			
		}


	}


}

