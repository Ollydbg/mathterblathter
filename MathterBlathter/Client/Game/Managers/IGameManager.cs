using System;

namespace Client.Game.Managers
{
	public interface IGameManager
	{

		void Start(Client.Game.Core.Game game);
		void Update(float dt);
		void Shutdown();
	}
}

