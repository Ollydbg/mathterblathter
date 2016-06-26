using System;
using Client.Game.Attributes;
using UnityEngine;
using Client.Game.Abilities.Utils;
using Client.Game.Actors;
using Client.Game.Abilities.Payloads;

namespace Client.Game.Abilities.Scripts
{
	public class EnergySap : AbilityBase
	{
		public EnergySap ()
		{
		}

		bool blowingUp = false;

		#region implemented abstract members of AbilityBase

		public override void Start ()
		{
			var target = context.source.Game.PossessedActor;

			var damage = this.Attributes[AbilityAttributes.Damage];

			target.Attributes[ActorAttributes.Anxiety] += damage;
			context.source.Attributes[ActorAttributes.Anxiety] += damage;
			PlayTimeline(context.data.Timelines[0], target);
			PlayTimeline(context.data.Timelines[0], context.source);

			var alpha = context.source.Attributes[ActorAttributes.Anxiety] / context.source.Attributes[ActorAttributes.MaxAnxiety];
			var targetColor = Color.Lerp(Color.white, Color.yellow, alpha);

			context.source.transform.GetComponent<Renderer>().material.color = targetColor;

			context.source.transform.localScale *= 1.05f;


			if(alpha >=1f) {
				blowingUp = true;
			}

		}
		private Vector3 blowupScale;
		private float blowupTime = .5f;

		public override void Update (float dt)
		{
			if(blowingUp) {
				context.source.transform.localScale = blowupScale * UnityEngine.Random.Range(.9f, 1.1f);
				blowupTime -= dt;

				if(blowupTime <= 0f) {
					Explode();
				}
			}
		}

		void Explode ()
		{
			blowupScale = context.source.transform.localScale;

			PlayTimeline(context.data.Timelines[1], context.source);

			var inRange = AbilityUtils.OverlapCircle(
				context.source.transform.position, 
				context,
				this.context.source.Attributes[ActorAttributes.ExplosionRadius],
				new FilterList(Filters.Hittable));
			var damage = (float)context.source.Attributes[ActorAttributes.Anxiety];
			damage *= context.source.Attributes[ActorAttributes.AnxietyDamageScalar];

			foreach( Actor tgt in inRange) {
				new DamagePayload (context, tgt, damage).Apply();
			}
		}

		public override bool IsComplete ()
		{
			return !blowingUp && TimelineRunner.IsComplete();
		}

		public override void End ()
		{
			
		}

		#endregion
	}
}

