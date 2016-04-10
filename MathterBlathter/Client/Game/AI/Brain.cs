using System;
using Client.Game.Actors;

namespace Client.Game.AI
{
	public class Brain
	{
		public AIAction CurrentAction;
		public Actor Self;

		public Brain (Actor actor)
		{
			this.Self = actor;
		}

		public void Update( float dt) {
			if (CurrentAction != null) {
				if (CurrentAction.Update (dt, Self) != AIResult.Incomplete) {
					CurrentAction = CurrentAction.Next;
				}
			}
		}
	}
}

