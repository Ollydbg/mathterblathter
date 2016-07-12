using System;
using Client.Game.Attributes;
using Client.Game.Abilities.Payloads;
using UnityEngine;
using Client.Game.Actors;
using System.Collections.Generic;
using Client.Utils;
using Client.Game.Utils;

namespace Client.Game.Abilities.Scripts.Buffs
{
	public class ControllerAimAssistBuff : BuffBase
	{
		
		public ControllerAimAssistBuff ()
		{
		}

		bool DebugRays = false;

		public override void Start ()
		{

			Debug.LogWarning("ADDING CONTROLLER SLOP ADJUSTMENT BUFF");
			context.source.Attributes[ActorAttributes.ControllerAimAssist] += this.Attributes[ActorAttributes.ControllerAimAssist];
		}

		public override void Update (float dt)
		{
			
		}

		public override bool OnPayloadSend (Payload payload)
		{
			var wpnPayload = payload as WeaponFirePayload;
			if(wpnPayload != null) {
				Adjust(payload.Context);
			}

			return false;
		}

		void Adjust (AbilityContext firingContext)
		{
			var start = VectorUtils.Vector2(context.source.transform.position);
			var matches = new List<ScoredMatch>();
			var tolerance = context.source.Attributes[ActorAttributes.ControllerAimAssist];
			var direction2D = VectorUtils.Vector2(firingContext.targetDirection);
			var hits = Physics2D.CircleCastAll(start, 10f, direction2D, 20f);

			ScoredMatch match = null;
			foreach( var hit in hits ) {
				if(TryScore(start, tolerance, direction2D, hit, out match)) {
					matches.Add(match);
				}
			}

			if(matches.Count > 0) {
				matches.Sort(MatchComparer);
				if(DebugRays) {
					Debug.DrawRay(start, matches[0].Direction*20f, Color.green, 2f);
				}
				firingContext.targetDirection = matches[0].Direction;
			}



		}


		bool TryScore (Vector2 start, float tolerance, Vector2 targetDirection, RaycastHit2D hit, out ScoredMatch match)
		{
			if(DebugRays) {
				Debug.DrawRay(start, targetDirection* 20f, Color.red, 2f);
			}

			Actor actor = null;
			if(ActorUtils.TryHitToActor(hit, out actor)){
				var resultDirection = (actor.HalfHeight2D - start).normalized;
				var angle = Mathf.Abs(Vector2.Angle(resultDirection, targetDirection));

				var score = angle + (hit.distance * .3f);


				if(DebugRays) {
					Debug.DrawLine(start, hit.point, Color.gray, 2f);
				}

				if(angle <= tolerance ) {


					if(DebugRays) {
						Debug.DrawLine(start, hit.point, Color.cyan, 2f);
					}

					match = new ScoredMatch();
					match.Direction = resultDirection;
					match.Score = score;

					return true;
				}
			}

			match = null;
			return false;
		}

		private class ScoredMatch {
			public float Score;
			public Vector2 Direction;

		}

		private static MatchComparator MatchComparer = new MatchComparator();
		private class MatchComparator: IComparer<ScoredMatch> {
			#region IComparer implementation

			public int Compare (ScoredMatch x, ScoredMatch y)
			{
				return x.Score.CompareTo(y.Score);
			}

			#endregion


		}

		public override void End ()
		{
			context.source.Attributes[ActorAttributes.ControllerAimAssist] -= this.Attributes[ActorAttributes.ControllerAimAssist];
		}

	}
}

