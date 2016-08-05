using System;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{
		private static int TRAP_OFFSET = 2<<8; //512

		public static CharacterData LAUNCH_PAD_FIXTURE {
			get {
				var ret = new CharacterData();
				ret.Id = TRAP_OFFSET+0;
				ret.ActorType = ActorType.Fixture;
				ret.AIData = new AIData ();
				ret.Name = "LaunchPad";
				ret.ResourcePath = "Actors/RoomFeatures/LaunchPad/LaunchPad_prefab";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, ActorAttributes.Health.MaxValue
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 0f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.KnockbackForce.Id, 80f
				));
				ret.AddAbility(AbilityDataTable.LAUNCH_PAD_BUFF);


				return ret;
			}
		}

		public static CharacterData UPGRADEABLE_TRAP_FIXTURE {
			get {
				var ret = new CharacterData();
				ret.Id = TRAP_OFFSET + 1;
				ret.ActorType = ActorType.Fixture;
				ret.AIData = new AIData();
				ret.Name = "Upgradeable proxy";

				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";

				ret.AddIndexed(SPIKES_FIXTURE, ActorAttributes.DataIds);
				ret.AddIndexed(WALL_TURRET_FIXTURE, ActorAttributes.DataIds);
				ret.AddIndexed(GRENADE_GEYSER_FIXTURE, ActorAttributes.DataIds);

				ret.AddAbility(AbilityDataTable.UPGRADEABLE_TRAP_BUFF);

				return ret;
			}
		}

		public static CharacterData SPIKES_FIXTURE {
			get {
				var ret = new CharacterData ();
				ret.Id = TRAP_OFFSET + 2;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.Name = "Spikes";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, ActorAttributes.Health.MaxValue
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.BaseDamage.Id, 1
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 0f
				));

				ret.AddAbility(AbilityDataTable.DAMAGE_ON_TOUCH_BUFF);


				return ret;
			}
		}


		public static CharacterData RETRACTING_SPIKES_FIXTURE {
			get {
				var ret = new CharacterData ();
				ret.Id = TRAP_OFFSET + 3;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.Name = "Spikes";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, ActorAttributes.Health.MaxValue
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.BaseDamage.Id, 5
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 0f
				));

				ret.AddAbility(AbilityDataTable.DAMAGE_ON_TOUCH_BUFF);

				return ret;
			}
		}



		public static CharacterData WALL_TURRET_FIXTURE {
			get {
				var ret = new CharacterData();
				ret.Id = TRAP_OFFSET + 4;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.AIData = AIDataTable.FIRING_FIXTURE_AI;
				ret.Name = "Wall Turret";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, ActorAttributes.Health.MaxValue
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.BaseDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 0f
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.WALL_TURRET_WEAPON.Id,
					0
				));

				return ret;
			}
		}

		public static CharacterData GRENADE_GEYSER_FIXTURE {
			get {
				var ret = new CharacterData();
				ret.Id = TRAP_OFFSET + 5;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.AIData = AIDataTable.FIRING_FIXTURE_AI;
				ret.Name = "Wall Turret";
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, ActorAttributes.Health.MaxValue
				));
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.BaseDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 0f
				));

				ret.AddAbility(AbilityDataTable.AI_BUFF);

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					CharacterDataTable.WALL_TURRET_WEAPON.Id,
					0
				));

				return ret;
			}
		}

	}
}

