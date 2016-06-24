using System;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
	using PlayerController = Client.Game.Actors.Controllers.CharacterController2D;

	public class JumpDamage : BuffBase
	{

		private PlayerController controller;
		private bool wasJumping;

		public JumpDamage ()
		{
		}



		#region implemented abstract members of AbilityBase
		float timeLeft = 0f;
		public override void Start ()
		{
			timeLeft = this.Attributes[AbilityAttributes.Duration];

			if(context.targetActor.ActorType == Client.Game.Data.ActorType.Player) {
				var player = (PlayerCharacter)context.targetActor;
				controller = (PlayerController)player.Controller;
				controller.OnGrounded += Controller_OnGrounded;

			}
		}

		void Controller_OnGrounded (Vector3 groundingVelocity)
		{
			if(-groundingVelocity.y > Attributes[AbilityAttributes.FallDamageThreshold]) {
				
				new DamagePayload(context, context.targetActor, Attributes[AbilityAttributes.Damage]).Apply();
			}
		}


		public override void Update (float dt)
		{
			timeLeft -= dt;
			if(controller != null) {
				var isGrounded = controller.IsGrounded;

				if(isGrounded && wasJumping) {
					
				}

				wasJumping = !isGrounded;
			}
			
		}

		public override bool isComplete ()
		{
			return timeLeft <= 0f || controller == null;
		}

		public override void End ()
		{
			if(controller != null) {
				controller.OnGrounded -= Controller_OnGrounded;
			}
		}

		#endregion
	}
}

