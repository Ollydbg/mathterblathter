using System;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	using Game = Client.Game.Core.Game;

	public class PlayerDeathBuff : AbilityBase
	{
		bool Dying;

		float timeAccumulator = 0f;
		public PlayerDeathBuff ()
		{
		}


		public override void Start ()
		{
			if(!Dying) {
				Dying = true;
				timeAccumulator = 0f;

			}
		}

		public override bool IsComplete ()
		{
			return timeAccumulator > 0;
		}

		public override void Update (float dt)
		{
			timeAccumulator += dt;
		}

		public override void End ()
		{
			Game.Instance.Restart();	
		}

	}
}

