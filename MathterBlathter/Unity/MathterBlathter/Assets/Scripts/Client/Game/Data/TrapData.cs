using System;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static partial class MockActorData
	{
		public static CharacterData SPIKES {
			get {
				var ret = new CharacterData ();
				ret.Id = 8;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.AIData = new AIData ();
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
				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id, 
					MockAbilityData.DAMAGE_ON_TOUCH_BUFF.Id,
					0
				));


				return ret;
			}
		}

		public static CharacterData WALL_TURRET {
			get {
				var ret = new CharacterData();
				ret.Id = 9;
				ret.ResourcePath = "Actors/RoomFeatures/Spike_prefab";
				ret.ActorType = ActorType.Fixture;
				ret.AIData = new AIData();
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
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id, 
					MockAbilityData.FIRING_FIXTURE_BUFF.Id,
					0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Weapons.Id,
					MockActorData.WALL_TURRET_WEAPON.Id,
					0
				));

				return ret;
			}
		}
	}
}

