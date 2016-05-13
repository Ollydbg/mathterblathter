using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Data;
using UnityEngine;

namespace Client.Game.States
{
	using Game = Client.Game.Core.Game;

	public class RunState : State
	{
		private IGameManager[] TickManagers;

		public RunState ()
		{
		}


		public override void Enter ()
		{
			var tmp = new List<IGameManager>();

			tmp.Add(Game.Instance.InputManager);
			tmp.Add(Game.Instance.AbilityManager);
			tmp.Add(Game.Instance.RoomManager);
			tmp.Add(Game.Instance.UIManager);
			tmp.Add(Game.Instance.ActorManager);
			tmp.Add(Game.Instance.CameraManager);


			TickManagers = tmp.ToArray();

			Game.Instance.PossessedActor = Game.Instance.ActorManager.Spawn<PlayerCharacter> (MockActorData.PLAYER_TEST);

			new List<IGameManager>(TickManagers).ForEach(p => p.Start (Game.Instance));

			new List<IGameManager>(TickManagers).ForEach(p => p.SetPlayerCharacter (Game.Instance.PossessedActor));

		}

		public override void Exit ()
		{
			new List<IGameManager>(TickManagers).ForEach(p => p.Shutdown());
		}

		public override void Update (float dt)
		{
			for( int i = 0; i<TickManagers.Length; i++ ) {
				TickManagers[i].Update(dt);
			}
		}

	}
}

