using System;
using UnityEngine;
using Client.Game.Data;
using Client.Game.Enums;
using Client.Utils;
using Client.Game.Abilities.Payloads;

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
			Vector3 origin = PointOnActor(AttachPoint.Muzzle, context.source);
			lr.SetPosition(0, origin);
			lr.SetPosition(1, origin + context.source.WeaponController.GetAimDirection()*100f);
		}


		public override void End ()
		{
			GameObject.Destroy(lr.gameObject);
		}

		public override bool OnPayloadReceive (Payload payload)
		{
			if( payload is KillPayload ) {
				Abort();
			}
			return false;
		}

		#endregion
	}
}

