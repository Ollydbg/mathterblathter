using System;
using UnityEngine;
using Client.Game.Core;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Animation;

namespace Client.Game.Actors
{
	public abstract class Actor
	{
		private static int LastId;
		public int Id = LastId++;
		public GameObject GameObject;
		public AttributeMap Attributes = new AttributeMap (ActorAttributes.GetAll());
		public Client.Game.Core.Game Game;

		public IAnimator Animator = new EmptyAnimator();
		public CharacterData Data;

		public float colliderHeight;
		public Vector3 HalfHeight {
			get {
				return transform.position + new Vector3 (0f, colliderHeight*.5f, 0f);
			}
		}

		public ActorType ActorType {
			get {
				return Data.ActorType;
			}
		}

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

			Attributes.LoadFromData (data.attributeData);
		}

		public virtual void EnterGame(Client.Game.Core.Game game) {
			this.Game = game;
			var coll = GameObject.GetComponentInChildren<Collider> ();
			if(coll != null) {
				colliderHeight = coll.bounds.extents.y;
			}

			//I should break this out into an actor factory instead of having hard linkages
			Game.AbilityManager.AddActor(this);

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

