using System;
using Client.Game.Map;
using Client.Game.Data;
using Client.Game.Enums;
using UnityEngine;

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
		public DoorRoomSide Side;

		public Guid SelfGuid;
		public Guid LinkedGuid;

		public RoomData.Link LinkData;

		private bool _isOpen;
		public bool isOpen {
			get {
				return _isOpen;
			} 
			private set {
				
				_isOpen = value;
				this.GameObject.GetComponent<Collider>().isTrigger = _isOpen;

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

		private float MateOffsetY {
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

		private float MateOffsetX {
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
				Game.RoomManager.EnterRoom(hitRef.Actor, this.Parent, this);
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

