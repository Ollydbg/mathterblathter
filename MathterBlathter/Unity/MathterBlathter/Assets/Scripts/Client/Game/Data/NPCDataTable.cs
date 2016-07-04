using System;
using Client.Game.Data;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{

		private static int NPC_OFFSET = 1<<11;

		public static CharacterData SHOPKEEPER {
			get {
				var ret = new CharacterData ();
				ret.Id = NPC_OFFSET + 1;

				ret.ResourcePath = "Actors/NPCS/ShopKeeper_prefab";
				ret.ActorType = ActorType.Friendly;
				ret.Name = "Grapthar";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 1000
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .08f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));
				ret.AddAbility(AbilityDataTable.SHOPKEEPER_INVENTORY_CREATOR);

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 300
				));

				return ret;
			}
		}

		public static CharacterData PATCHES {
			get {
				var ret = new CharacterData ();
				ret.Id = NPC_OFFSET + 2;

				ret.ResourcePath = "Actors/NPCS/ShopKeeper_prefab";
				ret.ActorType = ActorType.Friendly;
				ret.Name = "Grapthar";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 1000
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .08f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.AddAbility(AbilityDataTable.SHOPKEEPER_INVENTORY_CREATOR);

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 300
				));

				return ret;
			}
		}
	}
}

