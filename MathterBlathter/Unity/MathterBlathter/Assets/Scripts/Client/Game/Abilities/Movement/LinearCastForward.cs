using System;
using UnityEngine;
using Client.Game.Actors;
using Client.Utils;

namespace Client.Game.Abilities.Movement
{
	public class LinearCastForward : Linear
	{
		public LinearCastForward() {}

		public LinearCastForward (ProjectileActor actor, Vector3 direction, float speed) 
			: base(actor, direction, speed)
		{
			
		}

		public override void Update(float dt) 
		{
			var start = VectorUtils.Vector2(Target.transform.position);
			var moveVec = this.Direction * Speed * dt;

			var hits = Physics2D.LinecastAll(start, start + moveVec);


			foreach( var hit in hits ) {
				var res = Target.TryOnTrigger(hit.collider);

				if(res == TriggerTestResult.Geometry ) {
					Target.transform.position = hit.point;
					return;
				}
			}

			base.Update(dt);


		}
	}
}

