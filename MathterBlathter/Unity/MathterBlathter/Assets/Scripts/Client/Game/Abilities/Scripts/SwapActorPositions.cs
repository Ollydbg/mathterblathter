﻿using System;
using Client.Game.Data;
using UnityEngine;
using Client.Game.Actors;
using Client.Game.Attributes;
using Client.Game.Enums;
using Client.Game.Abilities.Payloads;
using Client.Utils;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Scripts
{
	public class SwapActorPositions : RailGunAttack
	{
		public SwapActorPositions ()
		{
		}

		void Swap (Actor source, Actor hitActor)
		{
			var sourcePos = source.transform.position;
			var targetPos = hitActor.transform.position;

            PlayTimeline(context.data.Timelines[4], sourcePos);
            PlayTimeline(context.data.Timelines[5], targetPos);

            source.transform.position = targetPos + Vector3.up;
			hitActor.transform.position = sourcePos;
		}

		public override void OnHit (Actor hitActor)
		{
			Swap(context.source, hitActor);
			base.OnHit (hitActor);
		}

	}
}

