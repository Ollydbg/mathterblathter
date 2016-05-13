// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;


namespace Client.Game.Attributes
{
	[Serializable]
	public class AttributeValue
	{
		public int Value;
		public float ValueF;
	}

	public enum GameAttributeEncoding
	{
		Int,
		IntMinMax,
		Float16,
		Float16or32,
		Float32,
		Long,
		Double,
	}
	
	[StructLayout(LayoutKind.Explicit)]
	public struct GameAttributeValue
	{
		[FieldOffset(0)]
		public int Value;
		[FieldOffset(0)]
		public float ValueF;
		
		[FieldOffset(4)]
		public long ValueL;
		[FieldOffset(4)]
		public double ValueD;

		public static bool operator ==(GameAttributeValue a, GameAttributeValue b)
		{
			return a.Value == b.Value && a.ValueL == b.ValueL;
		}

		public override bool Equals (object obj)
		{
			return this == (GameAttributeValue)obj;
		}

		public override int GetHashCode ()
		{
			return base.GetHashCode ();
		}

		public static bool operator !=(GameAttributeValue a, GameAttributeValue b)
		{
			return a.Value != b.Value || a.ValueL != b.ValueL;
		}
		
		public GameAttributeValue(int value)
		{
			ValueF = 0f;
			Value = value;
			ValueL = 0;
			ValueD = 0;
		}
		
		public GameAttributeValue(float value)
		{
			Value = 0;
			ValueF = value;
			ValueL = 0;
			ValueD = 0;
		}
		
		public GameAttributeValue(long value)
		{
			ValueD = 0;
			ValueL = value;
			Value = 0;
			ValueF = 0f;
		}
		
		public GameAttributeValue(double value)
		{
			ValueL = 0;
			ValueD = value;
			Value = 0;
			ValueF = 0f;
		}

		
		public override string ToString()
		{
			return string.Format("[GameAttributeValue ValueL={0}, ValueD={1}, Value={2}, ValueF={3}", ValueL, ValueD, Value, ValueF);
		}
	}

	public abstract partial class GameAttribute
	{
		public const float Float16Min = -65536.0f;
		public const float Float16Max = 65536.0f;
		
		public int Id;
		
		public GameAttributeValue defaultValue;
		public String Name;
		public String Description;
		
		public GameAttributeEncoding EncodingType;
		
		public GameAttributeValue Min;
		public GameAttributeValue Max;

		public bool IsSettable = true;

		public GameAttribute() { }
		
		public GameAttribute(int id, int defaultValue, string name, int min, int max, string description = null)
		{
			Id = id;
			this.defaultValue.Value = defaultValue;
			Name = name;
			Description = description;
			Min = new GameAttributeValue(min);
			Max = new GameAttributeValue(max);

			
		}
		
		public GameAttribute(int id, float defaultValue, string name, float min, float max, string description = null)
		{
			Id = id;
			this.defaultValue.ValueF = defaultValue;
			Name = name;
			Description = description;
			Min = new GameAttributeValue(min);
			Max = new GameAttributeValue(max);

		}
		
		public GameAttribute(int id, long defaultValue, string name, GameAttributeEncoding encodingType, long min, long max, string description = null)
		{
			Id = id;
			this.defaultValue.ValueL = defaultValue;
			Name = name;
			Description = description;
			EncodingType = encodingType;
			Min = new GameAttributeValue(min);
			Max = new GameAttributeValue(max);

		}
		
		public GameAttribute(int id, double defaultValue, string name, double min, double max, string description = null)
		{
			Id = id;
			this.defaultValue.ValueD = defaultValue;
			Name = name;
			Description = description;
			Min = new GameAttributeValue(min);
			Max = new GameAttributeValue(max);

		}
	}

	
	public class GameAttributeI : GameAttribute
	{
		public int DefaultValue { get { return defaultValue.Value; } }
		public int MaxValue { get { return Max.Value; } }
		public int MinValue { get { return Min.Value; } }
		
		public GameAttributeI() { }
		
		public GameAttributeI(int id, int defaultValue, string name, int min, int max, string description = null)
			: base(id, defaultValue, name, min, max, description)
		{
		}
	}

	public class GameAttributeE : GameAttribute
	{
		public int DefaultValue { get { return defaultValue.Value; } }
		public GameAttributeE() { }
		public Type EnumType;
		
		public GameAttributeE(int id, int defaultValue, string name, int min, int max, Type enumType, string description = null)
			: base(id, defaultValue, name, min, max, description)
		{
			EnumType = enumType;
		}

	}
	
	public class GameAttributeF : GameAttribute
	{
		public float DefaultValue { get { return defaultValue.ValueF; } }
		public float MaxValue { get { return Max.ValueF; } }
		public float MinValue { get { return Min.ValueF; } }
		
		public GameAttributeF() { }
		
		public GameAttributeF(int id, float defaultValue, string name, float min, float max, string description = null)
			: base(id, defaultValue, name, min, max, description)
		{
		}
	}

	
	public class GameAttributeB : GameAttribute
	{
		public bool DefaultValue { get { return defaultValue.Value != 0; } }
		
		public GameAttributeB() { }
		
		public GameAttributeB(int id, int defaultValue, string name, int min, int max, string description = null)
			: base(id, defaultValue, name, min, max, description)
		{
		}
	}
	
	public class GameAttributeL : GameAttribute
	{
		public long DefaultValue { get { return defaultValue.ValueL; } }
		public long MaxValue { get { return Max.ValueL; } }
		public long MinValue { get { return Min.ValueL; } }
		
		public GameAttributeL() { }
		
		public GameAttributeL(int id, long defaultValue, string name, long min, long max, string description = null)
			: base(id, defaultValue, name, min, max, description)
		{
		}
	}
	
	public class GameAttributeD : GameAttribute
	{
		public double DefaultValue { get { return defaultValue.ValueD; } }
		public double MaxValue { get { return Max.ValueD; } }
		public double MinValue { get { return Min.ValueD; } }
		
		public GameAttributeD() { }
		
		public GameAttributeD(int id, double defaultValue, string name, double min, double max,  string description = null)
			: base(id, defaultValue, name, min, max, description)
		{
		}
	}

}

