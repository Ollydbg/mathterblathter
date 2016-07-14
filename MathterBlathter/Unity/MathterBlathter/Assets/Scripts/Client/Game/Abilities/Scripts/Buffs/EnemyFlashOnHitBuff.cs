using System;
using Client.Game.Abilities.Payloads;
using UnityEngine;
using System.Collections.Generic;
using Client.Game.Actors;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class EnemyFlashOnHitBuff : BuffBase
	{
		private List<HitActor> hitActors = new List<HitActor>();

		public EnemyFlashOnHitBuff ()
		{
		}


		public override void Start ()
		{
		}

		public override void Update (float dt)
		{

			var count = hitActors.Count;
			if(count > 0) {
				for(var i = (count-1); i>= 0; i-- )  {
					var repl = hitActors[i];
					repl.framesLeft = repl.framesLeft -1;
					if(repl.framesLeft <= 0) {
						repl.material.SetFloat("_FlashAmount", 0f);
						hitActors.Remove(repl);
						repl.actor.Animator.SetIsHit(false);
					}
				}
			}
		}

		public override void End ()
		{
			
		}

		public override bool OnPayloadSend (Payload payload)
		{
			var dp = payload as DamagePayload;

			if(dp != null) {
				var renderers = dp.Target.GameObject.GetComponentsInChildren<Renderer>(); 
				
				foreach( var r in renderers ) {
					if( r is SpriteRenderer) {
						
						dp.Target.Animator.SetIsHit(true);
						var mat = r.material;
						hitActors.Add(new HitActor(mat, 2, dp.Target));
						mat.SetFloat("_FlashAmount", 1f);
					} 
				}
			}

			return false;
		}

		private class HitActor {
			public Material material;
			public int framesLeft;
			public Actor actor;

			public HitActor(Material mat, int frames, Actor actor) {
				material = mat;
				framesLeft = frames;
				this.actor = actor;
			}

		}

	}


		

}

