using System;
using Client.Game.Abilities.Payloads;
using UnityEngine;
using System.Collections.Generic;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class EnemyFlashOnHitBuff : BuffBase
	{
		private List<MaterialColorTuple> replacements = new List<MaterialColorTuple>();

		public EnemyFlashOnHitBuff ()
		{
		}


		public override void Start ()
		{
		}

		public override void Update (float dt)
		{
			for(var i = 0; i<replacements.Count; i++ )  {
				var repl = replacements[i];
				repl.framesLeft = repl.framesLeft -1;;
				if(repl.framesLeft <= 0) {
					repl.material.SetFloat("_FlashAmount", 0f);
					replacements.Remove(repl);
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

						var mat = r.material;
						replacements.Add(new MaterialColorTuple(mat, 4));
						mat.SetFloat("_FlashAmount", 1f);
					} 
				}
			}

			return false;
		}

		private class MaterialColorTuple {
			public Material material;
			public int framesLeft;
			

			public MaterialColorTuple(Material mat, int frames) {
				material = mat;
				framesLeft = frames;
			}

		}

	}


		

}

