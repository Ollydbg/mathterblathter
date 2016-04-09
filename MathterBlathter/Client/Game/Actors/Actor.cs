using System;
using UnityEngine;
using Client.Game.Core;
using Client.Game.Attributes;

namespace Client.Game.Actors
{
	public class Actor
	{
		private static int LastId;
		public int Id = LastId++;
		public GameObject GameObject;
		public AttributeMap Attributes = new AttributeMap (ActorAttribute.GetAll());


		public Transform transform {
			get {
				return GameObject.transform;
			}
		}

		public Actor ()
		{

		}



		public virtual void EnterGame(Client.Game.Core.Game game) {
			
		}



		public virtual void Update(float dt) {
			
		}

		public virtual void LateUpdate(float dt) {

		}
	}
}

