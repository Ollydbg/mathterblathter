using System;
using System.Collections.Generic;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Core;

namespace Client.Game.Map
{
	public class Room
	{

		public int X;
		public int Y;
		public int Width;
		public int Height;

		public List<Door> Doors;

		public GameObject roomObj;
		public GameObject containerObj;

		public float Left { 
			get {
				return (float)(X - .5*Width);
			}
		}

		public float Right {
			get {
				return (float)(X + .5 * Width);
			}
		}

		public float Top {
			get {
				return (float)(Y + .5 * Height);
			}
		}

		public float Bottom {
			get {
				return (float)(Y - .5 * Height);
			}
		}


		public Room (RoomData data)
		{
			initFromData (data);
		}


		public void initFromData (RoomData data)
		{
			this.Width = data.Width;
			this.Height = data.Height;

			this.Doors = data.Doors.Select (p => p.Clone ()).ToList();
			this.Doors.ForEach (p => p.Parent = this);
			
		}

		public void EnterGame(Game.Core.Game game) { 
			Draw ();
		}

		private void Draw() {

			containerObj = new GameObject();


			roomObj = DebugDraw (0, 0, 0, Width, Height, Color.red);
			roomObj.name = "room";
			roomObj.transform.parent = containerObj.transform;


			foreach (Door door in Doors) {
				var doorObj = DebugDraw (door.X, door.Y, -1, door.Width, door.Height, Color.cyan);
				door.gameObject = doorObj;
				doorObj.name = "door";
				doorObj.transform.SetParent(containerObj.transform);
			}

			containerObj.transform.position = new Vector3(X, Y, 0);

		}

		public GameObject DebugDraw(int x, int y, int z, int width, int height, Color color) {
			
			var obj = (GameObject)GameObject.Instantiate ((Resources.Load ("DebugSprite")));
			Vector3 position = new Vector3 (x, y, z);
			obj.transform.position = position;
			obj.transform.localScale = new Vector3 (width, height, 1f);
			obj.GetComponent<SpriteRenderer> ().color = color;



			return obj;


		}
	}
}

