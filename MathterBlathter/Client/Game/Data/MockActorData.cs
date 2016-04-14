using System;
using Client.Game.Attributes;

namespace Client.Game.Data
{
	public static class MockActorData
	{
		
		public static CharacterData PLAYER_TEST {
			get {
				var ret = new CharacterData ();
				ret.ResourcePath = "Actors/Arthur/Prefabs/arthur_prefab";
				ret.ActorType = ActorType.Player;
				ret.Id = 1;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 20f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.JumpHeight.Id, .6f
				));

				return ret;
			}
		}

		public static CharacterData ENEMY_TEST {
			get {
				var ret = new CharacterData ();
				ret.ResourcePath = "EnemyTest_prefab";
				ret.ActorType = ActorType.Enemy;
				ret.AIData = new AIData ();
				ret.Id = 100;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Health.Id, 100
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.AIDetectionRadius.Id, 20.0f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, .08f
				));
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Abilities.Id, 100
				));



				return ret;
			}
		}


	}
}

