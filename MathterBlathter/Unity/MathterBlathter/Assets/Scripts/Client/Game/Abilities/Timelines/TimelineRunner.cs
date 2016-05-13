using System;
using Client.Game.Data;
using Client.Game.Actors;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.Abilities.Utils;

namespace Client.Game.Abilities.Timelines
{
	public class TimelineRunner
	{
		public const char SFX_TRACK = 's';
		public const char VFX_TRACK = 'e';
		public delegate void Handler(TimelineData.Point pt, TimelineData data, Actor actor);
		public static Dictionary<char, Handler> HandlerMap;

		public TimelineRunner ()
		{
			if(HandlerMap == null) {
				HandlerMap = new Dictionary<char, Handler>();
				HandlerMap[SFX_TRACK] = PlaySFX;
				HandlerMap[VFX_TRACK] = PlayVFX;
			}
		}

		public void Play (TimelineData timelineData, Actor target)
		{
			//lets keep this dumb for now and only add persisted ticking when we need it
			foreach( var kvp in timelineData.Lookup) {
				HandlerMap[kvp.Key](kvp.Value, timelineData, target);
			}
		}


		static void PlaySFX (TimelineData.Point pt,TimelineData data, Actor actor)
		{

			var ac = Resources.Load(pt.Resource) as AudioClip;
			AudioSource.PlayClipAtPoint(ac, AttachPointComponent.AttachPointPositionOnActor(pt.AttachPoint, actor));

		}

		static void PlayVFX (TimelineData.Point pt, TimelineData data, Actor actor) {

			var go = (GameObject)GameObject.Instantiate(
				Resources.Load(pt.Resource),
				AttachPointComponent.AttachPointPositionOnActor(pt.AttachPoint, actor),
				Quaternion.identity
			);
			var ttl = go.AddComponent<EffectTTL>();
			ttl.TimeToLive = data.Duration;

		}

	}
}

