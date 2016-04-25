using System;
using Client.Game.AI;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class FiringFixtureBuff : BuffBase
	{

		public Brain Brain;

		public FiringFixtureBuff ()
		{
		}

		public override void Start ()
		{
			Brain = new Brain(context.source);
			Brain.CurrentAction = new Client.Game.AI.Actions.FireDirection(-context.source.transform.rotation.eulerAngles.normalized);
		}

		public override void Update (float dt)
		{
			Brain.Update(dt);
		}

		public override void End ()
		{
		}

	}
}

