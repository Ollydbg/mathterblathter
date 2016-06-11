using System;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public class PickupData : CharacterData {
		public float Rarity = 0;
		public string Description;
		public Type PickupType;
		public enum Type {
			Unassigned,
			Weapon,
			Buff,
			Item
		}
	}

	public static partial class MockActorData
	{
		private static int OFFSET = 256;

		public static PickupData RANDOM_WEAPON_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 1;
				ret.PickupType = PickupData.Type.Weapon;
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add( new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id,
					MockAbilityData.LEVEL_APPROPRIATE_WEAPON.Id,
					0
				));
				ret.Name = "RandomWeapon";
				ret.Availability = Availability.Droppable;
				return ret;
			}
		}

		public static PickupData MAX_HEALTH_BOOST {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 2;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.Description = "A very small health boost";
				
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupData.Type.Item;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.STAT_UP.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Health.Id,
					1
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 10;

				ret.Name = "Blood Thinner";
				return ret;
			}
		}

		public static PickupData MOVE_BOOST_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 3;
				ret.Description = "A temporary run speed upgrade";
				ret.PickupType = PickupData.Type.Buff;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.MOVE_BOOST_TEMP.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.Availability = Availability.Droppable;
				ret.Name = "Blood Pump";
				return ret;
			}
		}

		public static PickupData HEALTH_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 4;
				ret.Description = "A generous health pickup";

				ret.PickupType = PickupData.Type.Item;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.HEAL.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 30;
				ret.Name = "Blood Pack";
				return ret;
			}
		}

		public static PickupData SHORTENED_TENDONS_PICKUP {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 5;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.Description = "Improved jumping height, but you sometimes take damage on big falls";
				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.JUMP_BUFF_PERM.Id,
					0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.FALL_DAMAGE_PERM.Id,
					1
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 2
				));
				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 70;
				//better jumps, but takes a little damage on falling from heights
				ret.Name = "Shortened Achilles Tendon";

				return ret;
			}
		}

		public static PickupData RABBITS_FOOT {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 6;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.Description = "Improved Drop quality";
				ret.ActorType = ActorType.Pickup;

				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.RABBITS_FOOT_BUFF.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropQuality.Id,
					.5f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id,
					0f
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 50;

				ret.Name = "Rabbit's Foot";

				return ret;
			}
		}


		public static PickupData CURSED_RABBITS_FOOT {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 7;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.Description = "Lower drop rate, but they're better, I swear";
				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.RABBITS_FOOT_BUFF.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropQuality.Id,
					.75f
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id,
					-.1f
				));

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 60;

				ret.Name = "Cursed Rabbit's Foot";

				return ret;
			}
		}

		public static PickupData RANDOM_BUFF {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 8;
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.LEVEL_APPROPRIATE_BUFF.Id,
					0
				));

				ret.Availability = Availability.Droppable;
				return ret;
			}
		}

		public static PickupData CALM_DOWN_PILLS {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 9;
				ret.ActorType = ActorType.Pickup;
				ret.ResourcePath = "Items/GoldenPill_prefab";
				ret.Description = "Decrease your Anxiety";
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.ENERGY_HEAL.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id,
					.8f
				));
				ret.Name = "Calmdown pills";
				ret.Availability = Availability.Droppable;

				return ret; 
			}
		}

		public static PickupData SAFETY_BLANKET {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 10;
				ret.ActorType = ActorType.Pickup;
				ret.Description = "Take Less Anxiety Damage";
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.LOWER_ANXIETY_DAMAGE_BUFF.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));

				ret.Name = "Safety Blanket";
				ret.Availability = Availability.InShop;
				return ret;

			}
		}
		
		public static PickupData CURSED_COURAGE {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 11;
				ret.Name = "Cuh Cuh Cursed Courage";
				ret.Description = "At the cost of your max health, fire faster and have a higher anxiety threshold.";
				ret.ActorType = ActorType.Pickup;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.PickupType = PickupData.Type.Buff;
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.CURSED_COURAGE_BUFF.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.Availability = Availability.Droppable | Availability.InShop;
				
				return ret;
				
			}
			
		}
		
		public static PickupData TRIGGER_FINGERS {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 12;
				ret.Name = "TRIGGER FINGERS";
				ret.Description = "Better firing speed";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TRIGGER_FINGERS_BUFF.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));	
				ret.ResourcePath = "Items/ItemBuff_prefab";
				
				ret.Availability = Availability.Droppable | Availability.InShop;
				
				return ret;
			}
			
		}
		
		public static PickupData ANIMAL_HEART {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 13;
				ret.Name = "ANIMAL HEART";
				ret.Description = "Do more damage when at low health";
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.LOW_HEALTH_DAMAGE_AMP_BUFF.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));	
				ret.ResourcePath = "Items/ItemBuff_prefab";
				
				ret.Availability = Availability.Droppable | Availability.InShop;
				
				return ret;
			}
			
		}
		
		public static PickupData WEAPON_DE_CURSER {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 14;
				ret.Name = "Weapon De-Curser";
				ret.Description = "Removes curses from your current weapons";
				ret.ActorType = ActorType.Pickup;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.Cost = 500;	
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.WEAPON_DE_CURSER.Id,
					0
				));
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				ret.Availability = Availability.InShop;
				return ret;
			}
		}

		public static PickupData SHOP_CHEAPENER {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 15;
				ret.Name = "A Fancy Hat";
				ret.Description = "+5 charisma makes shop keepers give you a discount";
				ret.ActorType = ActorType.Pickup;
				ret.Cost = 1000;
				
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.SHOP_CHEAPENER_BUFF.Id,
					0
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				
				ret.Availability = Availability.InShop | Availability.Droppable;
				
				return ret;
			}

		}

		public static PickupData KILL_DE_STRESSER {
			get {
				var ret = new PickupData();
				ret.Id = OFFSET + 16;
				ret.Name = "Spiteful Heart";
				ret.Description = "Killing synth-heads reduces Anxiety";
				ret.ActorType = ActorType.Pickup;
				ret.Cost = 250;

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.KILL_DE_STRESSER_BUFF.Id,
					0
				));
				
				ret.attributeData.Add(new GameData.AttributeData(
					ActorAttributes.Abilities.Id,
					MockAbilityData.TOWER_ACTOR_ABSORBER.Id, 1
				));
				
				ret.Availability = Availability.InShop | Availability.Droppable;

				return ret;

			}

		}
		
		
	}
}

