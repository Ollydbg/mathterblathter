using System;
using UnityEngine;
using Client.Game.Actors;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class InputManager : IGameManager
	{
		public static string HORIZONTAL = "Horizontal";
		public static string PS4_HORIZONTAL = "PS4_HORIZONTAL";
		public static string VERTICAL = "Vertical";
		public static string HORIZONTAL_D_PAD = "PS4_DpadHorizontal";
		public static string PS4_SQ = "PS4_SQ";
		public static string PS4_R1 = "R1";
		public static string PS4_TRI = "PS4_TRI";
		public static string JUMP = "Jump";
		public static string SWITCH_WEAPON = "SwitchWeapon";
		public static string ATTACK = "Attack";
		public static string Aim = "Aim";
		public static string Interact = "Interact";
		public static string DUCK = "Duck";
		public static string AIM_RAY = "AIM_RAY";
		public static string PS4_RSTICK_H = "PS4_RSTICK_H";
		public static string PS4_RSTICK_V = "PS4_RSTICK_V";
		public static string ACTIVE_ITEM = "ActiveItem";
		public static string DODGE_ROLL = "DodgeRoll";

		public static KeyCode PAUSE = KeyCode.Escape;
		private UIManager UILayer;

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
			UILayer = game.UIManager;
		}
		public void Shutdown ()
		{
			TargetActor = null;
		}

		private void bindControls() {

		}

		public void Update (float dt)
		{
			
			if(Input.GetButton (JUMP)) {
				TargetActor.Controller.Jump ();
			}
			if(Input.GetButtonUp(JUMP)) {
				TargetActor.Controller.StopJumping();
			}

			if(Input.GetButtonDown(Interact)) {
				TargetActor.InteractionController.InteractClosest();
			}

			if(!UILayer.TryConsume()) {

				var hor = Input.GetAxis (HORIZONTAL);
				var controllerHor = (Input.GetAxis(HORIZONTAL_D_PAD));
				var stickHor = Input.GetAxis(PS4_HORIZONTAL);
				
				TargetActor.Controller.MoveRight (hor+controllerHor+stickHor);
			
				if (Input.GetButtonDown (SWITCH_WEAPON) || Input.GetButtonDown(PS4_TRI)) {
					TargetActor.WeaponController.ToggleWeapon ();
				}

				if(Input.GetButtonDown(ACTIVE_ITEM)) {
					TargetActor.ActiveItemController.UseCurrent();
				}

				if (Input.GetButton (ATTACK)) {
					TargetActor.WeaponController.Attack ();
				} 
				if(Input.GetButtonUp(ATTACK)) {
					TargetActor.WeaponController.AttackStop();
				}
			

				if(Input.GetButtonDown(AIM_RAY)) {
					AddControllerAiming();
				}


				TargetActor.Controller.Ducking = Input.GetButton(DUCK);

			}

			TargetActor.WeaponController.AimDirection(new Vector3(Input.GetAxis(PS4_RSTICK_H), Input.GetAxis(PS4_RSTICK_V)));

		}




		private void AddControllerAiming() {
			var context = new Client.Game.Abilities.AbilityContext(TargetActor, Client.Game.Data.AbilityDataTable.CONTROLLER_AIM_ASSIST);
			TargetActor.Game.AbilityManager.ActivateAbility(context);
		}

	}


}

