using System;
using Client.Game.Data;
using Client.Game.Actors;
using System.Collections.Generic;
using UnityEngine;
using Client.Game.Enums;
using Client.Game.Abilities.Utils;
using UnityEngine.Audio;

namespace Client.Game.Abilities.Timelines
{
	public class TimelineRunner
	{
		public const char SFX_TRACK = 's';
		public const char VFX_TRACK = 'e';
		public delegate void Handler(TimelineData.Point pt, TimelineData data, GameObject gameObject, Vector3 direction);
		public Dictionary<char, Handler> HandlerMap;

		public static AudioMixerGroup SFXGroup;

		public float CompleteAt;
		public bool IsComplete() {
			return Time.time >= CompleteAt;
		}

		List<GameObject> persistentTimelines = new List<GameObject>();

		public TimelineRunner ()
		{
			if(HandlerMap == null) {
				HandlerMap = new Dictionary<char, Handler>();
				HandlerMap[SFX_TRACK] = PlaySFX;
				HandlerMap[VFX_TRACK] = PlayVFX;
			}
		}

		public void Play (TimelineData timelineData, Actor target, Vector3 direction)
		{
			if(SFXGroup == null) 
				SFXGroup = target.Game.AudioMixer.FindMatchingGroups("Weapons")[0];

			//lets keep this dumb for now and only add persisted ticking when we need it
			foreach( var kvp in timelineData.Lookup) {
				HandlerMap[kvp.Key](kvp.Value, timelineData, target.GameObject, direction);
			}

			CompleteAt = Mathf.Max(CompleteAt, Time.time + timelineData.Duration);
		}

		public void Play (TimelineData timelineData, Vector3 worldPos, Vector3 direction)
		{
			//lets keep this dumb for now and only add persisted ticking when we need it
			var go = new GameObject();
			go.AddComponent<EffectTTL>().TimeToLive = timelineData.Duration;
			go.transform.position = worldPos;
			foreach( var kvp in timelineData.Lookup) {
				HandlerMap[kvp.Key](kvp.Value, timelineData, go, direction);
			}
		}

		public void Play(TimelineData timelineData, GameObject gameObject, Vector3 direction) {
			foreach( var kvp in timelineData.Lookup) {
				HandlerMap[kvp.Key](kvp.Value, timelineData, gameObject, direction);
			}
		}


		void PlaySFX (TimelineData.Point pt,TimelineData data, GameObject go, Vector3 direction)
		{
			var source = go.GetComponent<AudioSource>();
			var ac = Resources.Load(pt.Resource) as AudioClip;
			if(source == null) {
				source = go.AddComponent<AudioSource>();

				source.spatialBlend = 0f;
				source.rolloffMode = AudioRolloffMode.Logarithmic;
				source.outputAudioMixerGroup = SFXGroup;
			}

			source.PlayOneShot(ac);

		}

		void PlayVFX (TimelineData.Point pt, TimelineData data, GameObject gameObject, Vector3 direction) {

			var angle = Vector3.Angle(Vector3.right, direction);
			
			if(direction.y < 0) {
				angle *= -1f;
			}

			if(gameObject){
				var go = (GameObject)GameObject.Instantiate(
					Resources.Load(pt.Resource),
					AttachPointComponent.AttachPointPositionOnGameObject(pt.AttachPoint, gameObject),
					Quaternion.AngleAxis(angle, Vector3.forward)
				);

				go.transform.parent = gameObject.transform;
				
				var ttl = go.AddComponent<EffectTTL>();
				ttl.TimeToLive = data.Duration;

				if(data.ReparentOnDeath) {
					Register(gameObject, go);
					ttl.OnExpired += () => UnRegister(gameObject, go);
				}

			}


		}

		private void Register(GameObject host, GameObject timelineContainer) {
			persistentTimelines.Add(timelineContainer);
		}

		private void UnRegister(GameObject host, GameObject container) {
			persistentTimelines.Remove(container);
		}

		public void SoftKill() {
			foreach( var tl in persistentTimelines) {
				var pos = tl.transform.position;
				tl.transform.parent = null;
				tl.transform.position = pos;
			}
		}


	}
}

