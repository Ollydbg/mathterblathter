using System;
using Client.Game.Actors;
using Client.Utils;
using Client.Game.Abilities;
using Client.Game.Data;
using Client.Game.Map;

namespace Client.Game.AI.Actions
{
	public class TeleportRandom : AIAction
	{
		public TeleportRandom ()
		{
		}

		
		public override AIResult Update (float dt, Character actor)
		{
			var ctx = new AbilityContext(actor, actor, AbilityDataTable.TELEPORT);

			ctx.targetPosition = Player.transform.position + VectorUtils.Vector3(UnityEngine.Random.insideUnitCircle);

			var room = actor.Game.RoomManager.CurrentRoom;
			var generator = new RoomWaveGenerator(room);
			ctx.targetPosition = generator.RandomSpawnLocationForType(actor.Data.SpawnType);
			
			actor.Game.AbilityManager.ActivateAbility(ctx);

			return AIResult.Success;
		}
        
	}
}

