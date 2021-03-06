﻿using System;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Data;
using Client.Game.Utils;
using Client.Game.Attributes;
using System.Linq;
using Client.Game.Actors;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class UpgradeableTrapBuff : BuffBase
	{
		private int level = -1;
		private List<CharacterData> Levels = new List<CharacterData>();
		private Actor Child;

		Vector3 SpawnPosition;
		Quaternion SpawnRotation;

		public UpgradeableTrapBuff ()
		{
			
		}

		#region implemented abstract members of AbilityBase

        public int MaxLevel {
            get {
                return Levels.Count - 1;
            }
        }

		public bool ShouldUpgradeTo(int newLevel) {
            //clamp here
            if (newLevel > MaxLevel)
                newLevel = MaxLevel;

			return newLevel > level;
		}

		private bool DidInit = false;

		public void SetLevel( int newLevel ) {
			level = newLevel;
			if(Child != null) {
				Child.Destroy();
			}

			Child = Game.ActorManager.Spawn(Levels[level]);
			Child.SpawnData = Owner.SpawnData;
			Child.transform.position = SpawnPosition;
			Child.transform.rotation = SpawnRotation;

			if(DidInit) 
				PlayTimeline(context.data.Timelines[0], Child.TerrainCollider.bounds.center);

			DidInit = true;

		}


		public override void Start ()
		{
			
			SpawnPosition = context.source.GameObject.transform.position;
			SpawnRotation = context.source.GameObject.transform.rotation;
			context.source.GameObject.SetActive(false);
			
			Levels = ActorUtils
				.IterateAttributes(context.source, ActorAttributes.DataIds)
				.Select(p => CharacterDataTable.FromId(p))
				.ToList();
			
		}

		public int PlayerRoomDifficulty {
			get {
				return Game.PossessedActor.Attributes[ActorAttributes.RoomDifficulty];
			}
		}

		public override void Update (float dt)
		{
			var newDiff = PlayerRoomDifficulty;
			if(ShouldUpgradeTo(newDiff)) {
				SetLevel(newDiff);
			}

			if(Input.GetKeyDown(KeyCode.U)) {
				Game.PossessedActor.Attributes[ActorAttributes.RoomDifficulty] ++;
			}

		}

		public override void End ()
		{
		}

		#endregion
	}
}

