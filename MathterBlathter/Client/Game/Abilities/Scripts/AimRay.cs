using System;
using UnityEngine;
using Client.Game.Data;

namespace Client.Game.Abilities.Scripts
{
	
	public class AimRay : BuffBase
	{
		public AimRay ()
		{
		}

		#region implemented abstract members of AbilityBase
		LineRenderer lr;
		public override void Start ()
		{
			var path = "Projectiles/VFX/aimLine_prefab";
			var go = (GameObject)GameObject.Instantiate(Resources.Load(path));

			lr = go.GetComponent<LineRenderer>();
			lr.SetWidth(.1f, .01f);

		}

		public override void Update (float dt)
		{
			lr.SetPosition(0, AttachPointPositionOnActor(Client.Game.Enums.AttachPoint.Muzzle, context.source));
			lr.SetPosition(1, context.source.Game.PossessedActor.HalfHeight);
		}

		public override void End ()
		{
		}

		#endregion
	}
}

