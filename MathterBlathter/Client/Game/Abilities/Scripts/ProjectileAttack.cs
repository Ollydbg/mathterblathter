using System;
using UnityEngine;

namespace Client.Game.Abilities.Scripts
{
	public class ProjectileAttack : AbilityBase
	{
		public ProjectileAttack ()
		{
		}

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var go = FireProjectile (context.data.spawnableResourcePath);
			go.transform.position += Vector3.up *.5f;
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

