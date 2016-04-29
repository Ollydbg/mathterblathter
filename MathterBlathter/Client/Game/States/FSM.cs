using System;
using Client.Game.Managers;
using UnityEngine;

namespace Client.Game.States
{
	using Game = Client.Game.Core.Game;

	public class FSM : IGameManager
	{
		public delegate void StateChangeDelegate(State from, State to);
		public StateChangeDelegate OnStateChanged;

		private State _current;
		public State CurrentState {
			get {
				return _current;
			}
			set {
				var old = _current;
				if(_current != null) {
					
					_current.Exit();
				}
				_current = value;
				_current.Enter();
				Debug.Log("Entering state: " + _current.GetType().Name);
				if(OnStateChanged != null) {
					OnStateChanged(old, _current);
				}
			}
		}

		public FSM ()
		{
		}


		public bool didStart = false;
		public void Start (Game game)
		{
			if(!didStart) {
				this.CurrentState = new InitState();
				didStart = true;
			}
		}


		public void Update (float dt)
		{
			CurrentState.Update(dt);
		}


		public void Shutdown ()
		{
		}


		public void SetPlayerCharacter (Client.Game.Actors.PlayerCharacter player)
		{
		}



	}

	public abstract class State {
		public abstract void Enter();
		public abstract void Exit();
		public abstract void Update(float dt);

		public void Change<T>() where T : State {
			Game.Instance.States.CurrentState = Activator.CreateInstance<T>();
		}
	}
}

