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
		

		public static CharacterData PLAYER_CHARACTER2D {
			get {
				var ret = new CharacterData();
				ret.Id = 90000;
				ret.ResourcePath = "Actors/Player/Player_prefab";
				ret.ActorType = ActorType.Player;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 1200f
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
					ActorAttributes.MinJumpPower.Id, 26f
				)); 

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.JumpBoostFrameThresh.Id, 7
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxWeapons.Id, 2
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.SustainedJumpPower.Id, 9.5f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.MaxJumpPower.Id, 98.4f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.BaseDamage.Id, 15
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Inaccuracy.Id, 2f
				));
				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.WaveDifficulty.Id, 0
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.Health.Id, 15
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.MaxHealth.Id, 15
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Weapons.Id,
					CharacterDataTable.AUTO_HAMMER_WEAPON.Id,
					0
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Weapons.Id,
					CharacterDataTable.RUSTY_REPEATER.Id,
					1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.JumpBoostFrameFloor.Id,
					3
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.UsesAnxiety.Id,
					1
				));

				ret.attributeData.Add(new CharacterData.AttributeData(
					ActorAttributes.TeamID.Id, 1
				));


				ret.AddAbility(AbilityDataTable.INVULNERABLE_AFTER_HIT_BUFF);
				ret.AddAbility(AbilityDataTable.ANXIETY_REGEN_BUFF);
				ret.AddAbility(AbilityDataTable.ROOM_UNLOCK_HARDENER);
				ret.AddAbility(AbilityDataTable.ROOM_UNLOCK_DROP_BUFF);
				ret.AddAbility(AbilityDataTable.HIT_ENEMY_FLASH_BUFF);
				//ret.attributeData.Add(new CharacterData.AttributeData(AbilityDataTable.PLAYER_DEATH_BUFF.Id, (int)AbilitySlots.Death));

				return ret;
			}
		}


	}
}

