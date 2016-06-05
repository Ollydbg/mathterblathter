using Client.Game.AI;
using Client.Game.Data;
using UnityEngine;
namespace Client.Game.Abilities.Scripts
{
    public class AIBuff : BuffBase
	{

		public Brain Brain;

		public AIBuff ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			Brain = new Brain(context.source);
			
			var aiData = context.source.Data.AIData;
			
			if(aiData == null) {
				Debug.LogError(string.Format("NO AIDATA SPECIFIED FOR AI BUFF TO LOAD FOR SOURCE ACTOR ID: {0}!!", context.source.Data.Id));
				Abort();
			} else {
				Brain.LoadFromData(aiData);
			}
			
			
		}


		public override void Update (float dt)
		{
			Brain.Update(dt);

		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

