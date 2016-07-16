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


		private static int _castingMask = -1;
		public static int CastingMask {
			get {
				if(_castingMask == -1) {
					_castingMask = LayerMask.GetMask(new string[]{Layers.HardGeometry.ToString(), Layers.Player.ToString()});

				}
				return _castingMask;
			}
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
			var hit = Physics2D.Raycast(origin, context.source.WeaponController.AimDirection, 100f, CastingMask);
			lr.SetPosition(0, origin);

			if(hit.transform != null) {
				lr.SetPosition(1, hit.point);
				
			} else {
				lr.SetPosition(1, origin + context.source.WeaponController.AimDirection * 100f);
			}
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

