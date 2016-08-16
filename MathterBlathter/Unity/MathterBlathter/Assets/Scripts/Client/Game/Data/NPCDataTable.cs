using System;
using Client.Game.Data;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{

		private static int NPC_OFFSET = 1<<11; //2048

		public static CharacterData WEAPON_SHOPKEEPER {
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

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 1.0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData( 
					ActorAttributes.BloodBounty.Id, 300
				));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.ShopKeeperNumWeapons.Id, 5
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.ShopKeeperNumItems.Id, 2
                ));
                
                ret.AddAbility(AbilityDataTable.SHOPKEEPER_INVENTORY_CREATOR);
				return ret;
			}
		}

        public static CharacterData BUFF_SHOPKEEPER {
            get {
                var ret = new CharacterData();
                ret.Id = NPC_OFFSET + 2;

                ret.ResourcePath = "Actors/NPCS/ShopKeeper_prefab";
                ret.ActorType = ActorType.Friendly;
                ret.Name = "Krugas";
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.Health.Id, 1000
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.AIDetectionRadius.Id, 20.0f
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.Speed.Id, .08f
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.TakesDamage.Id, 1
                ));
                
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.GravityScalar.Id, 1.0f
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.BloodBounty.Id, 300
                ));

                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.ShopKeeperNumBuffs.Id, 5
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.ShopKeeperNumItems.Id, 3
                ));
                ret.attributeData.Add(new CharacterData.AttributeData(
                    ActorAttributes.ShopKeeperNumActiveItems.Id, 3
                ));

                ret.AddAbility(AbilityDataTable.SHOPKEEPER_INVENTORY_CREATOR);

                return ret;
            }
        }

        public static CharacterData PATCHES {
			get {
				var ret = new CharacterData ();
				ret.Id = NPC_OFFSET + 3;

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

