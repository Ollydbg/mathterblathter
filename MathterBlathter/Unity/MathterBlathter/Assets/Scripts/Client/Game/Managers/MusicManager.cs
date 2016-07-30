using System;
using Client.Game.Actors;
using Client.Game.Data;
using UnityEngine.Audio;
using UnityEngine;
using System.Linq;
using Client.Game.Map;
using System.Collections;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class MusicManager : IGameManager
	{

		public static AudioMixerGroup MusicGroup;
		public static AudioMixerGroup OverrideGroup;
		public static AudioMixerGroup AmbienceGroup;

		AudioSource MusicSource;
		AudioSource OverrideSource;
		AudioSource AmbienceSource;

		CrossFade Fade;

		public MusicManager ()
		{

		}

		#region IGameManager implementation

		public void Start (Game game)
		{
			MusicGroup = game.AudioMixer.FindMatchingGroups("Music")[0];
			OverrideGroup = game.AudioMixer.FindMatchingGroups("OverrideMusic")[0];
			AmbienceGroup = game.AudioMixer.FindMatchingGroups("Ambience")[0];


			var obj = GameObject.Find("MusicSource");
			MusicSource = obj.GetComponent<AudioSource>();

			OverrideSource = (GameObject.Instantiate(obj) as GameObject).GetComponent<AudioSource>();
			obj =  GameObject.Find("AmbienceSource");
			AmbienceSource = obj.GetComponent<AudioSource>();

			game.RoomManager.OnRoomEntered += OnRoomEntered;

		}

		void OnRoomEntered (Actor actor, Room oldRoom, Room newRoom)
		{
			
			if(newRoom.data.OverrideMusic != null) {
				RequestOverride(newRoom.data.OverrideMusic);
			} else {
				ReleaseOverride();
			}
		}

		public void RequestOverride(MusicData data) {
			var ac = Resources.Load(data.Resource) as AudioClip;
			OverrideSource.clip = ac;
			OverrideSource.Play();
			
			Fade = new CrossFade{From = MusicSource, To = OverrideSource, Duration = 2.75f};
		}


		public void ReleaseOverride() {
			Fade = new CrossFade{To = MusicSource, From = OverrideSource, Duration = 1.5f};
		}

		public void StartRun ()
		{

			//Play(Game.Instance.Seed.RandomInList(MusicDataTable.GetAll().Where(p => p.RunMusic).ToList()));
			Play(MusicDataTable.STRANGER_THEME);

		}

		public void Update (float dt)
		{
			if(Fade != null) {
				Fade.Apply(dt);
				if(Fade.IsComplete) {
					if(Fade.From == OverrideSource)
						OverrideSource.Stop();
					
					Fade = null;
				}
			}
		}

		public void Shutdown ()
		{
		}

		void PlayAmbience (MusicData data)
		{
			var ac = Resources.Load(data.Resource) as AudioClip;
			AmbienceSource.clip = ac;
			AmbienceSource.Play();
		}

		public void Play(MusicData musicData, float crossFadeTime = 1.5f) {
			var ac = Resources.Load(musicData.Resource) as AudioClip;
			MusicSource.clip = ac;
			MusicSource.Play();
		}

		

		public void SetPlayerCharacter (PlayerCharacter player)
		{
		}



		#endregion

		public class CrossFade {
			public AudioSource From;

			public bool IsComplete {
				get { return currentTime >= Duration; }
			}


			public AudioSource To;
			public float Duration;
			public float currentTime;

			public void Apply (float dt)
			{
				currentTime += dt;
				float alpha = Mathf.Clamp01(currentTime/Duration);
				To.volume = alpha;
				From.volume = 1-alpha;
			}

		}
	}
}

