using System;
using Client.Game.Attributes;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Data
{
	public static class MockActorData
	{
		private static Dictionary<int, CharacterData> _all;
		static void StaticInit() {
			_all = typeof(MockActorData).GetProperties()
				.Select( p => p.GetGetMethod().Invoke(null, null) as CharacterData)
				.ToDictionary(p => p.Id, p=>p);
			
		}

		public static CharacterData FromId(int id) {
			if(_all == null) StaticInit();
			return _all[id];
		}

		public static CharacterData PLAYER_TEST {
			get {
				var ret = new CharacterData ();
				ret.ResourcePath = "Actors/Arthur/Prefabs/arthur_prefab";
				ret.ActorType = ActorType.Player;
				ret.Id = 1;
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.Speed.Id, 25f
				));

				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.JumpPower.Id, .65f
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
				ret.attributeData.Add (new CharacterData.AttributeData (
					ActorAttributes.GravityScalar.Id, 0.0f
				));



				return ret;
			}
		}


	}
}

