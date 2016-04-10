using System;
using Client.Game.Managers;
using System.Collections.Generic;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;
using Client.Game.Abilities.Scripts;

namespace Client.Game.Abilities
{
	public class AbilityManager : IGameManager
	{

		public Dictionary<Actor, List<AbilityBase>> Abilities = new Dictionary<Actor, List<AbilityBase>>();


		public AbilityManager ()
		{
			
		}


		public void Init ()
		{
			
		}


		public void Update (float dt)
		{
			
		}

		public void ActivateAbility(AbilityContext ctx) {
			
			var ability = (AbilityBase)Activator.CreateInstance(ctx.data.executionScript);
			Abilities [ctx.source] = new List<AbilityBase> ();
			Abilities [ctx.source].Add (ability);

			ability.Init (ctx);
			ability.Start ();

		}

		public void TriggerPayload (Payload payload)
		{
			
		}
	}
}

