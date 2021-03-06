﻿using System;
using UnityEngine;
using Client.Game.Core;
using Client.Game.Attributes;
using Client.Game.Data;
using Client.Game.Animation;
using Client.Game.Items;
using Client.Game.Abilities.Timelines;

namespace Client.Game.Actors
{
	public abstract class Actor
	{
		private static int LastId;
		public int Id = LastId++;
		public GameObject GameObject;
		public AttributeMap Attributes = new AttributeMap (ActorAttributes.GetAll());
		public Client.Game.Core.Game Game;
		public WeaponController WeaponController;

		public IAnimator Animator = new EmptyAnimator();
		public CharacterData Data;
		public RoomData.Spawn SpawnData;

		public TimelineRunner TimelineRunner;

		private bool _pendingDelete = false;
		public bool Destroyed {
			get { return _pendingDelete; }
		}
		
		public delegate void DestroyedDelegate(Actor actor);
		public event DestroyedDelegate OnDestroyed;

		public ActorRef GameObjectRef;

		public float colliderHeight;
		public Vector3 HalfHeight {
			get {
				return transform.position + new Vector3 (0f, colliderHeight*.5f, 0f);
			}
		}
		public Vector2 HalfHeight2D {
			get {
				return new Vector2(transform.position.x, transform.position.y + colliderHeight * .5f);
			}
		}

		public Collider2D TerrainCollider { get; private set; }

		public bool FacingRight {
			get {
				return GameObject.transform.localScale.x > 0f;
			}
		}
		public bool FacingLeft { get { return !FacingRight; } }
			
		public void FaceRight() {
			var scale = GameObject.transform.localScale;
			if(scale.x < 0f) 
			{
				scale.x *= -1f;
				GameObject.transform.localScale = scale;
			}
		}
		public void FaceLeft() {
			var scale = GameObject.transform.localScale;
			if(scale.x > 0f) 
			{
				scale.x *= -1f;
				GameObject.transform.localScale = scale;
			}
		}

		public ActorType ActorType {
			get {
				return Data.ActorType;
			}
		}

		
		public bool IsHeld {
			get {
				return this.GameObject.transform.parent != null;
			}
		}

		public Actor Owner {
			get {
				if (IsHeld) {
					return this.GameObject.transform.root.GetComponent<ActorRef>().Actor;
				}
				return null;
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

		public void Destroy() {
			TimelineRunner.SoftKill();
			this.Game.ActorManager.RemoveActor(this);
			this.Game.AbilityManager.RemoveActor(this);
			var wpnController = this.WeaponController;

			_pendingDelete = true;

			this.WeaponController = null;
			if(wpnController != null) {
				wpnController.Destroy();
			}
		}

		public virtual void NotifyDestroyed() {
			if(OnDestroyed != null) {
				OnDestroyed(this);
			}
		}

		public virtual void LoadFromData(CharacterData data) {
			this.Data = data;

			Attributes.LoadFromData (data.attributeData);
		}

		public virtual void EnterGame(Client.Game.Core.Game game) {
			this.Game = game;
			TerrainCollider = GameObject.GetComponentInChildren<Collider2D> ();
			if(TerrainCollider != null) {
				colliderHeight = TerrainCollider.bounds.extents.y;
			}

			this.WeaponController = new WeaponController(this);

			//I should break this out into an actor factory instead of having hard linkages
			Game.AbilityManager.AddActor(this);

			TimelineRunner = new TimelineRunner();

		}

		
		public virtual void Update(float dt) {
			
		}

		public virtual void FixedUpdate() {
			
		}

		public override string ToString ()
		{
			return string.Format ("[Actor: name={0}, id={1}, dataId={2}]", this.Data.Name, this.Id, this.Data.Id);
		}



	}

}

