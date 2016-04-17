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

		#region implemented abstract members of Actor

		public override ActorType ActorType {
			get {
				return ActorType.Door;
			}
		}

		#endregion

		public float X;
		public float Y;
		public int Width;
		public int Height;

		public Room Parent;
		public DoorRoomSide Side;

		public Guid SelfGuid;
		public Guid LinkedGuid;

		public RoomData.Link Data;

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
				return Data.X + Parent.X + MateOffsetX;
			}
		}

		public float MatingY {
			get {
				return Data.Y + Parent.Y + MateOffsetY;
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


		void onCollision (UnityEngine.Collider Collider)
		{
			var hitRef = Collider.gameObject.GetComponent<ActorRef>();
			if(hitRef && Game.PossessedActor == hitRef.Actor) {
				Game.RoomManager.EnterRoom(hitRef.Actor, this.Parent, this);
			}
		}

		public override void Update (float dt)
		{
			//Debug.Log(transform.position);
			base.Update(dt);
		}

		public override void EnterGame(Client.Game.Core.Game game) {
			
			GameObject.GetComponent<ActorRef> ().TriggerEvent += onCollision;

			base.EnterGame(game);

		}

		public void InitWithData(RoomData.Link link) {
			this.Data = link;
			this.Width = link.Width;
			this.Height = link.Height;
			this.X = link.X;
			this.Y = link.Y;
			this.SelfGuid = link.Id;
			this.Side = link.Side;
		}


	}
}

