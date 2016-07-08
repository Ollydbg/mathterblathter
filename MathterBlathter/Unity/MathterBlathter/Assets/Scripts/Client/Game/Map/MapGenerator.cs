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

		List<RoomData> availableRooms() {
			return RoomDataTable.GetAll().Where( p=>!p.Mute).ToList();
		}

		IEnumerable<ZoneData> availableZones() {
			var solod = mapData.Zones.Where(p => p.Solo);
			if(solod.Count() > 0) {
				return solod;
			}
			return mapData.Zones.Where(p => !p.Mute);
		}

		public MapGenerator (MapData map)
		{
			mapData = map;
			Constraints = new ConstraintList();
			Constraints.InitWithMap(mapData);

			foreach( var z in availableZones()) {
				var gen = new ZoneGenerator(z);
				ZoneGenerators.Add(gen);
				gen.InitPool(availableRooms(), z.MaxRooms);
			}

		}

		public bool IsComplete = false;


		public Room Emit() {
			foreach( var zone in ZoneGenerators ) {
				if(!zone.IsComplete) {

					var room = zone.Emit();

					if(zone.IsComplete) {
						CurrentZoneIndex ++;
						IsComplete = CurrentZoneIndex == ZoneGenerators.Count;

						if(!this.IsComplete) {
							zone.SealDoors(except:zone.TopMostUnlinkedDoor);
							ZoneGenerators[CurrentZoneIndex].BuildFrom(zone.TopMostUnlinkedDoor, zone.Constraints);
						} else {
							zone.SealDoors();
						}
					}

					return room;
				}
			}

			return null;

		}

	}
}
