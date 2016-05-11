using System;
using System.Collections.Generic;
using Client.Game.Enums;
using Client.Game.Data.Ascii;

namespace Client.Game.Data
{
	public class AbilityData : GameData
	{
		public string name;
		public List<AttributeData> attributeData = new List<AttributeData>();
		public string animation;
		public Type executionScript;
		public int spawnableDataId;
		public AbilityType AbilityType = AbilityType.Instanced;

		public List<TimelineData> Timelines = new List<TimelineData>();

		public AbilityData ()
		{
		}



	}

	public class TimelineData
	{
		public AsciiMap AsciiMap = new AsciiMap();
		public class Point {
			public string Resource;
			public AttachPoint AttachPoint;

			public Point(string resouce, AttachPoint ap) {
				this.Resource = resouce;
				this.AttachPoint = ap;
			}
		}

		public Dictionary<char, Point> Lookup = new Dictionary<char, Point>();
		public float Duration;

		public TimelineData ()
		{

		}

	}
}

