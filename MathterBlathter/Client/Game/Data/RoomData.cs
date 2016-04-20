using System;
using System.Collections.Generic;
using Client.Game.Map;
using Client.Game.Data;
using Client.Game.Actors;
using Client.Game.Enums;
using Client.Game.Map.Ascii;
using UnityEngine;

namespace Client.Game.Data
{
	public class RoomData : GameData
	{

		public int Width;
		public int Height;
		public List<Link> Doors = new List<Link>();
		public List<Spawn> Spawns = new List<Spawn> ();
		public Dictionary<char, CharacterData> AsciiSpawnLookup = new Dictionary<char, CharacterData>();

		public AsciiMap AsciiMap = new AsciiMap();

		public bool Solo;
		public bool Mute;

		public class Link
		{
			public int X;
			public int Y;
			public int Width;
			public int Height;
			public DoorRoomSide Side;

			public Guid Id = Guid.NewGuid();

			public Link()
			{
				
			}

			public Link(Link other) {
				this.X = other.X;
				this.Y = other.Y;
				this.Width = other.Width;
				this.Height = other.Height;
				this.Side = other.Side;
			}

			public Link Clone() {
				return new Link (this);
			}



		}

		public class Spawn
		{
			public int ActorId;
			//LOCAL SPACE!!
			public float X;
			public float Y;
			public RoomSpawnType SpawnType;
			public Guid Guid;
			public Spawn(CharacterData inData) {
				this.ActorId = inData.Id;
				this.Guid = Guid.NewGuid();
			}
			public Vector3 RoomPosition {
				get {
					return new Vector3(X, Y);
				}
			}

		}

		public RoomData ()
		{
		}

	}
}

