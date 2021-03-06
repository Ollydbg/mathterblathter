﻿using System;
using Client.Game.Attributes;
using System.Collections.Generic;
using Client.Game.Data;

namespace Client.Game.Attributes
{
	using KeyId = System.UInt16;

	public class AttributeMap
	{
		const KeyId KEY_MASK = 0xFF00;
		const KeyId ID_MASK = 0x00FF;

		protected GameAttribute[] indexedAttributes;
		protected Dictionary<KeyId, GameAttributeValue> attributeValues = new Dictionary<KeyId, GameAttributeValue> ();

		private static byte GetId(KeyId keyId) {
			return (byte)(keyId & ID_MASK);
		}

		private static KeyId GetKeyId(int id, int? key) {
			byte truncated = (byte)id;
			byte truncatedKey = key.HasValue ? (byte)key.Value : byte.MaxValue;
			return GetKeyId (truncated, truncatedKey);
		}

		private static KeyId GetKeyId(byte id, byte key = byte.MaxValue)
		{
			return (KeyId)((KeyId)id | (key << 8));
		}

		public AttributeMap(GameAttribute[] indexed) {
			indexedAttributes = indexed;
		}

		public AttributeMap(List<CharacterData.AttributeData> attributeData) {
			this.LoadFromData(attributeData);
		}

		private GameAttribute GetGameAttribute(KeyId keyId) {
			return indexedAttributes [GetId (keyId) - 1];
		}

	
		public GameAttributeValue GetAttributeValue(GameAttribute inAttribute, int? key) {
			return RawGetAttributeValue (inAttribute, key);
		}

		private GameAttributeValue RawGetAttributeValue(GameAttribute inAttribute, int? key) {
			var keyId = GetKeyId (inAttribute.Id, key);
			GameAttributeValue outValue;
			if (attributeValues.TryGetValue (keyId, out outValue)) {
				return outValue;
			}

			return inAttribute.defaultValue;
		}

		public void SetAttributeValue(GameAttribute inAttribute, int? key, GameAttributeValue inValue) {
			RawSetAttributeValue (inAttribute, key, inValue);
		}

		void RawSetAttributeValue (GameAttribute inAttribute, int? key, GameAttributeValue inValue)
		{
			var keyId = GetKeyId (inAttribute.Id, key);
			if (inValue == inAttribute.defaultValue) {
				attributeValues.Remove (keyId);
			} else {
				attributeValues [keyId] = inValue;
			}
		}


		public void LoadFromData (List<CharacterData.AttributeData> attributeData)
		{
			foreach (var attr in attributeData) {
				var keyId = GetKeyId (attr.Id, attr.Index);
				var attrValue = attr.ValueI == 0 ? new GameAttributeValue (attr.ValueF) : new GameAttributeValue (attr.ValueI);
				attributeValues [keyId] = attrValue;
			}
		}

		public int this[GameAttributeI inAttribute, int? key = null]
		{
			get { return GetAttributeValue(inAttribute, key).Value; }
			set { SetAttributeValue(inAttribute, key, new GameAttributeValue(value)); }
		}

		public float this[GameAttributeF inAttribute, int? key = null]
		{
			get { return GetAttributeValue(inAttribute, key).ValueF; }
			set { SetAttributeValue(inAttribute, key, new GameAttributeValue(value)); }
		}

		public bool this[GameAttributeB inAttribute, int? key = null]
		{
			get { return GetAttributeValue(inAttribute, key).Value != 0; }
			set { SetAttributeValue(inAttribute, key, new GameAttributeValue(value ? 1 : 0)); }
		}

		public int this[GameAttributeE inAttribute, int? key = null]
		{
			get { return GetAttributeValue(inAttribute, key).Value; }
			set { SetAttributeValue(inAttribute, key, new GameAttributeValue(value)); }
		}

		public long this[GameAttributeL inAttribute, int? key = null]
		{
			get { return GetAttributeValue(inAttribute, key).ValueL; }
			set { SetAttributeValue(inAttribute, key, new GameAttributeValue(value)); }
		}

		public double this[GameAttributeD inAttribute, int? key = null]
		{
			get { return GetAttributeValue(inAttribute, key).ValueD; }
			set { SetAttributeValue(inAttribute, key, new GameAttributeValue(value)); }
		}
	}
}

