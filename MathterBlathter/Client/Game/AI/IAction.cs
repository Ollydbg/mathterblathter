using System;

namespace Client.Game.AI
{
	public interface IAction
	{
		bool IsComplete();
		bool Update(float dt);
	}
}

