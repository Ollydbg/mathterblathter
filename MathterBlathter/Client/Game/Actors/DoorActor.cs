﻿using System;
using Client.Game.Map;
using Client.Game.Data;
using Client.Game.Enums;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Actors
{
	public class DoorActor : Actor
	{
		public DoorActor ()
		{
		}


		public float X;
		public float Y;
		public int Width;
		public int Height;

		public Room Parent;

		public Dictionary<DoorRoomSide, Room> Portals = new Dictionary<DoorRoomSide, Room>();

		public DoorRoomSide Side;

		public Guid SelfGuid;

		public RoomData.Link LinkData;

		private static Color OPEN_COLOR = Color.white;
		private static Color CLOSED_COLOR = Color.red;

		private bool _isOpen;
		public bool isOpen {
			get {
				return _isOpen;
			} 
			private set {
				_isOpen = value;
				this.GameObject.GetComponent<Renderer>().material.color = _isOpen ? OPEN_COLOR : CLOSED_COLOR;
				//this.GameObject.GetComponent<Collider>().isTrigger = _isOpen;

			}
		}

		public bool WallDoor {
			get {
				return this.Side == DoorRoomSide.Left || this.Side == DoorRoomSide.Right;
			}
		}

		public bool isClosed {
			get {return !isOpen; }
		}

		public void Open() {
			isOpen = true;
		}

		public void Close() {
			isOpen = false;
		}
		

		public float WorldX {
			get {
				return Parent.X + this.X;
			}
		}

		public float WorldY {
			get {
				return Parent.Y + this.Y;
			}
		}

		public float MatingX {
			get {
				return LinkData.X + Parent.X + MateOffsetX;
			}
		}

		public float MatingY {
			get {
				return LinkData.Y + Parent.Y + MateOffsetY;
			}
		}

		public float MateOffsetY {
			get{
				if (Side == DoorRoomSide.Top) {
					return +1f;
				}
				if (Side == DoorRoomSide.Bottom) {
					return -1f;
				}
				return 0;
			}

		}

		public float MateOffsetX {
			get {
				if (Side == DoorRoomSide.Left) {
					return -1;
				}
				if (Side == DoorRoomSide.Right) {
					return 1;
				}
				return 0;
			}
		}


		void OnTrigger (UnityEngine.Collider Collider)
		{
			var hitRef = Collider.gameObject.GetComponent<ActorRef>();
			if(hitRef && Game.PossessedActor == hitRef.Actor) {
				//get intended direction
				var side = getEntranceSide(hitRef);
				//lookup linkage
				Room targetRoom;
				if(Portals.TryGetValue(DoorRoom.Opposite(side), out targetRoom)) {
					//move them there
					Game.RoomManager.EnterRoom(hitRef.Actor, targetRoom, this);
				} else {
					Debug.LogWarning("Couldn't get desired room from door entrance, this shouldn't have happened!");
				}

			}

		}

		DoorRoomSide getEntranceSide (ActorRef hitRef)
		{
			if(WallDoor) {
				//test for left or right
				return hitRef.Actor.transform.position.x < this.transform.position.x? DoorRoomSide.Left : DoorRoomSide.Right;
			} else {
				//test for above or below
				return hitRef.Actor.transform.position.y > this.transform.position.y? DoorRoomSide.Top : DoorRoomSide.Bottom;
			}
		}

		public override void Update (float dt)
		{
			base.Update(dt);
		}

		public override void EnterGame(Client.Game.Core.Game game) {
			
			GameObject.GetComponent<ActorRef> ().TriggerEvent += OnTrigger;

			base.EnterGame(game);

		}

		public void InitWithData(RoomData.Link link) {
			this.LinkData = link;
			this.Width = link.Width;
			this.Height = link.Height;
			this.X = link.X;
			this.Y = link.Y;
			this.SelfGuid = link.Id;
			this.Side = link.Side;
		}


	}
}

