using System;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Actors;
using System.Linq;
using Client.Game.Data;

namespace Client.Game.Map
{

	public class MapPathfinder
	{
		
		public MapPathfinder (List<Room> rooms)
		{
			
		}



		public DoorActor FirstDoorToRoom(Room worldFrom, Room worldTo) {

			long time = DateTime.UtcNow.Millisecond;
			var path = ShortestPathTo(worldFrom, worldTo, null, null);
			long elapsed = DateTime.UtcNow.Millisecond - time;
			Debug.Log(string.Format("Found path in {0} ms, has {1} node(s)", elapsed, path.Count)); 

			//1 means we're there, so no door
			if(path.Count <= 1 ) {
				return null;
			} else {
				foreach( var door in path[0].Doors) {
					if(door.Portals[door.Side] == path[1]) {
						return door;
					}
				}
			}

			return null;
		}


		//breadth first search
		public List<Room> ShortestPathTo(Room fromRoom, Room data, List<Room> crumbs = null, Dictionary<Room, bool> seen = null) {
			if(seen == null) {
				seen = new Dictionary<Room, bool>();
			}

			List<Room> stackCrumbs = new List<Room>();

			if(crumbs != null) {
				stackCrumbs.AddRange(crumbs);   
			}


			var buff = new List<Room>();
			seen[fromRoom] = true;
			stackCrumbs.Add(fromRoom);

			//earliest matching
			if(fromRoom.Id == data.Id) {
				buff.AddRange(stackCrumbs);
				buff.Add(fromRoom);
				return buff;
			}

			foreach( var child in fromRoom.Children()) {
				if(child.Id == data.Id) {
					buff.AddRange(stackCrumbs);
					buff.Add(child);
					return buff;
				}


			}

			foreach( var child in fromRoom.Children())
				if(!seen.ContainsKey(child)) 
					buff.AddRange(ShortestPathTo(child, data, stackCrumbs, seen));


			return buff;
		}


	}

	public static class RoomHelper {
		public static IEnumerable<Room> Children(this Room room) {
			foreach( var d in room.Doors) {
				yield return d.Portals[d.Side];
			}

		}
	}
}

