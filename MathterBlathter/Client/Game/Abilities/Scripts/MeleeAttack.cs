using System;
using Client.Game.Animation;

namespace Client.Game.Abilities.Scripts
{
	public class MeleeAttack : AbilityBase
	{
		public MeleeAttack ()
		{
		}



		#region implemented abstract members of AbilityBase
		public override void Start ()
		{
			this.context.source.Animator.RequestState (States.ATTACK1, 1, 1);	
		}
		public override void Update (float dt)
		{
			
		}
		public override void End ()
		{
			
		}
		#endregion
	}
}

