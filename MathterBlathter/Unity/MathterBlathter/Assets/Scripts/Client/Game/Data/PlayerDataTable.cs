using System;
using Client.Game.Attributes;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Enums;

namespace Client.Game.Data
{
	public static partial class CharacterDataTable
	{
		

		public static CharacterData PLAYER_CHARACTER3D {
			get {
				var ret = new CharacterData ();
				ret.Id = 1;
				ret.ResourcePath = "Actors/Arthur/Prefabs/arthur_prefab";
				ret.ActorType = ActorType.Player;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 20f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.PassesThroughPlatforms.Id, 1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Anxiety.Id, 0
				));

				ret.attributeData.Add(new GameData.AttributeData( 
					ActorAttributes.MaxAnxiety.Id, 200
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AnxietyRegen.Id, 2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MinJumpPower.Id, .3f
				)); 

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxWeapons.Id, 2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.SustainedJumpPower.Id, 10f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MaxJumpPower.Id, .45f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.BaseDamage.Id, 15
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Inaccuracy.Id, 2f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.RunDifficulty.Id, 4
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Weapons.Id,
					CharacterDataTable.RUSTY_REPEATER.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.PLAYER_DEATH_BUFF.Id,
					(int)AbilitySlots.Death
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.INVULNERABLE_AFTER_HIT_BUFF.Id,
					0
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.ANXIETY_REGEN_BUFF.Id,
					1
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.ROOM_UNLOCK_HARDENER.Id,
					2
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.ROOM_UNLOCK_DROP_BUFF.Id,
					3
				));

				return ret;
			}
		}


		public static CharacterData PLAYER_CHARACTER2D {
			get {
				var ret = PLAYER_CHARACTER3D;
				ret.Id = 90000;
				ret.ResourcePath = "Actors/Player/Player_prefab";
				ret.ActorType = ActorType.Player;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 30f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.PassesThroughPlatforms.Id, 1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TakesDamage.Id, 1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Anxiety.Id, 0
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.GravityScalar.Id, 9.4f
				));

				ret.attributeData.Add(new GameData.AttributeData( 
					ActorAttributes.MaxAnxiety.Id, 200
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.AnxietyRegen.Id, 2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MinJumpPower.Id, 38.5f
				)); 

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxWeapons.Id, 2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.SustainedJumpPower.Id, 38.18f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MaxJumpPower.Id, 96.4f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.BaseDamage.Id, 15
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Inaccuracy.Id, 2f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.RunDifficulty.Id, 4
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Weapons.Id,
					CharacterDataTable.RUSTY_REPEATER.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 
					AbilityDataTable.PLAYER_DEATH_BUFF.Id,
					(int)AbilitySlots.Death
				));


				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.INVULNERABLE_AFTER_HIT_BUFF.Id,
					0
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.ANXIETY_REGEN_BUFF.Id,
					1
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.ROOM_UNLOCK_HARDENER.Id,
					2
				));

				ret.attributeData.Add( new CharacterData.AttributeData(
					ActorAttributes.Abilities.Id,
					AbilityDataTable.ROOM_UNLOCK_DROP_BUFF.Id,
					3
				));


				return ret;
			}
		}


	}
}

