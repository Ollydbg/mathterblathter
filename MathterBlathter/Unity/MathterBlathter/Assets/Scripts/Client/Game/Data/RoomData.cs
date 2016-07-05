using System;
using System.Collections.Generic;
using Client.Game.Map;
using Client.Game.Data;
using Client.Game.Actors;
using Client.Game.Enums;
using UnityEngine;
using Client.Game.Data.Ascii;
using System.Linq;

namespace Client.Game.Data
{

	public class RoomData : GameData
	{

		public int Width;
		public int Height;
		public List<Link> Doors = new List<Link>();
		public List<Spawn> Spawns = new List<Spawn> ();
		public AsciiLookup AsciiSpawnLookup = new AsciiLookup();

		public AsciiMap AsciiMap = new AsciiMap();

		public int MinElevation;
		public int MaxElevation;
		public int MaxInstances = int.MaxValue;

		public int SortOrder = 100; //<-- used for explicit layout/ starting sequence

		public bool Solo;
		public bool Mute;

		public ParallaxData LayerData;
		public SetPieceData SetPiece;

		public RoomType Type = RoomType.Normal;


		public override string ToString ()
		{
			return string.Format ("[RoomData Id:{0}, Width:{1}, Height:{2}]", Id, Width, Height);
		}


		public class Link
		{
			public int X;
			public int Y;
			public int Width;
			public int Height;
			public DoorRoomSide Side;

			public Chunk ChunkData;

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
			public Vector3 Facing;
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
		
		
		public RoomData Clone() {

			var clone = new RoomData();
			clone.Width = this.Width;
			clone.Height = this.Height;
			clone.Doors = this.Doors.ToList();	
			clone.AsciiSpawnLookup = this.AsciiSpawnLookup;
			clone.AsciiMap = this.AsciiMap.Clone();
			clone.MinElevation = this.MinElevation;
			clone.MaxElevation = this.MaxElevation;
			clone.SortOrder = this.SortOrder;
			clone.Solo = this.Solo;
			clone.Mute = this.Mute;
			clone.Type = this.Type;
			clone.Spawns = this.Spawns.ToList();
			clone.Id = this.Id;
			clone.LayerData = this.LayerData;
			clone.SetPiece = this.SetPiece;
			return clone;
			
		}

	}

	[FlagsAttribute]
	public enum RoomType : short {
		Normal = 1,
		Challenge = 2,
		Store = 4,
		LurchStart = 8,
		Secret = 16,
		Terminal = 32,
		Boss = 64,
		NoWaves = 128,
		WeaponRoom = 256,
		ItemRoom = 512
	}
}

