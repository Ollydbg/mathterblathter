﻿using System;
using UnityEngine;
using Client.Game.Attributes;
using Client.Game.Animation;

namespace Client.Game.Actors
{
	public class CharacterController
	{
		private Character Actor;
		private int angle = 90;
		Rigidbody body;

		public CharacterController(Character actor) {
			this.Actor = actor;
			body = this.Actor.GameObject.GetComponent<Rigidbody> ();
		}
	
		public void MoveRight (float hor)
		{
			float RunSpeed = Actor.Attributes[ActorAttribute.Speed];
			Vector3 oldPos = Actor.GameObject.transform.position;

			var transform = Actor.GameObject.transform;

			transform.position = new Vector3 (oldPos.x + hor * RunSpeed, oldPos.y, oldPos.z);

			if(hor > 0) 
				angle = 90;
			else if(hor < 0)
				angle = -90;

			string animTarget = hor != 0 ? States.RUN : States.IDLE ;
			Actor.Animator.RequestState(animTarget, 0);
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

		}

		public void SwitchWeapon ()
		{

		}

		public void Update(float dt) {
		}



		public void Jump() {

			var jumpHeight = Actor.Attributes[ActorAttribute.JumpHeight];

			this.body.AddForce (Vector3.up * jumpHeight, ForceMode.VelocityChange);
		}

		public void Attack () {
			Actor.Animator.RequestState (States.ATTACK1, 1, 1);	
		}
	}




}

