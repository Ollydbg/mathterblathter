using System;
using Client.Game.Actors;
using Client.Game.Data;
using UnityEngine.Audio;
using UnityEngine;

namespace Client.Game.Managers
{
	using Game = Client.Game.Core.Game;

	public class MusicManager : IGameManager
	{

		public static AudioMixerGroup MusicGroup;
		AudioSource MusicSource;

		public MusicManager ()
		{
			var obj = GameObject.Find("MusicSource");
			MusicSource = obj.GetComponent<AudioSource>();

		}

		#region IGameManager implementation

		public void Start (Game game)
		{
			MusicGroup = game.AudioMixer.FindMatchingGroups("Music")[0];
			
		}

		public void Update (float dt)
		{
		}

		public void Shutdown ()
		{
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
	}
}

