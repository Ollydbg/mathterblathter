﻿using System;
using System.Collections.Generic;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	
	public static partial class CharacterDataTable
	{
		private static int OFFSET = 256;

		public static CharacterData RANDOM_WEAPON_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 1;
				ret.PickupType = PickupType.Weapon;
				ret.ActorType = ActorType.Pickup;
				ret.attributeData.Add( new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id,
					AbilityDataTable.LEVEL_APPROPRIATE_WEAPON.Id,
					0
				));
				ret.Name = "RandomWeapon";
				ret.Availability = Availability.Droppable;
				return ret;
			}
		}

		public static CharacterData MAX_HEALTH_BOOST {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 2;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.Description = "A very small health boost";
				
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupType.Item;
				ret.AddAbility(AbilityDataTable.STAT_UP);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.overrideAttributes.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxHealth.Id,
					1
				));
				ret.overrideAttributes.Add(new CharacterData.AttributeData(
					ActorAttributes.Health.Id,
					1
				));
				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 10;

				ret.Name = "Blood Thinner";
				return ret;
			}
		}

		public static CharacterData MOVE_BOOST_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 3;
				ret.Description = "A temporary run speed upgrade";
				ret.PickupType = PickupType.Buff;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;

				ret.AddAbility(AbilityDataTable.MOVE_BOOST_TEMP);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.Droppable;
				ret.Name = "Blood Pump";
				return ret;
			}
		}

		public static CharacterData SMALL_HEALTH_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 4;
				ret.Description = "A generous health pickup";

				ret.PickupType = PickupType.Item;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.AddAbility(AbilityDataTable.SMALL_HEAL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 30;
				ret.Name = "Blood Pack";
				return ret;
			}
		}

		public static CharacterData SHORTENED_TENDONS_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 5;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.Description = "Improved jumping height, but you sometimes take damage on big falls";
				ret.PickupType = PickupType.Buff;

				ret.AddAbility(AbilityDataTable.JUMP_BUFF_PERM);
				ret.AddAbility(AbilityDataTable.FALL_DAMAGE_PERM);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.Droppable | Availability.InShop;
				ret.Cost = 70;
				//better jumps, but takes a little damage on falling from heights
				ret.Name = "Shortened Achilles Tendon";

				return ret;
			}
		}

		public static CharacterData RABBITS_FOOT {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 6;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.Description = "Improved Drop quality";
				ret.ActorType = ActorType.Pickup;

				ret.PickupType = PickupType.Buff;

				ret.AddAbility(AbilityDataTable.RABBITS_FOOT_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

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


		public static CharacterData CURSED_RABBITS_FOOT {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 7;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.Description = "Lower drop rate, but they're better, I swear";
				ret.PickupType = PickupType.Buff;
				ret.AddAbility(AbilityDataTable.RABBITS_FOOT_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

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

		public static CharacterData RANDOM_BUFF {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 8;
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupType.Buff;

				ret.AddAbility(AbilityDataTable.LEVEL_APPROPRIATE_BUFF);

				ret.Availability = Availability.Droppable;
				return ret;
			}
		}

		public static CharacterData CALM_DOWN_PILLS {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 9;
				ret.ActorType = ActorType.Pickup;
				ret.ResourcePath = "Items/GoldenPill_prefab";
				ret.Description = "Decrease your Anxiety";

				ret.AddAbility(AbilityDataTable.ENERGY_HEAL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.DropRate.Id,
					.8f
				));
				ret.Name = "Calmdown pills";
				ret.Availability = Availability.Droppable;

				return ret; 
			}
		}

		public static CharacterData SAFETY_BLANKET {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 10;
				ret.ActorType = ActorType.Pickup;
				ret.Description = "Take Less Anxiety Damage";
				ret.ResourcePath = "Items/ItemBuff_prefab";

				ret.AddAbility(AbilityDataTable.LOWER_ANXIETY_DAMAGE_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Name = "Safety Blanket";
				ret.Availability = Availability.InShop;
				return ret;

			}
		}
		
		public static CharacterData CURSED_COURAGE {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 11;
				ret.Name = "Cuh Cuh Cursed Courage";
				ret.Description = "At the cost of your max health, fire faster and have a higher anxiety threshold.";
				ret.ActorType = ActorType.Pickup;
				ret.ResourcePath = "Items/CursedBuff_prefab";
				ret.PickupType = PickupType.Buff;

				ret.AddAbility(AbilityDataTable.CURSED_COURAGE_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.Droppable | Availability.InShop;
				
				return ret;
				
			}
			
		}
		
		public static CharacterData TRIGGER_FINGERS {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 12;
				ret.Name = "TRIGGER FINGERS";
				ret.Description = "Better firing speed";
				ret.ActorType = ActorType.Pickup;
				ret.AddAbility(AbilityDataTable.TRIGGER_FINGERS_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.ResourcePath = "Items/ItemBuff_prefab";
				
				ret.Availability = Availability.Droppable | Availability.InShop;
				
				return ret;
			}
			
		}
		
		public static CharacterData ANIMAL_HEART {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 13;
				ret.Name = "ANIMAL HEART";
				ret.Description = "Do more damage when at low health";
				ret.ActorType = ActorType.Pickup;

				ret.AddAbility(AbilityDataTable.LOW_HEALTH_DAMAGE_AMP_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.ResourcePath = "Items/ItemBuff_prefab";
				
				ret.Availability = Availability.Droppable | Availability.InShop;
				
				return ret;
			}
			
		}
		
		public static CharacterData WEAPON_DE_CURSER {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 14;
				ret.Name = "Weapon De-Curser";
				ret.Description = "Removes curses from your current weapons";
				ret.ActorType = ActorType.Pickup;
				ret.ResourcePath = "Items/ItemBuff_prefab";
				ret.Cost = 500;	

				ret.AddAbility(AbilityDataTable.WEAPON_DE_CURSER);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.InShop;
				return ret;
			}
		}

		public static CharacterData SHOP_CHEAPENER {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 15;
				ret.Name = "A Fancy Hat";
				ret.Description = "+5 charisma makes shop keepers give you a discount";
				ret.ActorType = ActorType.Pickup;
				ret.Cost = 1000;

				ret.AddAbility(AbilityDataTable.SHOP_CHEAPENER_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.InShop | Availability.Droppable;
				
				return ret;
			}

		}

		public static CharacterData KILL_DE_STRESSER {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 16;
				ret.Name = "Spiteful Heart";
				ret.Description = "Killing synth-heads reduces Anxiety";
				ret.ActorType = ActorType.Pickup;
				ret.Cost = 250;

				ret.AddAbility(AbilityDataTable.KILL_DE_STRESSER_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.InShop | Availability.Droppable;

				return ret;
			}

		}
		
		public static CharacterData YEE_HAW {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 17;
				ret.Cost = 50;
				ret.Name = "Yee Haw: A Beverage";
				ret.ResourcePath = "Items/SmallHealth_prefab";
				
				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupType.Item;

				ret.AddAbility(AbilityDataTable.YEE_HAW_BUFF);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);


				ret.Availability = Availability.InShop | Availability.Droppable | Availability.RoomClearReward;
				ret.Description = "Move faster until hit. Next hit costs anxiety instead of health";
				return ret;
			}

		}

		public static CharacterData SMALL_ADD_MAX_ANXIETY_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 18;
				ret.Cost = 100;
				ret.Name = "Nerves of Steel";
				ret.ResourcePath = "Items/SmallHealth_prefab";

				ret.ActorType = ActorType.Pickup;
				ret.PickupType = PickupType.Item;

				ret.AddAbility(AbilityDataTable.SMALL_ADD_MAX_ANXIETY);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.overrideAttributes.Add(new GameData.AttributeData(
					ActorAttributes.MaxAnxiety.Id,
					20
				));

				ret.Availability = Availability.InShop | Availability.Droppable | Availability.RoomClearReward;
				ret.Description = "Extends your maximum Anxiety";
				return ret;
			}
		}

		public static CharacterData BIG_HEALTH_PICKUP {
			get {
				var ret = new CharacterData();
				ret.Id = OFFSET + 19;
				ret.Description = "A generous health pickup";

				ret.PickupType = PickupType.Item;
				ret.ResourcePath = "Items/SmallHealth_prefab";
				ret.ActorType = ActorType.Pickup;
				ret.AddAbility(AbilityDataTable.BIG_HEAL);
				ret.AddAbility(AbilityDataTable.TOWER_ACTOR_ABSORBER);
				ret.AddAbility(AbilityDataTable.TOWER_ABSORPTION_TTL);

				ret.Availability = Availability.Droppable | Availability.InShop | Availability.RoomClearReward;
				ret.Cost = 45;
				ret.Name = "Blood Pack";
				return ret;
			}
		}
	}
}

