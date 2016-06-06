using System;
using Client.Game.Actors;

namespace Client.Game.AI.Actions
{
	public class TestPlayerLOS : AIAction
	{
		public TestPlayerLOS ()
		{
		}

		#region implemented abstract members of AIAction

		public override AIResult Update (float dt, Actor actor)
		{
			var target = PlayerMid;
			var distanceVec = target-actor.transform.position;

			if(ActionUtil.InDetectionRange(distanceVec, actor)) {
				return ActionUtil.HasLOS(actor, target) ? AIResult.Success : AIResult.Running;
			} else {
				return AIResult.Failure;
			}
		}
		#endregion
	}
	
	public class HasPlayerLOS : AIAction 
	{
		public HasPlayerLOS ()
		{
		}

		#region implemented abstract members of AIAction

		public override AIResult Update (float dt, Actor actor)
		{
			var target = PlayerMid;
			var distanceVec = target-actor.transform.position;

			if(ActionUtil.InDetectionRange(distanceVec, actor)) {
				return ActionUtil.HasLOS(actor, target) ? AIResult.Running : AIResult.Failure;
			} else {
				return AIResult.Failure;
			}
		}

		#endregion
		
	}
}

