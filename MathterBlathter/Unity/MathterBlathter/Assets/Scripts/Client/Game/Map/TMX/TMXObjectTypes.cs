using System;
using Client.Game.Data;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace Client.Game.Map.TMX
{
	public static class TMXObjectTypes
	{
		public static Dictionary<string, CharacterData> Lookup = new Dictionary<string, CharacterData>();
		private static ObjectTypes ObjectDefs;
		private const string DATA_ID = "DataId";

		public static CharacterData GetCharacterData(string id) {

			return CharacterDataTable.FromId(GetCharacterDataId(id));
			
		}

		public static int GetCharacterDataId(string id) {

			if(ObjectDefs == null) {

				var text = Resources.Load("TMXData/objecttypes") as TextAsset;
				XmlSerializer serializer = new XmlSerializer(typeof(ObjectTypes));
				StringReader reader = new StringReader(text.text);
				ObjectDefs = serializer.Deserialize(reader) as ObjectTypes;

			}

			var charId = ObjectDefs.Items.Find(p => p.name == id).Properties.Find(s => s.name == DATA_ID).Default;

			return charId;

		}

		
		[System.Serializable, XmlRoot("objecttypes")]
		public class ObjectTypes {

			public ObjectTypes(){Items = new List<ObjectType>();}

			[XmlElement("objecttype")]
			public List<ObjectType> Items {get; set;}

		}

		[System.Serializable, XmlRoot("objecttype")]
		public class ObjectType {

			
			[XmlAttribute("name")]
			public string name;
			
			[XmlAttribute("color")]
			public string color;


			public ObjectType(){
				Properties = new List<ObjectProperty>();
			}

			[XmlElement("property")]
			public List<ObjectProperty> Properties {get; set;}

		}

		[System.Serializable, XmlRoot("property")]
		public class ObjectProperty {
			
			[XmlAttribute("name")]
			public string name;
			[XmlAttribute("type")]
			public string type;
			[XmlAttribute(AttributeName="default")]
			public int Default;
		}

	}
}

