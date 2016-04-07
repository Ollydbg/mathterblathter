using System;
using System.Collections.Generic;
using Client.Game.Data;
using UnityEngine;
using System.Linq;
using Client.Game.Core;

namespace Client.Game.Map
{
	class DebugRoomDrawer : Room.IRoomDrawer
	{
		public void Draw(Room room) {
			
			var containerObj = new GameObject();

			var roomObj = DebugDraw (0, 0, 0, room.Width, room.Height, Color.red);
			roomObj.name = "room";
			roomObj.transform.parent = containerObj.transform;


			foreach (Door door in room.Doors) {
				var doorObj = DebugDraw (door.X, door.Y, -1, door.Width, door.Height, Color.cyan);
				door.gameObject = doorObj;
				doorObj.name = "door";
				doorObj.transform.SetParent(containerObj.transform);
			}

			containerObj.transform.position = new Vector3(room.X, room.Y, 0);

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

