using System;
using UnityEngine;
using Client.Game.Core;
using Client.Game.Attributes;
using Client.Game.Data;

namespace Client.Game.Actors
{
	public abstract class Actor
	{
		private static int LastId;
		public int Id = LastId++;
		public GameObject GameObject;
		public AttributeMap Attributes = new AttributeMap (ActorAttributes.GetAll());
		public Client.Game.Core.Game Game;

		public CharacterData Data;

		public abstract ActorType ActorType {get;}

		public Transform transform {
			get {
				return GameObject.transform;
			}
		}

		public Actor ()
		{

		}


		public virtual void LoadFromData(CharacterData data) {
			this.Data = data;
		}

		public virtual void EnterGame(Client.Game.Core.Game game) {
			this.Game = game;
		}



		public virtual void Update(float dt) {
			
		}

		public virtual void FixedUpdate() {
		}

		public override string ToString ()
		{
			return string.Format ("[Actor: name={0}]", GameObject.name);
		}

	}

}

