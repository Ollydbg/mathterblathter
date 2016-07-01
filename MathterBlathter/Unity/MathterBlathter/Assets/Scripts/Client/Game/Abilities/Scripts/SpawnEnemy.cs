using System;
using Client.Game.Data;
using Client.Game.Enums;

namespace Client.Game.Abilities.Scripts
{
	public class SpawnEnemy : AbilityBase
	{
		
		public SpawnEnemy ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var spawnData = CharacterDataTable.FromId(context.data.spawnableDataId);

			var actor = context.source.Game.ActorManager.Spawn(spawnData);
			var pos = PointOnActor(AttachPoint.WeaponSlot, context.source);

			var xDiff = context.source.Game.Seed.InRange(-1, 1);
			var yDiff = context.source.Game.Seed.NextFloat();

			pos += new UnityEngine.Vector3(xDiff, yDiff, 0f)*3;

			actor.transform.position = pos; 

			Game.RoomManager.CurrentRoom.Waves.AddActor(actor);

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

