using System;
using Client.Game.Map;
using Client.Game.Attributes;
using UnityEngine;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class PlayerRunHardenerBuff : BuffBase
	{
		public PlayerRunHardenerBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			context.source.Game.RoomManager.OnCurrentRoomUnlocked += OnRoomUnlocked;
		}

		void OnRoomUnlocked (Room room)
		{
			//make the game harder
			context.targetActor.Attributes[ActorAttributes.RoomDifficulty] += this.Attributes[ActorAttributes.RoomUnlockDifficultyIncr];
			
		}

		public override void Update (float dt)
		{
			
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

