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
				if(!Target.Destroyed) {
					
					Target.transform.position = hit.point;
					Target.TryOnTrigger(hit.collider);
				
				} else {
					return;
				}
			}

			base.Update(dt);

		}

	}
}

