using System;
using UnityEngine;

namespace Client.Game.Map
{
	public class Door
	{
		public int X;
		public int Y;
		public int Width;
		public int Height;

		public Room Parent;
		public Room Linked;
		public RoomSide Side;
		public GameObject gameObject;

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

		public Door ()
		{
			
		}

		public Door(Door other) {
			this.X = other.X;
			this.Y = other.Y;
			this.Width = other.Width;
			this.Height = other.Height;
			this.Side = other.Side;
		}

		public Door Clone() {
			return new Door (this);
		}

		public enum RoomSide {
			Top,
			Bottom,
			Left,
			Right
		}
	}
}

