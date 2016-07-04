using System;
using System.Collections.Generic;
using Client.Game.Data;
using System.Linq;
using Client.Game.Actors;
using Client.Game.Enums;
using UnityEngine;
using Client.Game.Map.GenConstraints;
using Client.Game.Utils;


namespace Client.Game.Map
{
    using DoorLinkMapping = Dictionary<RoomData.Link, DoorActor>;
    using MatingLookup = Dictionary<Vector3, DoorActor>;
    using Game = Game.Core.Game;
    using Client.Game.Data.Ascii;

    public class MapGenerator
	{
		MapData mapData;
		ConstraintList Constraints;
		List<ZoneGenerator> ZoneGenerators = new List<ZoneGenerator>();
		int CurrentZoneIndex;

		Room Head;

		public MapGenerator ()
		{
			mapData = MapDataTable.Map1;
			Constraints = new ConstraintList();
			Constraints.InitWithMap(mapData);

			foreach( var z in mapData.Zones) {
				var gen = new ZoneGenerator(z);
				ZoneGenerators.Add(gen);
			}
		}

		public bool IsComplete = false;

		public void InitWithPool (List<RoomData> availableRooms, int numRoomsToGenerate)
		{
			ZoneGenerators.ForEach(p => p.InitPool(availableRooms, numRoomsToGenerate));
		}

		public IEnumerable<Room> Emit() {
			
			foreach( var zone in ZoneGenerators ) {
				var room = zone.Emit();

				if(zone.IsComplete) {
					CurrentZoneIndex ++;
					IsComplete = CurrentZoneIndex >= ZoneGenerators.Count;
				}

				yield return room;
			}

		}



		public void LinkAndSealZones() {

			/*
			foreach(var unlinked in UnlinkedDoors) {
				
				unlinked.Parent.Doors.Remove(unlinked);
				Game.Instance.ActorManager.RemoveActor(unlinked);
				
				var ff = new FloodFill(unlinked.Parent.data.AsciiMap);
				ff.Fill(AsciiConstants.SEALED_DOOR, unlinked.LinkData.ChunkData);	
			}
			*/
		}


	}
}
