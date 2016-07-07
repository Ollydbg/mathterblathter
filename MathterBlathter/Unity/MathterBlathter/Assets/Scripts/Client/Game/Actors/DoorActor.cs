using System;
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

		public bool Set = false;

		private bool _isOpen;


        public bool isOpen {
			get {
				return _isOpen;
			} 
			private set {
				_isOpen = value;
				this.GameObject.GetComponent<Renderer>().material.color = _isOpen ? OPEN_COLOR : CLOSED_COLOR;
				this.GameObject.GetComponent<Collider2D>().isTrigger = _isOpen;
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


		void OnTriggerExit(Actor actor) {
			if(actor == Game.PossessedActor) {

				//get exit direction
				var side = getExitSide(actor);
				//lookup linkage
				Game.RoomManager.EnterRoom(actor, Portals[side], this);

			}
		}

		public bool Validate() {
			if(Portals.ContainsKey(this.Side)) 
				return true;

			Debug.Log("INVALID DOOR: ", this.GameObject);
			return false;
		}

		DoorRoomSide getExitSide (Actor actor)
		{
			if(WallDoor) {
				//test for left or right
				return actor.transform.position.x < this.transform.position.x? DoorRoomSide.Left : DoorRoomSide.Right;
			} else {
				//test for above or below
				return actor.transform.position.y > this.transform.position.y? DoorRoomSide.Top : DoorRoomSide.Bottom;
			}
		}

		public override void Update (float dt)
		{
			base.Update(dt);
		}

		public override void EnterGame(Client.Game.Core.Game game) {
			
			GameObject.GetComponent<ActorRef> ().OnTriggerActorExit += OnTriggerExit;

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

